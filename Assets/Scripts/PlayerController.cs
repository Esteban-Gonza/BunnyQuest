using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    [SerializeField] float speed = 4f;
    
    public string nextPlaceName;
    public Vector2 lastMovement = Vector2.zero;
    
    bool isWalking = false;

    [Header("Constants")]
    const string horizontal = "Horizontal";
    const string vertical = "Vertical";
    const string lastHorizontal = "LastHorizontal";
    const string lastVertical = "LastVertical";
    const string walking = "IsMoving";

    [Header("References")]
    Animator playerAnimator;
    Rigidbody2D playerRigidBody;

    public static bool playerCreated;

    void Awake(){
        
        if (!playerCreated){
            playerCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    private void Start() {
        
        playerAnimator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {

        //Set animation states
        playerAnimator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        playerAnimator.SetFloat(vertical, Input.GetAxisRaw(vertical));

        playerAnimator.SetFloat(lastHorizontal, lastMovement.x);
        playerAnimator.SetFloat(lastVertical, lastMovement.y);

        playerAnimator.SetBool(walking, isWalking);
    }

    void FixedUpdate() {
        
        isWalking = false;

        if(Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f){

            /*this.transform.Translate(
                new Vector3(Input.GetAxisRaw(horizontal) * speed * Time.deltaTime, 0, 0));*/
            playerRigidBody.velocity = new Vector2(Input.GetAxisRaw(horizontal) * speed,
                playerRigidBody.velocity.y);
            isWalking = true;
            lastMovement = new Vector2(Input.GetAxisRaw(horizontal), 0);
        }

        if(Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f){

            /*this.transform.Translate(
                new Vector3(0, Input.GetAxisRaw(vertical) * speed * Time.deltaTime, 0));*/
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x,
                Input.GetAxisRaw(vertical) * speed);
            isWalking = true;
            lastMovement = new Vector2(0, Input.GetAxisRaw(vertical));
        }

        if(!isWalking){
            playerRigidBody.velocity = Vector2.zero;
        }
    }
}