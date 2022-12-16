using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class scriptmovimiento : MonoBehaviour
{

    [SerializeField] Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("npc"))
        {  
        anim.SetBool("Walking", false);
        anim.SetBool("RTurn", true);
        }
    }
}
