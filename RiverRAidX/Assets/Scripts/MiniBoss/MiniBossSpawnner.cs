using UnityEngine;

public class MinibossSpawner : MonoBehaviour
{
    [Header("Miniboss Prefabs (variações)")]
    public GameObject[] _miniBossPrefab;

    [Header("Área de Spawn")]
    public Transform _pontoSpawn;

    [Header("Tempo de Respawn")]
    public float _atrasoRespawnMin = 5f;
    public float _atrasoRespawnMax = 15f;

    public static MinibossSpawner Instance { get; private set; }

    private GameObject _miniBossAtual;
    private bool _esperaRespawn = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        SpawnNewMiniboss();
    }

    void SpawnNewMiniboss()
    {
        int index = Random.Range(0, _miniBossPrefab.Length);
        _miniBossAtual = Instantiate(_miniBossPrefab[index], _pontoSpawn.position, Quaternion.identity);
    }

    public void NotifyMinibossDeath()
    {
        if (!_esperaRespawn)
        {
            _esperaRespawn = true;
            float delay = Random.Range(_atrasoRespawnMin, _atrasoRespawnMax);
            Invoke(nameof(SpawnNewMinibossAfterDelay), delay);
        }
    }

    void SpawnNewMinibossAfterDelay()
    {
        SpawnNewMiniboss();
        _esperaRespawn = false;
    }
}
