using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] Rigidbody2D leftPaddle;
    [SerializeField] Rigidbody2D rightPaddle;
    [SerializeField] float paddleSpeed;
    void Update()
    {
        int leftVelocity = 0;
        int rightVelocity = 0;

        leftPaddle.velocity = Vector2.zero;
        rightPaddle.velocity = Vector2.zero;

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

        leftPaddle.velocity = new Vector2(0, leftVelocity * paddleSpeed);
        rightPaddle.velocity = new Vector2(0, rightVelocity * paddleSpeed);
    }
}
