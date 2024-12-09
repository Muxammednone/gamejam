using System.Net.Sockets;
using UnityEngine;

public class RoketSpawner : MonoBehaviour
{
    public GameObject rocketPrefab;  // ������ ������
    public Transform spawnPoint;    // ����� ������ ������
    public float rocketSpeed = 10f; // �������� ������

    public void SpawnRocket(Transform target)
    {
        if (rocketPrefab == null || target == null || spawnPoint == null)
        {
            Debug.LogWarning("�� ������� ������, ���� ��� ����� ������!");
            return;
        }

        // ������� ������
        GameObject rocket = Instantiate(rocketPrefab, spawnPoint.position, Quaternion.identity);
        Roket rocketScript = rocket.GetComponent<Roket>();
        if (rocketScript != null)
        {
            // �������� ���� � �������� ������
            rocketScript.SetTarget(target, rocketSpeed);
        }
    }
}
