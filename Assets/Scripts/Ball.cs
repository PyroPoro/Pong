using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script is attached to the ball.
    It is responsible for controlling the ball's movements, spawning, and detecting scoring.
*/
public class Ball : MonoBehaviour
{
    // a reference to the rigidbody attached to the ball. This allows us to manipulate the physical properties of the ball.
    [SerializeField] Rigidbody2D rb;
    // the base speed of the ball when it is initially launched
    [SerializeField] float ballBaseSpeed;
    // a two dimensional vector that stores the velocity of the ball that we want to set.
    Vector2 ballSpeed;

    // two events that are triggered when the ball is scored into either goal
    public event Action LeftGoalScoredEvent = delegate {};
    public event Action RightGoalScoredEvent = delegate {};
    void Start()
    {
        // spawn the ball at the beginning of the game
        StartCoroutine(SpawnNewBall());
    }

    void Update()
    {
        
    }

    /*
        Choose a random direction for the ball and launch it with a set speed.
    */
    void LaunchBall() {
        float yVel = UnityEngine.Random.Range(0.2f, 1f) * UnityEngine.Random.Range(0, 2) * 2 - 1;
        float xVel = UnityEngine.Random.Range(0, 2) * 2 - 1;
        ballSpeed = ballBaseSpeed * new Vector2(xVel, yVel).normalized;
        rb.velocity = ballSpeed;
    }

    /*
        Triggers whenever the ball collides with a trigger collider.
        In our case, only goals have trigger colliders attached, so we also respawn the ball.
    */
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("LeftGoal")){
            LeftGoalScoredEvent();
        }
        if(collider.CompareTag("RightGoal")){
            RightGoalScoredEvent();
        }
        StartCoroutine(SpawnNewBall());
    }
    
    /*
        Function called when the ball is scored and needs to be respawned in the center.
        Instead of respawning the ball, we just make it invisible and move it back to the center of the screen.
        Call LaunchBall again once the blinking animation finishes to make it luanch in a new direction.
    */
    IEnumerator SpawnNewBall(){
        GetComponent<SpriteRenderer>().enabled = false;
        rb.velocity = Vector2.zero;
        transform.position = Vector3.zero;

        yield return new WaitForSeconds(1f);

        for(int i = 0; i < 3; i++){
            yield return new WaitForSeconds(0.25f);
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.25f);
            GetComponent<SpriteRenderer>().enabled = true;
        }

        yield return new WaitForSeconds(1);
        LaunchBall();
    }
}
