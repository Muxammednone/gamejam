using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
public class SlowTower : Tower
{
    public float normalSpeed = 5.0f;       
    public float slowedSpeed = 2.0f;     
    public float slowDuration;
    [SerializeField] private float slowRadius;
    [SerializeField] private LayerMask enemyLayer;
    public override void shootEnemy(Enemy enemy)
    {
        GetComponentInChildren<RoketSpawner>().SpawnRocket(enemy.transform);
        base.shootEnemy(enemy);
        SlowDown(slowDuration, enemy);
    }
    public void SlowDown(float duration, Enemy enemy)
    {
        if (!enemy.isSlowed) // ѕровер€ем, не наложено ли замедление уже
        {
            List<Enemy> enemies = getExploadedEnemies(enemy);
            foreach (Enemy enem in enemies)
            {
                StartCoroutine(SlowdownCoroutine(duration, enemy));
            }
            
        }
    }

    private IEnumerator SlowdownCoroutine(float duration, Enemy enemy)
    {
        enemy.isSlowed = true;
        enemy.speed = slowedSpeed;       

        yield return new WaitForSeconds(duration);

        enemy.speed = normalSpeed;     
        enemy.isSlowed = false;
    }
    private List<Enemy> getExploadedEnemies(Enemy enemy)
    {
        Collider[] colliders = Physics.OverlapSphere(enemy.transform.position, slowRadius, enemyLayer);
        List<Enemy> enemies = new List<Enemy>();
        foreach (Collider col in colliders)
        {
            if (col.GetComponentInParent<Enemy>())
            {
                enemies.Add(col.GetComponentInParent<Enemy>());
            }
        }
        return enemies;
    }
    
}
