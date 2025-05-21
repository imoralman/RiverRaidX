using UnityEngine;

public class NaveController : MonoBehaviour
{
    public float speed = 15f;
    public float xBound = 13f;
    public float tiltAngle = 20f; // Ângulo máximo de inclinação
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation; // Salva a rotação inicial da nave
    }

    void Update()
    {
        // Movimento no eixo X
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + Vector3.right * horizontalInput * speed * Time.deltaTime;

        // Limitar o movimento
        newPosition.x = Mathf.Clamp(newPosition.x, -xBound, xBound);
        transform.position = newPosition;

        // Inclinação da nave
        float tilt = horizontalInput * -tiltAngle; // Inclinação negativa para corresponder ao movimento
        transform.localRotation = initialRotation * Quaternion.Euler(0, tilt, 0);
    }
}