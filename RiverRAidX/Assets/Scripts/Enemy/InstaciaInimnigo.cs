using System.Collections.Generic;
using UnityEngine;

public class InstaciaInimnigo : MonoBehaviour
{
   
    public GameObject[] inimigos;
    public Vector2 quantidadeInimigos;

    public List<GameObject> novoInimigo;


    void Start(){

        //determina a quantidade de inimigos
        int novoNumeroDeInimigos = (int)Random.Range(quantidadeInimigos.x, quantidadeInimigos.y);
        
        //instancia os inimigos aleatoriamente
        for(int i = 0; i < novoNumeroDeInimigos; i++) {
            novoInimigo.Add(Instantiate(inimigos[Random.Range(0, inimigos.Length)], transform));
            novoInimigo[i].SetActive(false);
        }

        PosicionaInimigo();

    }

    void PosicionaInimigo(){

        for(int i = 0; i < novoInimigo.Count; i++) {
            //tem que saber qual o tamanho do "terreno" para poder posicionar o inimigos
            float posZMinima = (83.48f / novoInimigo.Count) + (125 / novoInimigo.Count) * i;
            float posZMaxima = (83.48f / novoInimigo.Count) + (125 / novoInimigo.Count) * i + 1;
            novoInimigo[i].transform.localPosition = new Vector3(0,0, Random.Range(posZMinima, posZMaxima));
            novoInimigo[i].SetActive(true);
        }

    }


    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            transform.position = new Vector3(0,0, transform.position.z + 83.48f *2);
            Debug.Log("colidiu com"+"  "+ this);
            PosicionaInimigo();
        }
        
    }
}
