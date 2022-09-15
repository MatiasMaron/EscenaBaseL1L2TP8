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
    int dialogueIndex = 0;

    [Header("Timer")]
    [SerializeField] private int minutes;
    [SerializeField] private int seconds;

    [SerializeField] private TextMeshProUGUI timer;

    private float restante;
    private bool enMarcha;

    int DialogueIndex;

    void Awake()
    {
        restante = (minutes * 60) + seconds;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ShowNextDialogueLine();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        NPCDialogueScript = other.gameObject.GetComponent<NPCDialogue>();
        dialogueIndex = 0;
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
    }

    public void ShowNextDialogueLine()
    {
        Debug.Log("Se esta ejecutando");
        if (dialogueIndex < NPCDialogue.Length)
        {
            dialogueTxt.text = NPCDialogue[dialogueIndex];
            dialogueIndex++;
        }
    } 

    private void StartTimer()
    {
        if (enMarcha)
        {
            restante -= Time.deltaTime;
            if (restante < 1)
            {
                //EndGame
            }
        }
    }
}
