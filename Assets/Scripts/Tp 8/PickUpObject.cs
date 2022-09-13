using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    public GameObject ObjectToPickUp;
    public GameObject ObjectToPickUp2;
    public GameObject PickedObject;
    public GameObject gabinete;
    public Transform interactionZone;
    public Transform ZonaADejar;
    private bool ExitHere;
    private string GabineteD, MonitorD, MouseD, TecladoD;

    void Start()
    {
        ExitHere = GetComponent<PickableObject>().Exit;
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectToPickUp2.name == "Gabinete")
        {
            ZonaADejar = gabinete.transform;
        }



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

        else if (PickedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject.GetComponent<PickableObject>().isPickable = true;
                PickedObject.transform.SetParent(null);
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject = null;
            }
        }
    }
}
