using UnityEngine;

public class FuelManager : MonoBehaviour
{
    public float maxFuel = 100f;
    public float fuelConsumptionRate = 5f;
    public float currentFuel;
    public GameObject gameOverUI;

    void Start()
    {
        currentFuel = maxFuel;
    }

    void Update()
    {
        // Consumir combustível
        currentFuel -= fuelConsumptionRate * Time.deltaTime;

        if (currentFuel <= 0)
        {
            currentFuel = 0;
            GameOver();
        }
    }

    public void CollectFuel(float amount)
    {
        currentFuel += amount;
        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);
    }

    void GameOver()
    {
        Time.timeScale = 0; // Pausa o jogo
        gameOverUI.SetActive(true);
    }
}
