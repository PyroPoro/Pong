using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script is responsible for listening to scoring events, tracking the current score, and determining the winner.
*/
public class ScoreManager : MonoBehaviour
{
    // a reference to the ball so we can listen to its scoring events.
    [SerializeField] Ball ball;
    // the two variable for tracking the score of each player.
    [SerializeField] int leftScore = 0;
    [SerializeField] int rightScore = 0;
    void Start()
    {
        // subscribe to the scoring events
        ball.LeftGoalScoredEvent += LeftGoalScored;
        ball.RightGoalScoredEvent += RightGoalScored;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // functions to call when a goal is scored.
    void LeftGoalScored(){
        rightScore++;
    }

    void RightGoalScored(){
        leftScore++;
    }
}
