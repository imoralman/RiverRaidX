using UnityEngine;

public class Kamikaze : MonoBehaviour
{
    [Header("Detecção")]
    public float detectionRadius;

    [Header("Movimento")]
    public float chargeSpeed;

    [Header("Explosão")]
    public bool destroyOnHit = true;

    private Transform player;
    private bool charging = false;

    void Start()
    {
        gameObject.SetActive(true);
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);



        if (!charging && distance <= detectionRadius)
        {
            charging = true;
        }

        if (charging)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            // Faz o inimigo olhar para o jogador suavemente
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

            // Move em frente, na direção que está olhando
            transform.position += transform.forward * chargeSpeed * Time.deltaTime;
        }
        /*
        if (charging)
{
    Vector3 direction = (player.position - transform.position).normalized;
    transform.position += direction * chargeSpeed * Time.deltaTime;
}*/

    }

    void OnTriggerEnter(Collider other)
    {
        if (charging && other.CompareTag("Player"))
        {
            Debug.Log("Kamikaze atingiu o jogador!");

            // Aqui você pode causar dano ao jogador

            gameObject.SetActive(false);

        }

        void OnDrawGizmosSelected()
        {
            // Gizmo da área de detecção
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
    void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy)
        {
            Debug.Log($"{gameObject.name} saiu da tela e foi desativado.");
            gameObject.SetActive(false);
        }
    }

}
