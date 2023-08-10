using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesTransition : MonoBehaviour{

    [SerializeField] string newPlaceName;
    [SerializeField] string goToPlaceName;
    [SerializeField] GameObject interactionMark;

    bool isInRange = false;

    void Start(){
        
        interactionMark.SetActive(false);
    }

    void Update(){

        if (isInRange == true && Input.GetKeyDown(KeyCode.E)){

            FindObjectOfType<PlayerController>().nextPlaceName = goToPlaceName;
            SceneManager.LoadScene(newPlaceName);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject.CompareTag("Player")){

            isInRange = true;
            interactionMark.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision){

        if (collision.gameObject.CompareTag("Player")){

            isInRange = false;
            interactionMark.SetActive(false);
        }
    }
}