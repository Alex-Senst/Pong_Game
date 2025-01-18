using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;


    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    public Paddle leftPaddle;
    public Paddle rightPaddle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Convert screen's pixel coordinate into game's coordinate
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //Create a left and a right paddle
        leftPaddle = Instantiate(paddle) as Paddle;
        rightPaddle = Instantiate(paddle) as Paddle;
        rightPaddle.Init(true); //right paddle
        leftPaddle.Init(false); //left paddle

        ball.leftPaddle = leftPaddle;
        ball.rightPaddle = rightPaddle;
    }
}
