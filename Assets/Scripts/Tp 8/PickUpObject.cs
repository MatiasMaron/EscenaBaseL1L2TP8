using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpObject : MonoBehaviour
{

    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform interactionZone;
    public Transform ZonaADejar;
    private bool ExitHere;

    [Header("Objetos")]
    public TextMeshProUGUI txtObjetos;

    [Header("ObjetosAEncontrar")] 
    public GameObject Gabinete;
    public GameObject Teclado;
    public GameObject Monitor;
    public GameObject Mouse;

    public int objetosEncontrados = 0;

    void Start()
    {
        //ExitHere = GetComponent<PickableObject>().Exit;
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

        txtObjetos.text = ("ObjetosEncontrados " + objetosEncontrados + "/4");

    }
}
