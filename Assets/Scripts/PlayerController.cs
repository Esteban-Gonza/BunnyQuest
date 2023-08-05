using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    [SerializeField] float speed = 4f;

    bool isWalking = false;
    public Vector2 lastMovement = Vector2.zero;

    const string horizontal = "Horizontal";
    const string vertical = "Vertical";
    const string lastHorizontal = "LastHorizontal";
    const string lastVertical = "LastVertical";
    const string walking = "IsMoving";

    Animator playerAnimator;

    private void Start() {
        
        playerAnimator = GetComponent<Animator>();
    }

    void Update() {
        
        isWalking = false;

        if(Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f){

            this.transform.Translate(
                new Vector3(Input.GetAxisRaw(horizontal) * speed * Time.deltaTime, 0, 0));
            isWalking = true;
            lastMovement = new Vector2(Input.GetAxisRaw(horizontal), 0);
        }

        if(Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f){

            this.transform.Translate(
                new Vector3(0, Input.GetAxisRaw(vertical) * speed * Time.deltaTime, 0));
            isWalking = true;
            lastMovement = new Vector2(0, Input.GetAxisRaw(vertical));
        }

        //Set animation states
        playerAnimator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        playerAnimator.SetFloat(vertical, Input.GetAxisRaw(vertical));

        playerAnimator.SetFloat(lastHorizontal, lastMovement.x);
        playerAnimator.SetFloat(lastVertical, lastMovement.y);

        playerAnimator.SetBool(walking, isWalking);
    }
}