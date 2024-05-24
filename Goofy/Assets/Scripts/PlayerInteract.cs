using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] float interactRange = 2f;
    [SerializeField] float interactRadius = 1f;
    [SerializeField] LayerMask interactionLayer;
    [SerializeField] Transform playerCamera;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){

            RaycastHit hit;

            Debug.Log(Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, interactRange));

            if(Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, interactRange)){

                Debug.Log("Hit Pickup Object Named: " + hit.collider.name);

            }

        }
        
    }

    void OnDrawGizmos(){

        Gizmos.color = Color.blue;

        RaycastHit hit;

        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, interactRange)) {

        Gizmos.DrawLine(playerCamera.position, hit.point); 

        }

    }

}
