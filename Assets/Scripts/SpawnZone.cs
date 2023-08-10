using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour{

    [SerializeField] Vector2 facingDirection = Vector2.zero;
    [SerializeField] string placeName;

    [Header("References")]
    PlayerController player;
    CameraController mainCamera;

    private void Start(){
        
        player = FindObjectOfType<PlayerController>();
        mainCamera = FindObjectOfType<CameraController>();

        if (!player.nextPlaceName.Equals(placeName)){
            return;
        }

        player.transform.position = this.transform.position;
        mainCamera.transform.position = new Vector3(
            this.transform.position.x, this.transform.position.y, mainCamera.transform.position.z);

        player.lastMovement = facingDirection;
    }
}