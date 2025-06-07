using UnityEngine;

public class MinibossController : MonoBehaviour
{
    [Header("Distância do jogador no eixo Z")]
    public float _distanciaDoPlayer = 20f;

    [Header("Movimento lateral")]
    public float xMoveRange = 10f;
    public float xMoveSpeed = 5f;

    [Header("Ataque")]
    public float attackInterval = 3f;
    public float attackDuration = 1.5f;

    private Transform player;
    private Vector3 initialLocalPosition;
    private float attackCooldown = 0f;
    private bool attacking = false;
    private int direction = 1;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        initialLocalPosition = transform.localPosition;
        attackCooldown = Random.Range(0f, attackInterval); // Para desincronizar
    }

    void Update()
    {
        if (player == null) return;

        FollowPlayerZ();

        if (!attacking)
        {
            MoveSideToSide();
            attackCooldown -= Time.deltaTime;

            if (attackCooldown <= 0f)
            {
                StartCoroutine(Attack());
            }
        }

        LookAtPlayer();
    }

    void FollowPlayerZ()
    {
        // Segue o jogador mantendo distância no Z, mas não altera X/Y
        Vector3 pos = transform.position;
        pos.z = player.position.z + _distanciaDoPlayer;
        transform.position = pos;
    }

    void MoveSideToSide()
    {
        Vector3 newPos = transform.position;
        newPos.x += direction * xMoveSpeed * Time.deltaTime;

        if (Mathf.Abs(newPos.x - initialLocalPosition.x) > xMoveRange)
        {
            direction *= -1;
        }

        transform.position = newPos;
    }

    void LookAtPlayer()
    {
        Vector3 lookDir = (player.position - transform.position).normalized;
        lookDir.y = 0f; // opcional: trava rotação no Y
        Quaternion targetRotation = Quaternion.LookRotation(-lookDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 20f);
    }

    System.Collections.IEnumerator Attack()
    {
        attacking = true;

        // Ativaria tiros aqui
        Debug.Log($"{gameObject.name} atacando!");

        yield return new WaitForSeconds(attackDuration);

        attacking = false;
        attackCooldown = attackInterval;
    }

    public void Die()
    {
        Debug.Log($"{gameObject.name} morreu!");
        gameObject.SetActive(false);
        MinibossSpawner.Instance.NotifyMinibossDeath();
    }

    void OnEnable()
    {
        attacking = false;
        attackCooldown = Random.Range(0f, attackInterval);
        direction = 1;
        initialLocalPosition = transform.localPosition;
    }
}
