using System.Net.Sockets;
using UnityEngine;

public class RoketSpawner : MonoBehaviour
{
    public GameObject rocketPrefab;  // Префаб ракеты
    public Transform spawnPoint;    // Точка спавна ракеты
    public float rocketSpeed = 10f; // Скорость ракеты

    public void SpawnRocket(Transform target)
    {
        if (rocketPrefab == null || target == null || spawnPoint == null)
        {
            Debug.LogWarning("Не указаны ракета, цель или точка спавна!");
            return;
        }

        // Спавним ракету
        GameObject rocket = Instantiate(rocketPrefab, spawnPoint.position, Quaternion.identity);
        Roket rocketScript = rocket.GetComponent<Roket>();
        if (rocketScript != null)
        {
            // Передаем цель и скорость ракеты
            rocketScript.SetTarget(target, rocketSpeed);
        }
    }
}
