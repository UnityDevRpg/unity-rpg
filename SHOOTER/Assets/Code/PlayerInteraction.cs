using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    if(Input.GetKeyDown(KeyCode.E)){
    float interactRange = 5f;
    Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
    foreach(Collider collider in colliderArray){
    
        if (collider.TryGetComponent(out NPCinteractable npcInteractable)){

            npcInteractable.Interact();

        }
    
    }
    }
    }

    public NPCinteractable GetInteractableObject()
    {

    float interactRange = 5f;
    Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
    foreach(Collider collider in colliderArray){
    
        if (collider.TryGetComponent(out NPCinteractable npcInteractable)){

            return npcInteractable;

        }
        
    
    }
    return null;

    }
}

