using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public float speed = 10;
    public float xBound = 10f;

    private bool turbo = true;
    public float turboForca;
    private float turboTempo = 0.5f;
    private float turboCooldown = 1f;

    [SerializeField] private TrailRenderer tr;

    private void Start()
    {

        rb.GetComponent<Rigidbody>();
        tr.emitting = true;

    }


    void Update()
    {

        // Movimento no eixo X
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + Vector3.right * horizontalInput * speed * Time.deltaTime;

        // Limitar o movimento
        newPosition.x = Mathf.Clamp(newPosition.x, -xBound, xBound);
        transform.position = newPosition;

        if (Input.GetKeyDown(KeyCode.Space) && turbo)
        {
            StartCoroutine(Turbo());
        }


    }

    private void FixedUpdate()
    {

        rb.linearVelocity = Vector3.forward * speed;
    }

    private IEnumerator Turbo()
    {
        turbo = true;
        tr.emitting = true;

        speed = turboForca;
        yield return new WaitForSeconds(turboTempo);
        speed = 10f;
        yield return new WaitForSeconds(turboCooldown);
        turbo = true;
    }

}