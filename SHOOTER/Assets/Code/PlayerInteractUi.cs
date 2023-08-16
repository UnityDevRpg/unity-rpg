using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractAI : MonoBehaviour
{
    [SerializeField]private GameObject containerGameObject;
    [SerializeField]private PlayerInteraction playerInteraction;
    [SerializeField]private TextMeshProUGUI interactTextMeshProUGUI;

    
    private void Update() {
        
        if(playerInteraction.GetInteractableObject() != null){

            Show(playerInteraction.GetInteractableObject());

        } else {
            Hide();
        }

    }

    private void Show(NPCinteractable npcInteractable)
    {
    
        containerGameObject.SetActive(true);
        interactTextMeshProUGUI.text = npcInteractable.GetInteractText();
    
    }


    private void Hide()
    {
    
        containerGameObject.SetActive(false);
    
    }

    
}
