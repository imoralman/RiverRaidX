using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Dano : MonoBehaviour
{

    public int _vidaMax;
    private int _vidaAtual;
    private bool _invincible = false;
    public float _tempoInvencivel;

    public GameObject _model;


    private void Start()
    {
        _vidaAtual = _vidaMax;

    }


    void OnTriggerEnter(Collider other)
    {
  
        
        if (_invincible)
        {
            return;
        }

        if (other.CompareTag("Inimigo"))
        {
            //    _vidaAtual--;
            //fazer aniamcao para aviao tremer
            //fazer script para tremer tela
            Debug.Log("Bateu");

                if (_vidaAtual <= 0)
                {
                    _vidaAtual--;
                    StartCoroutine(Blinking(_tempoInvencivel));

                    //game over
                }
                else
                {


                } 

        }
    }
    IEnumerator Blinking(float _time)
    {
        _invincible = true;
        float _timer = 0;
        float _currentBlink = 1f;
        float _lastBlink = 0f;
        float _blinkPeriod = 0.1f;
        bool _enable = false;

        yield return new WaitForSeconds(1.5f);



        while (_timer < _time && _invincible)
        {
            _model.SetActive(_enable);
            yield return null;
            _timer += Time.deltaTime;
            _lastBlink += Time.deltaTime;

            if (_blinkPeriod < _lastBlink)
            {
                _lastBlink = 0;
                _currentBlink = 1f - _currentBlink;
                _enable = !_enable;
                Debug.Log("era pra piscar");
            }


        }
        _model.SetActive(true);
        _invincible = false;


    }



}


