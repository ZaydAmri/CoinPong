using UnityEngine;
using UnityEngine.UI;

public class GammarjiBallController : MonoBehaviour {

    //----configuration
    public float constanteSpeed;
    public float frottement;
    public float frottement2;
    float frottement1;
    public int numberOfBalls = 3;
    public int bronzeScore, silverScore, goldScore;
    public float arrowLength = 2f;
    //----etat partie
    public enum ballState
    {
        aim,
        fire,
        wait,
        endShot
    }

    public ballState currentBallState;

    public bool bronzeTouche = false, silverTouche = false, goldTouche = false; 
    
    //bool touched = true;
    int score = 0;
    bool stopped = true;
    int highscore = 0;
    bool accelerated = false;
    //----variable temporaire
    Vector2 ballPositionWhenRelease;
    float lineLength = 0;
    private Vector2 mouseStartPosition;
    private Vector2 mouseEndPosition;
    private float ballVelocityX, ballVelocityY;
    bool firstClick = false;
    int scoreInitial, tempScore;
    
    //----objet externe
    public GameObject pressPosition;
    public Rigidbody2D ball;
    public GameObject arrow;
    public GammarjiGoalSpawner goalSpawner;
    public Text textScore, textBalls, TextHighscore;
    public GammarjiManager gameManager;

    void Start()
    {

        frottement1 = frottement;
        currentBallState = ballState.aim;
        textScore.text = score.ToString();
        textBalls.text = numberOfBalls.ToString();

        highscore = gameManager.GetHighscore();
        TextHighscore.text = "Highscore = " + highscore;
    }

    void Update()
    {
        
        switch (currentBallState)
        {
            case ballState.aim:
                if ((Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)))
                {
                    MouseClicked();
                    firstClick = true;
                }
                if ((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)))
                {
                    if (firstClick)
                    {

                        MouseDragged();
                    }

                }
                if ((Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)))
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
                if ((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)))
                {
                    Accelerate();
                }
                if ((Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)))
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






        if (currentBallState == ballState.fire)
        {
            ball.velocity *= frottement;
        }

        if (ball.velocity.magnitude < 0.25f && currentBallState == ballState.fire)
        {
            ball.velocity = Vector2.zero;
            stopped = true;

        }

        if (ball.velocity == Vector2.zero && stopped && currentBallState == ballState.fire)
        {
            if (goldTouche)
            {
                CalculScore(goldScore);
            }
            else if (silverTouche)
            {
                CalculScore(silverScore);
            }
            else if (bronzeTouche)
            {
                CalculScore(bronzeScore);
            }
            else
            {
                score = scoreInitial;
                UpdateScore();
                numberOfBalls--;
                textBalls.text = numberOfBalls.ToString();
                Desaccelerate();
                this.gameObject.GetComponent<TrailRenderer>().enabled = false;
                this.transform.position = ballPositionWhenRelease;



                if (numberOfBalls == 0)
                {
                    if (score > highscore)
                    {
                        gameManager.SetHighscore(score);
                    }
                    UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
                }
            }







            
            currentBallState = ballState.aim;
        }


    }
    //---------------------------------------------------------------------------------------------------------------------

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
    //---------------------------------------------------------------------------------------------------------------------
    public void MouseDragged()
    {
        if (Input.touchCount > 0)
        {
            int touchCount = Input.touchCount;
            arrow.SetActive(true);
            Vector2 tempMousePosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(touchCount - 1).position);
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
    //---------------------------------------------------------------------------------------------------------------------
    public void ReleaseMouse()
    {
        ballPositionWhenRelease = this.transform.position;
        //touched = false;
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

            if (lineLength > 0.15f)
            {
                stopped = false;
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


    //---------------------------------------------------------------------------------------------------------------------
    void OnCollisionEnter2D()
    {
        score++;
        UpdateScore();
    }

    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("green"))
        {
            //----------
            if(other.gameObject.name== "bronze")
            {
                bronzeTouche = true;
            } else if (other.gameObject.name == "silver")
            {
                silverTouche = true;
            } else if (other.gameObject.name == "gold")
            {
                goldTouche = true;
            }


            //----------
            


           
        }

        

    }

    void OnTriggerExit2D(Collider2D other)
    {


        if (other.CompareTag("green"))
        {
            //----------
            if (other.gameObject.name == "bronze")
            {
                bronzeTouche = false;
            }
            else if (other.gameObject.name == "silver")
            {
                silverTouche = false;
            }
            else if (other.gameObject.name == "gold")
            {
                goldTouche = false;
            }
            
        }

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


    //---------------------------------------------------------------------------------------------------------------------

    void CalculScore(int couleur)
    {
        score+=couleur;
        
        currentBallState = ballState.endShot;
        ball.velocity = Vector2.zero;

        goalSpawner.DeleteGoal();

        if (accelerated)
        {
            Desaccelerate();
        }


        
        goalSpawner.SpawnGoal(ball.transform.position);
        textScore.text = score.ToString();
        currentBallState = ballState.aim;


    }









    //-------------------------------end
}
