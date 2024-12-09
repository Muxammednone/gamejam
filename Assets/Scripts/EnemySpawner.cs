using UnityEngine;
using System.Collections;
[System.Serializable]
class WaveInfo
{
    public Enemy enemy1;  // ������ ��� �����
    public int amount1;    // ���������� ������� ���� ������
    public Enemy enemy2;  // ������ ��� ����� (���� ����)
    public int amount2;    // ���������� ������� ���� ������
}

public class EnemySpawner : MonoBehaviour
{
    bool flag = false;
    [SerializeField] private WaveInfo[] waveInfos; // ������ ���������� � ������
    [SerializeField] private float timeBetweenWaves = 5f; // ����� ����� �������
    [SerializeField] private float spawnInterval = 0.5f; // �������� ����� ������� ������
    [SerializeField] private GameManager gameManager;
    public int index;
    private bool isSpawning = false;
    private int waveNumber = 0;

    private void Update()
    {
        if (gameManager.isStarted && !flag) { 
            StartCoroutine(SpawnWaves()); 
            flag = true;
        }
    }

    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            waveNumber++;
            Debug.Log($"Wave {waveNumber} starting...");

            // ��������, ���������� �� ���������� � ������� �����
            if (waveNumber - 1 < waveInfos.Length)
            {
                // ��������� ����� ������ ��� ������� �����
                StartCoroutine(SpawnEnemies(waveInfos[waveNumber - 1]));
            }
            else
            {
                Debug.Log("No more waves!");
                yield break;  // ���� ����� �����������, ������� �� ��������
            }
        }
    }

    private IEnumerator SpawnEnemies(WaveInfo waveInfo)
    {
        isSpawning = true;

        // ������� ������ ������� ����
        for (int i = 0; i < waveInfo.amount1; i++)
        {
            SpawnEnemy(waveInfo.enemy1);
            yield return new WaitForSeconds(spawnInterval);
        }

        // ������� ������ ������� ���� (���� ����)
        for (int i = 0; i < waveInfo.amount2; i++)
        {
            SpawnEnemy(waveInfo.enemy2);
            yield return new WaitForSeconds(spawnInterval);
        }

        isSpawning = false;
    }

    private void SpawnEnemy(Enemy enemy)
    {
        // �������� �� ������� ����� ������
        if (transform != null)
        {
            // ������� ����� �� ������� ������� ��������
            EnemyMovement enem = Instantiate(enemy.gameObject, transform.position, transform.rotation).GetComponent<EnemyMovement>();
            enem.pathIndex = index;
        }
        else
        {
            Debug.LogError("Spawn point is not assigned!");
        }
    }
}

