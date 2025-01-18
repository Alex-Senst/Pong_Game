using UnityEditor;
using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;


public class Ball : MonoBehaviour
{
    public CanvasToggle toggle;
    public Paddle leftPaddle;
    public Paddle rightPaddle;
    [SerializeField]
    float speed;

    float radius;
    public Vector2 direction;
    private bool start = true;
    private bool menuVisible = true;
    private bool first = true;
    public int leftScore = 0;
    public int rightScore = 0;

    public TMPro.TextMeshProUGUI leftScoreText;
    public TMPro.TextMeshProUGUI rightScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
        transform.position = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            Time.timeScale = 0;
        }

        if (Input.GetKey(KeyCode.Tab) && !menuVisible)
        {
            start = false;
            Time.timeScale = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && first)
        {
            menuVisible = false;
            toggle.ToggleCanvasVisibility();
            first = false;
            start = false;
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            menuVisible = !menuVisible;
            if (menuVisible)
            {
                Time.timeScale = 0;
            }
            else if (!menuVisible && !start)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }

        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        transform.Translate(direction * speed * Time.deltaTime);
        
        //Top and bottom collisions
        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0) {
            direction.y = -direction.y;
        }
        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }

        if (transform.position.x < GameManager.bottomLeft.x - radius && direction.x < 0)
        {
            rightScore++;
            UpdateScoreUI();
            Time.timeScale = 0;
            ResetBall();
        }
        if (transform.position.x > GameManager.topRight.x + radius && direction.x > 0)
        {
            leftScore++;
            UpdateScoreUI();
            Time.timeScale = 0;
            ResetBall();
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Paddle")
        {
            bool isRight = other.GetComponent<Paddle>().isRight;

            //rebounds off right paddle
            if(isRight == true && direction.x > 0)
            {
                direction.x = -direction.x;
            }
            //rebounds off left paddle
            if(isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;
            }
        }
    }

    private void UpdateScoreUI()
    {
        leftScoreText.text = "Score: " + leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

    private void ResetBall()
    {
        transform.position = Vector2.zero;
        enabled = true;
        start = true;
        leftPaddle.ResetPaddle();
        rightPaddle.ResetPaddle();
    }

}
