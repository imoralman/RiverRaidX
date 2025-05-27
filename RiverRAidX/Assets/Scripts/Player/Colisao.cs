using System.Collections;
using UnityEngine;


public class Coisao : MonoBehaviour
{
    public int _vidaMax = 5;
    private int _vidaAtual;
    private bool _invincible = false;
    public float _tempoInvencivel = 2f;

    public GameObject _model; // Referência ao modelo visual
    private Renderer _renderer;

    private void Start()
    {
        _vidaAtual = _vidaMax;
        if (_model != null)
        {
            _renderer = _model.GetComponent<Renderer>();
            if (_renderer == null)
            {
                Debug.LogError("Renderer não encontrado no _model.");
            }
        }
        else
        {
            Debug.LogError("O campo _model não está atribuído.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (_invincible) return;

        if (other.CompareTag("Inimigo"))
        {
            Debug.Log("Bateu");
            _vidaAtual--;

            if (_vidaAtual <= 0)
            {
                Debug.Log("Game Over");
                // Coloque lógica de game over aqui
            }
            else
            {
                StartCoroutine(Blinking(_tempoInvencivel));
            }
        }
    }

    IEnumerator Blinking(float duration)
    {
        if (_renderer == null) yield break;

        _invincible = true;
        float elapsed = 0f;
        float blinkInterval = 0.05f;

        while (elapsed < duration)
        {
            _renderer.enabled = !_renderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
            elapsed += blinkInterval;
        }

        _renderer.enabled = true;
        _invincible = false;
    }
}