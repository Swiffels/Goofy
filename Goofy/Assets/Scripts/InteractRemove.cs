using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRemove : MonoBehaviour, IInteractable
{
   
    public void Interact(){
        Destroy(this.gameObject);
    }

}
