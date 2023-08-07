using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour{

    [SerializeField] GameObject followTarget;
    [SerializeField] Vector3 targetPosition;
    [SerializeField] float cameraSpeed = 4f;

    private void Update() {
        
        targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, this.transform.position.z);
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }
}