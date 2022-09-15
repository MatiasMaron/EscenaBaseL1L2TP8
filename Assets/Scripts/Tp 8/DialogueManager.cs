using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject UIElements;
    [SerializeField] TextMeshProUGUI dialogueTxt;
    [SerializeField] TextMeshProUGUI btnTxt;
    [SerializeField] string[] NPCDialogue;
    [SerializeField] NPCDialogue NPCDialogueScript;
    private Timer timer;
    int dialogueIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueIndex == 5)
        {
            btnTxt.text = "Cerrar";
        }
        else
        {
            btnTxt.text = "Siguiente";
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        NPCDialogueScript = other.gameObject.GetComponent<NPCDialogue>();
        if (NPCDialogueScript)
        {
            UIElements.SetActive(true);
            NPCDialogue = NPCDialogueScript.data.dialogueLines;
            ShowNextDialogueLine();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            UIElements.SetActive(false);
            dialogueIndex = 0;
        }

        if ( dialogueIndex == 5)
        {
            timer.startTimer();
        }
    }

    public void ShowNextDialogueLine()
    {
        if (dialogueIndex <= NPCDialogue.Length)
        {
            dialogueTxt.text = NPCDialogue[dialogueIndex];
            dialogueIndex++;
        }
        else if (dialogueIndex == 5 && btnTxt.text == "Cerrar")
        {
            UIElements.SetActive(false);
        }

    }
}
