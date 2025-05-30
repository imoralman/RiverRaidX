using UnityEngine;
using UnityEngine.UI;

public class _FuelController : MonoBehaviour
{
    public float _fuelMax = 100f;
    public float _fuelMin = 0f;
    public float _fuel;
    public float _dano = 15f;
    public Slider _fuelBar;

    // Suavização
    private float _displayedFuel = 0f;
    public float _suavizarDano = 5f; // maior = mais rápido

    void Start()
    {
        _fuel = _fuelMax;
        _displayedFuel = _fuelMax;

        _fuelBar.maxValue = _fuelMax;
        _fuelBar.minValue = _fuelMin;
        _fuelBar.value = _displayedFuel;
    }

    void Update()
    {
        // Consome combustível com o tempo
        _fuel -= 0.03f;
        _fuel = Mathf.Clamp(_fuel, _fuelMin, _fuelMax);

        // Suaviza a barra de combustível
        _displayedFuel = Mathf.Lerp(_displayedFuel, _fuel, Time.deltaTime * _suavizarDano);
        _fuelBar.value = _displayedFuel;

        // Quando acabar o combustível real, desativa o player
        if (_fuel <= _fuelMin)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            _TomarDano();
            Debug.Log("Colidiu com inimigo via TRIGGER.");
        }
    }

    void _TomarDano()
    {
        _fuel -= _dano;
        _fuel = Mathf.Clamp(_fuel,_fuelMin , _fuelMax);
        // _fuelBar.value será atualizado suavemente via Update()
    }
}