using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject _inimigo;
    public float _tempoSpawn;
    public Transform[] _pontoSpawn;

    void Start()
    {
        InvokeRepeating("StartSpawn", _tempoSpawn, _tempoSpawn);
    }

    void StartSpawn()
    {
        int _pontoSpawnIndex = Random.Range(0, _pontoSpawn.Length);
        Instantiate(_inimigo, _pontoSpawn[_pontoSpawnIndex].position, _pontoSpawn[_pontoSpawnIndex].rotation);
    }

    
    
        void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            transform.position = new Vector3(0,0, transform.position.z + 83.48f * 2);
            //Debug.Log("colidiu com"+"  "+ this);
            StartSpawn();
        }
        
    }
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        

    // Update is called once per frame
    void Update()
    {
        
    }
}
