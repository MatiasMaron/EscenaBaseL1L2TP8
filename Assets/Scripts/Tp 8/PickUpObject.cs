using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class PickUpObject : MonoBehaviour
{

    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform interactionZone;
    public Transform ZonaADejar;
    private bool ExitHere;

    [Header("NPC")]
    NavMeshAgent agent;
    [SerializeField] Transform destination;
    [SerializeField] Animator anim;
    [SerializeField] Transform NPCPosition;
    [SerializeField] GameObject npc;

    [Header("Objetos")]
    public TextMeshProUGUI txtObjetos;
    public TextMeshProUGUI txtMision;

    [Header("ObjetosAEncontrar")] 
    public GameObject Gabinete;
    public GameObject Teclado;
    public GameObject Monitor;
    public GameObject Mouse;

    public int objetosEncontrados = 0;

    void Start()
    {
        txtObjetos.enabled = false;
        txtMision.enabled = false;
        agent = npc.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickableObject>().isPickable == true && PickedObject == null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<PickableObject>().isPickable = false;
                PickedObject.transform.SetParent(interactionZone);
                PickedObject.transform.position = interactionZone.position;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        else if (PickedObject != null && PickedObject.GetComponent<Tags>().Objeto == "Mouse")
        {
            ZonaADejar = Mouse.transform;
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject.GetComponent<PickableObject>().isPickable = true;
                PickedObject.transform.SetParent(ZonaADejar);
                PickedObject.transform.position = ZonaADejar.position;
                PickedObject.transform.rotation = ZonaADejar.rotation;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
                PickedObject.transform.SetParent(null);
                PickedObject = null;
                Mouse.SetActive(false);
                ZonaADejar = null;
                objetosEncontrados++;
            }
        }
        else if (PickedObject != null && PickedObject.GetComponent<Tags>().Objeto == "Teclado")
        {
            ZonaADejar = Teclado.transform;
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject.GetComponent<PickableObject>().isPickable = true;
                PickedObject.transform.SetParent(ZonaADejar);
                PickedObject.transform.position = ZonaADejar.position;
                PickedObject.transform.rotation = ZonaADejar.rotation;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
                PickedObject.transform.SetParent(null);
                PickedObject = null;
                Teclado.SetActive(false);
                ZonaADejar = null;
                objetosEncontrados++;
            }
        }
        else if (PickedObject != null && PickedObject.GetComponent<Tags>().Objeto == "Gabinete")
        {
            ZonaADejar = Gabinete.transform;
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject.GetComponent<PickableObject>().isPickable = true;
                PickedObject.transform.SetParent(ZonaADejar);
                PickedObject.transform.position = ZonaADejar.position;
                PickedObject.transform.rotation = ZonaADejar.rotation;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
                PickedObject.transform.SetParent(null);
                PickedObject = null;
                Gabinete.SetActive(false);
                ZonaADejar = null;
                objetosEncontrados++;
            }
        }
        else if (PickedObject != null && PickedObject.GetComponent<Tags>().Objeto == "Monitor")
        {
            ZonaADejar = Monitor.transform;
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject.GetComponent<PickableObject>().isPickable = true;
                PickedObject.transform.SetParent(ZonaADejar);
                PickedObject.transform.position = ZonaADejar.position;
                PickedObject.transform.rotation = ZonaADejar.rotation;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
                PickedObject.transform.SetParent(null);
                PickedObject = null;
                Monitor.SetActive(false);
                ZonaADejar = null;
                objetosEncontrados++;
            }
        }
            txtObjetos.text = ("Objetos Encontrados " + objetosEncontrados + "/4");

        if (objetosEncontrados == 4)
        {
            agent.destination = destination.position;
            anim.SetBool("Walking", true);
        }

    }
}
