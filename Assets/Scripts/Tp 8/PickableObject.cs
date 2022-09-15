﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{

    public bool isPickable = true;
    public bool Exit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerInteractionZone")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = this.gameObject;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerInteractionZone")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = null;
        }
    }
}
