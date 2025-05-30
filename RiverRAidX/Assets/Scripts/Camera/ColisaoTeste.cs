using System;
using UnityEngine;
using UnityEngine.UI;

public class ColisaoTeste : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colidiu com: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Inimigo"))
        {
            Debug.Log("Colidiu com o INIMIGO!");
        }
    }
}
