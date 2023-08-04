using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    [SerializeField] float speed = 4f;

    const string horizontal = "Horizontal";
    const string vertical = "Vertical";

    void Update() {
        
        if(Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f){

            this.transform.Translate(
                new Vector3(Input.GetAxisRaw(horizontal) * speed * Time.deltaTime, 0, 0));
        }

        if(Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f){

            this.transform.Translate(
                new Vector3(0, Input.GetAxisRaw(vertical) * speed * Time.deltaTime, 0));
        }
    }
}