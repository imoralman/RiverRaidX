using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Coisao : MonoBehaviour
{

    private bool _invincible = false;
    [SerializeField] public float _tempoInvencivel;

    
    
    public GameObject _player; // Referência ao modelo visual
    private Renderer _renderer;

    private void Start()
    {
        //_fuel = _fuelMax;
        if (_player != null)
        {
            _renderer = _player.GetComponent<Renderer>();
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
            StartCoroutine(Blinking(_tempoInvencivel));

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