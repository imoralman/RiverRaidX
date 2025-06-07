using UnityEngine;

public class TiroInimigo : MonoBehaviour
{
    [Header("Tiro")]
    public float _distanciaTiro;
    public float _tiroCooldown;

    private float _tempoEntreDisparo = 0f; 
    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        // Inicia com tempo aleatório para evitar tiros sincronizados
        _tempoEntreDisparo = Random.Range(0f, _tiroCooldown);
    }

    void Update()
    {
        if (player == null) return;

        _tempoEntreDisparo -= Time.deltaTime;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= _distanciaTiro && _tempoEntreDisparo <= 0f)
        {
            ShootAtPlayer();
            _tempoEntreDisparo = _tiroCooldown;
        }
    }

    void ShootAtPlayer()
    {
        // Substitua pela lógica de disparo com projétil
        Debug.Log($"{gameObject.name} atirou no jogador!");
    }
}
