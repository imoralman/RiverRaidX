using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public float _fuel;
    public float _fuelMax = 100f;
    public float _fuelMin = 0f;

    public GameObject _player;

    public Slider _fuelBar;

    void Start()
    {
        _fuel = _fuelMax;
    }

    private void FixedUpdate()
    {
        _fuel -= 0.05f;
        _fuelBar.value = _fuel;

    }

    void OnTriggerEnter(Collider other)
        {
            
            if (_player.CompareTag("Inimigo"))
            {
                Debug.Log("Bateu");
                _fuel = _fuel - 5f;

                if (_fuel <= _fuelMin)
                {
                    Debug.Log("Game Over");
                    // Coloque lógica de game over aqui
                }
            
            }
        }
}
