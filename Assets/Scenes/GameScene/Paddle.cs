using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;

    float height;

    string input;
    public bool isRight;
    private Vector2 initialPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        height = transform.localScale.y;
    }

    public void Init(bool isRightPaddle)
    {
        isRight = isRightPaddle;

        Vector2 pos = Vector2.zero;

        if (isRightPaddle)
        {
            //Put paddle on right side
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x; // Keeps paddles on screen by shifting left a bit

            input = "PaddleRight";
        }
        else
        {
            //Put paddle on left side
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x; //Keeps paddles on screen by shifting right a bit

            input = "PaddleLeft";
        }
        //Save original position
        initialPosition = pos;
        //Update paddle's position
        transform.position = pos;

        transform.name = input;
    }
    // Update is called once per frame
    void Update()
    {
        //GetAxis is a number between -1 to 1 (-1 for down, 1 for up)
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        //Restrict paddle movement
        //If user attempts to move paddle too low, STOP
        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }
        //If user attempts to move paddle too high, STOP
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }
        transform.Translate(move * Vector2.up);
    }
    
    public void ResetPaddle()
    {
        transform.position = initialPosition;
    }
}
