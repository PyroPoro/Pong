using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float ballBaseSpeed;
    Vector2 ballSpeed;

    public event Action LeftGoalScoredEvent = delegate {};
    public event Action RightGoalScoredEvent = delegate {};
    void Start()
    {
        StartCoroutine(SpawnNewBall());
    }

    void Update()
    {
        
    }

    void LaunchBall() {
        float yVel = UnityEngine.Random.Range(0.2f, 1f) * UnityEngine.Random.Range(0, 2) * 2 - 1;
        float xVel = UnityEngine.Random.Range(0, 2) * 2 - 1;
        ballSpeed = ballBaseSpeed * new Vector2(xVel, yVel).normalized;
        rb.velocity = ballSpeed;
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("LeftGoal")){
            LeftGoalScoredEvent();
        }
        if(collider.CompareTag("RightGoal")){
            RightGoalScoredEvent();
        }
        StartCoroutine(SpawnNewBall());
    }
    
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
