using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] float interactRange = 2f;
    [SerializeField] float interactRadius = 1f;
    [SerializeField] LayerMask interactionLayer;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){

            Debug.Log("E Pressed");

            RaycastHit hit;

            if(Physics.SphereCast(transform.position, interactRadius, transform.forward, out hit, interactRange, interactionLayer)){

                Debug.Log("Hit Pickup Object Named: " + hit.collider.name);

            }

        }
        
    }

}
