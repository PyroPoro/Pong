using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script is responsible for controlling the two paddles.
    Takes in keyboard input.
    W and S for the left paddle, Up Arrow and Down Arrow for the the right paddle.
*/
public class PaddleController : MonoBehaviour
{
    // references to the rigidbodies of the two paddles so we can move them via physics
    [SerializeField] Rigidbody2D leftPaddle;
    [SerializeField] Rigidbody2D rightPaddle;
    // the speeds of the paddles
    [SerializeField] float paddleSpeed;
    void Update()
    {
        // reset the velocity of both paddles at the start of each frame so the paddles only move when the buttons are held down
        int leftVelocity = 0;
        int rightVelocity = 0;

        leftPaddle.velocity = Vector2.zero;
        rightPaddle.velocity = Vector2.zero;

        // take user input and increment/decrement the tracking variables
        if(Input.GetKey(KeyCode.W)){
            leftVelocity++;
        }
        if(Input.GetKey(KeyCode.S)){
            leftVelocity--;
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            rightVelocity++;
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            rightVelocity--;
        }

        // set the velocities based on which keys were pressed.
        leftPaddle.velocity = new Vector2(0, leftVelocity * paddleSpeed);
        rightPaddle.velocity = new Vector2(0, rightVelocity * paddleSpeed);
    }
}
