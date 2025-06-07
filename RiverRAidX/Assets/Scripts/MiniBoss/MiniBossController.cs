using UnityEngine;

public class MinibossController : MonoBehaviour
{
    [Header("Distância do Jogador")]
    public float _distanciaDoPlayer = 20f;
    public float approachSpeed = 10f;

    [Header("Movimento lateral")]
    public float _movimentoEmX = 10f;
    public float _velocidadeEmX = 5f;

    [Header("Ataque")]
    public float _attackInterval = 3f;
    public float _duracaoDoAtaque = 1.5f;

    private Transform player;
    private Vector3 _posicaoInicial;
    private bool _atacando = false;
    private float _tempoDeAtaque = 0f;
    private float _esperaParaAtacar;

    private int _direcao = 1;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _posicaoInicial = transform.position;
        _esperaParaAtacar = Random.Range(0, _attackInterval); // Desincronizar ataques
    }

    void Update()
    {
        if (player == null) return;

        MaintainDistanceFromPlayer();

        if (!_atacando)
        {
            MoveSideToSide();
            _esperaParaAtacar -= Time.deltaTime;

            if (_esperaParaAtacar <= 0f)
            {
                StartCoroutine(Attack());
            }
        }
    }

    void MaintainDistanceFromPlayer()
    {
        float currentDistance = Vector3.Distance(transform.position, player.position);
        Vector3 _direcao = (transform.position - player.position).normalized;

        if (Mathf.Abs(currentDistance - _distanciaDoPlayer) > 1f)
        {
            transform.position -= _direcao * approachSpeed * Time.deltaTime;
        }

        // Olhar para o player
        Vector3 lookDir = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(lookDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void MoveSideToSide()
    {
        Vector3 newPos = transform.position;
        newPos.x += _direcao * _velocidadeEmX * Time.deltaTime;

        if (Mathf.Abs(newPos.x - _posicaoInicial.x) > _movimentoEmX)
        {
            _direcao *= -1;
        }

        transform.position = newPos;
    }

    System.Collections.IEnumerator Attack()
    {
        _atacando = true;
        Debug.Log($"{gameObject.name} está atacando!");
        // Aqui você pode ativar tiros, lasers, etc.

        yield return new WaitForSeconds(_duracaoDoAtaque);

        _atacando = false;
        _esperaParaAtacar = _attackInterval;
    }

    public void Die()
    {
        Debug.Log($"{gameObject.name} morreu!");
        gameObject.SetActive(false);
        MinibossSpawner.Instance.NotifyMinibossDeath();
    }
}
