using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PuertasMueble : MonoBehaviour
{
    [SerializeField] Animator anim;
    public bool chequeo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        chequeo = anim.GetBool("Abrir");
    }

    void OnTriggerStay(Collider other)
    {
        if (chequeo == false && Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("Abrir", true);
            anim.SetBool("Cerrar", false);
        }
        else if (chequeo == true && (Input.GetKeyDown(KeyCode.E)))
        {
            anim.SetBool("Abrir", false);
            anim.SetBool("Cerrar", true);
        }

    }
}
