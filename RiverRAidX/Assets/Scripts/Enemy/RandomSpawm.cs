using System.Collections.Generic;
using UnityEngine;

public class RandomSpawm : MonoBehaviour
{

    public GameObject[] _inimigos;
    public List<GameObject> novoInimigo;
    public Vector2 quantidadeInimigos;

    private void Start()
    {

        int novoNumeroDeInimigos = (int)Random.Range(quantidadeInimigos.x, quantidadeInimigos.y);

        //instancia os inimigos aleatoriamente
        for (int i = 0; i < novoNumeroDeInimigos; i++)
        {
            novoInimigo.Add(Instantiate(_inimigos[Random.Range(0, _inimigos.Length)], transform));
            novoInimigo[i].SetActive(false);
        }

        PosicionaInimigo();
    }

    void PosicionaInimigo()
    {
            for(int i = 0; i < novoInimigo.Count; i++) {
            //tem que saber qual o tamanho do "terreno" para poder posicionar o inimigos
            float posZMinima = (10f / novoInimigo.Count) + (80 / novoInimigo.Count) * i;
            float posZMaxima = (10f / novoInimigo.Count) + (80 / novoInimigo.Count) * i + 1;

            //float posXMinima = (-14f / novoInimigo.Count) + (13f / novoInimigo.Count) * i;
            //float posXmaxima = (-14f / novoInimigo.Count) + (13f / novoInimigo.Count) * i + 1;

            novoInimigo[i].transform.localPosition = new Vector3(Random.Range(-14f, 13f),0, Random.Range(posZMinima, posZMaxima));
            novoInimigo[i].SetActive(true);
        }


        /*        
                int _randomIndex = Random.Range(3, _inimigos.Length);
                Vector3 _spawmAleatorio = new Vector3(Random.Range(-14, 12), 0, Random.Range(10, 80));

                Instantiate(_inimigos[_randomIndex], _spawmAleatorio, Quaternion.identity);
        */
    }


    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            transform.position = new Vector3(0,0, transform.position.z + 83.48f * 2);
            //Debug.Log("colidiu com"+"  "+ this);
            PosicionaInimigo();
        }
        
    }
    
        
    

}
