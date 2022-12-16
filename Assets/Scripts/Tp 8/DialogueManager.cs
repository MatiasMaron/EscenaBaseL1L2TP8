using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject UIElements;
    [SerializeField] TextMeshProUGUI dialogueTxt;
    [SerializeField] TextMeshProUGUI btnTxt;
    [SerializeField] string[] NPCDialogue;
    [SerializeField] NPCDialogue NPCDialogueScript;
    int dialogueIndex = 0;
    private bool iniciartimer = false;
    private bool iniciartimer2 = false;

    [Header("Textos")]
    [SerializeField] public TextMeshProUGUI objetos;
    [SerializeField] public  TextMeshProUGUI mision;

    [Header("Timer")]
    [SerializeField] public int minutes;
    [SerializeField] public int seconds;

    [SerializeField] private TextMeshProUGUI timer;

    private float restante;
    public bool enMarcha;

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
        if (enMarcha == false)
        {
            timer.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ShowNextDialogueLine();
        }

        if (dialogueIndex == 5)
        {
            iniciartimer2 = true;
        }

        if (iniciartimer == true && iniciartimer2 == true)
        {
            enMarcha = true;
            objetos.enabled = true;
            mision.enabled = true;
        }

        StartTimer();

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
            iniciartimer = true;
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
            timer.enabled = true;
            restante -= Time.deltaTime;
            if (restante < 1)
            {
                SceneManager.LoadScene(1);
            }
            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            timer.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        }
    }
}
