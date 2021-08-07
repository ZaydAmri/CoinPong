using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    
    //----configuration
    public float constanteSpeed;
    public float frottement;
    public float frottement2;
    float frottement1;
    public int numberOfBalls = 3;
    public int level2, level3,level4,level5,level6;
    public float arrowLength = 2.5f;
    //----etat partie
    public bool play = true;
    public enum ballState
    {
        aim,
        fire,
        wait,
        endShot
    }
    public ballState currentBallState;
    bool touched = true;
    int score = 0;
    int combo = 0;
    public int level = 1;
    int highscore = 0;
    int highCombo = 0;
    bool accelerated = false;
    //----variable temporaire
    Vector2 ballPositionWhenRelease;
    float lineLength = 0;
    private Vector2 mouseStartPosition;
    private Vector2 mouseEndPosition;
    private float ballVelocityX, ballVelocityY;
    bool firstClick = false;
    int scoreInitial,tempScore;
    //----objet externe
    public Slider scoreSlider;
    public GameObject pressPosition;
    public Rigidbody2D ball;
    public GameObject arrow;
    public GoalSpawner goalSpawner;
    public Text textScore, textBalls,TextHighscore,textCombo,textHighCombo;
    public GameManager gameManager;
    public MainGameUI gameUI;
    public GameAudioManager audioManager;
    void Start () {

        frottement1 = frottement;
        currentBallState = ballState.aim;

        textScore.text = score.ToString();
        textBalls.text = numberOfBalls.ToString();
        scoreSlider.value = score;

        highscore = gameManager.GetHighscore();
        TextHighscore.text = highscore.ToString();
        highCombo = gameManager.GetHighCombo();
        textHighCombo.text = highCombo.ToString();

        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            SetVolume(0);
        }
        else
        {
            SetVolume(1);
        }
    }
	
	// Update is called once per frame
	void Update () {
       // Debug.Log(ball.velocity);
        switch (currentBallState)
        {
            case ballState.aim:
                if ((Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && play)
                {
                    MouseClicked();
                    firstClick = true;
                }
                if ((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)) && play)
                {
                    if (firstClick)
                    {

                        MouseDragged();
                    }
                    
                }
                if ((Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)) && play)
                {
                    if (firstClick)
                    {
                        tempScore = 0;
                        scoreInitial = score;
                        ReleaseMouse();
                    }

                    
                    firstClick = false;
                }
                break;
            case ballState.fire:
                if ((Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)))
                {
                   
                }
                if ((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)) && play)
                {
                    Accelerate();
                }
                if ((Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)) && play)
                {
                    if (accelerated)
                    {
                        Desaccelerate();
                    }
                }
                
                break;
            case ballState.wait:

                break;
            case ballState.endShot:

                break;
            default:
                break;
            
        }






        if (currentBallState == ballState.fire && play)
        {
            ball.velocity *= frottement;
        }

        if(ball.velocity.magnitude < 0.25f && currentBallState == ballState.fire && play)
        {
            ball.velocity = Vector2.zero;
            touched = false;
            
        }

        if(ball.velocity == Vector2.zero && !touched && currentBallState == ballState.fire && play)
        {
            score = scoreInitial;
            scoreSlider.value = score;
            UpdateScore();

            numberOfBalls--;
            
            if (combo > highCombo)
            {
                highCombo = combo;
                gameManager.SetHighCombo(combo);
                textHighCombo.text = highCombo.ToString();
            }
            combo = 0;
            textBalls.text = numberOfBalls.ToString();
            textCombo.text = "Combo : "+combo.ToString();
            Desaccelerate();
            this.gameObject.GetComponent<TrailRenderer>().enabled = false;
            this.transform.position = ballPositionWhenRelease;
            


            if (numberOfBalls == 0)
            {
                audioManager.PlayGameOver();
                if (score > highscore)
                {
                    gameManager.SetHighscore(score);
                }


                gameUI.GameOverMenu();
            }else
            {
                audioManager.PlayNumberDown();
            }
            currentBallState = ballState.aim;
        }

       
	}


    public void MouseClicked()
    {
        
        if (Input.touchCount > 0)
        {
            mouseStartPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            pressPosition.transform.position = mouseStartPosition;
            pressPosition.SetActive(true);
        }
        else
        {
            mouseStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pressPosition.transform.position = mouseStartPosition;
            pressPosition.SetActive(true);
        }
        
    }

    public void MouseDragged()
    {
        if (Input.touchCount > 0)
        {
            int touchCount = Input.touchCount;
            arrow.SetActive(true);
            Vector2 tempMousePosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(touchCount-1).position);
            float diffX = mouseStartPosition.x - tempMousePosition.x;
            float diffY = mouseStartPosition.y - tempMousePosition.y;
            
            Vector2 line = new Vector2(diffX, diffY);
            
            if (line.magnitude > arrowLength)
            {
                line.Normalize();
                line.x *= arrowLength;
                line.y *= arrowLength;
            }
            arrow.GetComponent<LineRenderer>().SetPosition(1, line);
            lineLength = line.magnitude;
            
        }
        else
        {
            
            
            arrow.SetActive(true);
            Vector2 tempMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float diffX = mouseStartPosition.x - tempMousePosition.x;
            float diffY = mouseStartPosition.y - tempMousePosition.y;
            
            Vector2 line = new Vector2(diffX, diffY);
            
            if (line.magnitude > arrowLength)
            {
                line.Normalize();
                line.x *= arrowLength;
                line.y *= arrowLength;
            }

            arrow.GetComponent<LineRenderer>().SetPosition(1, line);
            lineLength = line.magnitude;
            
        }

        

    }
    public void ReleaseMouse()
    {
        ballPositionWhenRelease = this.transform.position;
        touched = false;
        pressPosition.SetActive(false);

        if (Input.touchCount > 0)
        {

            this.gameObject.GetComponent<TrailRenderer>().enabled = true;
            arrow.SetActive(false);
            if (lineLength > 0.15f)
            {
                int touchCount = Input.touchCount;
                currentBallState = ballState.fire;
                

                mouseEndPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(touchCount - 1).position);
                ballVelocityX = (mouseStartPosition.x - mouseEndPosition.x);
                ballVelocityY = (mouseStartPosition.y - mouseEndPosition.y);
                Vector2 tempVelocity = new Vector2(ballVelocityX, ballVelocityY);
                

                if (tempVelocity.magnitude > 1.5f)
                {
                    tempVelocity = new Vector2(ballVelocityX, ballVelocityY).normalized;
                    ball.velocity = constanteSpeed * tempVelocity * 1.5f;

                }
                else
                {
                    ball.velocity = constanteSpeed * tempVelocity;
                }

                if (ball.velocity == Vector2.zero)
                {
                    return;
                }

                
            }
                
        }
        else
        {
            arrow.SetActive(false);

            if (lineLength>0.15f)
            {
                currentBallState = ballState.fire;
                this.gameObject.GetComponent<TrailRenderer>().enabled = true;
                mouseEndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ballVelocityX = (mouseStartPosition.x - mouseEndPosition.x);
                ballVelocityY = (mouseStartPosition.y - mouseEndPosition.y);
                Vector2 tempVelocity = new Vector2(ballVelocityX, ballVelocityY);
                
                if (tempVelocity.magnitude > 1.5f)
                {
                    tempVelocity = new Vector2(ballVelocityX, ballVelocityY).normalized;
                    ball.velocity = constanteSpeed * tempVelocity * 1.5f;

                }
                else
                {
                    ball.velocity = constanteSpeed * tempVelocity;
                }

                if (ball.velocity == Vector2.zero)
                {
                    return;
                }
                
            }


            
        }

        
    }
    void OnCollisionEnter2D()
    {
        audioManager.PlayTouchBorder();
        score++;
        scoreSlider.value = score;
        UpdateScore();
    }

    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("green"))
        {
            audioManager.PlayTouchGoal();
            score++;
            scoreSlider.value = score;
            combo++;
            touched = true;
            currentBallState = ballState.endShot;
            ball.velocity = Vector2.zero;
            Destroy((GameObject)other.transform.parent.gameObject);
            if (accelerated)
            {
                Desaccelerate();
            }


            if (score < level2+1)
            {
                level = 1;
            }else if (score < level3+1)
            {
                level = 2;
            }
            else if (score < level4 + 1)
            {
                level = 3;
            }
            else if (score < level5 + 1)
            {
                level = 4;
            }
            else if (score < level6 + 1)
            {
                level = 5;
            }
            else
            {
                level = 6;
            }

            goalSpawner.SpawnGoal(ball.transform.position, level);
            textScore.text = score.ToString();
            textCombo.text = "Combo : " + combo.ToString();
            currentBallState = ballState.aim;

        }

        /*
        if (other.CompareTag("red"))
        {
            Destroy((GameObject)other.transform.parent.gameObject);
            
            Destroy((GameObject)ball.gameObject);
            Debug.Log("game over");
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);


        }
        */
        
    }

    public void Accelerate()
    {
        
        accelerated = true;
        Time.timeScale = 3f;
        frottement = frottement2;
    }
    public void Desaccelerate()
    {
        
        accelerated = false;
        Time.timeScale = 1.0f;
        frottement = frottement1;
    }
    public void UpdateScore()
    {
        textScore.text = score.ToString();
    }
     public void SetVolume(int x)
    {
        audioManager.gameObject.GetComponent<AudioSource>().volume = x;
    }

    //---------------------
}
