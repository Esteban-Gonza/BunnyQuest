using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour{

    [SerializeField] float speed = 1.0f;

    [SerializeField] float timeBetweenSteps;
    float timeBetweenStepsCounter = 1.0f;

    [SerializeField] float timeToMakeStep;
    float timeToMakeStepCounter;

    Vector2 directionToMakeStep;
    Vector2 lastMovement;

    [Header("References")]
    Rigidbody2D enemyRigidbody;
    Animator enemyAnimator;

    [Header("Constants")]
    const string horizontal = "Horizontal";
    const string vertical = "Vertical";
    const string lastHorizontal = "LastHorizontal";
    const string lastVertical = "LastVertical";

    bool isMoving;

    void Start(){
        enemyAnimator = GetComponent<Animator>();
        enemyRigidbody = GetComponent<Rigidbody2D>();

        timeBetweenStepsCounter = timeBetweenSteps;
        timeToMakeStepCounter = timeToMakeStep;
    }

    void Update(){
        
        enemyAnimator.SetFloat(horizontal, directionToMakeStep.x);
        enemyAnimator.SetFloat(vertical, directionToMakeStep.y);
        enemyAnimator.SetFloat(lastHorizontal, lastMovement.x);
        enemyAnimator.SetFloat(lastVertical, lastMovement.y);
        enemyAnimator.SetBool("IsMoving", isMoving);

    }

    void FixedUpdate(){

        if (isMoving){

            timeToMakeStepCounter -= Time.deltaTime;
            enemyRigidbody.velocity = directionToMakeStep;

            if(timeToMakeStepCounter < 0){

                isMoving = false;
                timeBetweenStepsCounter = timeBetweenSteps;
                enemyRigidbody.velocity = Vector2.zero;
            }
        }else{

            timeBetweenStepsCounter -= Time.deltaTime;
            if(timeBetweenStepsCounter < 0){
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;

                directionToMakeStep = new Vector2(Random.Range(-1,2), Random.Range(-1,2)) * speed;
            }
        }

        lastMovement = new Vector2(directionToMakeStep.x, directionToMakeStep.y);
    }
}