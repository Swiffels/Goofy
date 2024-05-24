using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] float interactRange = 2f;
    [SerializeField] float interactRadius = 1f;
    [SerializeField] Transform playerCamera;

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.E)){

            RaycastHit hit;

            int interactionLayer = LayerMask.GetMask("Pickups");

            if(Physics.SphereCast(playerCamera.position, interactRadius, playerCamera.forward, out hit, interactRange, interactionLayer, QueryTriggerInteraction.Ignore)){

                Debug.Log("Hit Pickup Object Named: " + hit.collider.name);

            }

        }
        
    }

    void OnDrawGizmos(){

        Gizmos.color = Color.blue;

        RaycastHit hit;

        int interactionLayer = LayerMask.GetMask("Pickups");

        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, interactRange, interactionLayer)) {

            Gizmos.DrawWireSphere(playerCamera.position, interactRadius); 
            Gizmos.DrawWireSphere(hit.point, interactRadius);

        }

    }

}
