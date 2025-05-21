using UnityEngine;

public class FuelPickup : MonoBehaviour
{
    public float fuelAmount = 20f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<FuelManager>().CollectFuel(fuelAmount);
            Destroy(gameObject);
            Debug.Log("fuelAmount");
        }
    }
}
