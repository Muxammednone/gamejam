using UnityEngine;
using System.Collections;
[System.Serializable]
class WaveInfo
{
    public Enemy enemy1;  // Первый тип врага
    public int amount1;    // Количество первого типа врагов
    public Enemy enemy2;  // Второй тип врага (если есть)
    public int amount2;    // Количество второго типа врагов
}

public class EnemySpawner : MonoBehaviour
{
    bool flag = false;
    [SerializeField] private WaveInfo[] waveInfos; // Массив информации о волнах
    [SerializeField] private float timeBetweenWaves = 5f; // Время между волнами
    [SerializeField] private float spawnInterval = 0.5f; // Интервал между спавном врагов
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

            // Проверка, существует ли информация о текущей волне
            if (waveNumber - 1 < waveInfos.Length)
            {
                // Запускаем спавн врагов для текущей волны
                StartCoroutine(SpawnEnemies(waveInfos[waveNumber - 1]));
            }
            else
            {
                Debug.Log("No more waves!");
                yield break;  // Если волны закончились, выходим из корутины
            }
        }
    }

    private IEnumerator SpawnEnemies(WaveInfo waveInfo)
    {
        isSpawning = true;

        // Спавним врагов первого типа
        for (int i = 0; i < waveInfo.amount1; i++)
        {
            SpawnEnemy(waveInfo.enemy1);
            yield return new WaitForSeconds(spawnInterval);
        }

        // Спавним врагов второго типа (если есть)
        for (int i = 0; i < waveInfo.amount2; i++)
        {
            SpawnEnemy(waveInfo.enemy2);
            yield return new WaitForSeconds(spawnInterval);
        }

        isSpawning = false;
    }

    private void SpawnEnemy(Enemy enemy)
    {
        // Проверка на наличие точки спавна
        if (transform != null)
        {
            // Спавним врага на текущем объекте спавнера
            EnemyMovement enem = Instantiate(enemy.gameObject, transform.position, transform.rotation).GetComponent<EnemyMovement>();
            enem.pathIndex = index;
        }
        else
        {
            Debug.LogError("Spawn point is not assigned!");
        }
    }
}

