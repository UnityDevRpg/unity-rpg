using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCinteractable : MonoBehaviour
{
    public Quest quest;
    
    public PlayerMovement playerQuest;
    public GameObject QuestMenuMenu;
    public GameObject OtherMenu;
    public GameObject OtherMenu1;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI experienceText;
    public TextMeshProUGUI goldText;
    
    [SerializeField]private string interactText;
    public Transform player;
    void Update()
    {
        
        transform.LookAt(player);

    }

    public void Interact()
    {
        OtherMenu.SetActive(false);
        OtherMenu1.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        QuestMenuMenu.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        experienceText.text = quest.experienceReward.ToString();
        goldText.text = quest.goldReward.ToString();

    
    }

    public void acceptQuest()
    {

        QuestMenuMenu.SetActive(false);
        OtherMenu.SetActive(true);
        OtherMenu1.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        quest.isActive = true;
        playerQuest.quest = quest;
    

    }


    public string GetInteractText()
    {
        return interactText;
    }
}
