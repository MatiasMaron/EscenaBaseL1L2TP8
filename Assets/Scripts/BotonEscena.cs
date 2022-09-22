using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonEscena : MonoBehaviour
{
    public int numeroEscena;

    public void iniciar()
    {
        SceneManager.LoadScene(numeroEscena);
    }
}
