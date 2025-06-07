using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _velocidadeTiro = 30f;
    //public float _speedTiro;
    public float _tempoVidaTiro = 2f;

    private float _tempo;

    void OnEnable()
    {
        _tempo = _tempoVidaTiro;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * _velocidadeTiro * Time.deltaTime);

        _tempo -= Time.deltaTime;
        if (_tempo <= 0f)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Você pode verificar colisão com inimigos aqui
        if (other.CompareTag("Enemy"))
        {
            // Adicione dano, efeitos, etc.
            gameObject.SetActive(false);
        }
    }
}
