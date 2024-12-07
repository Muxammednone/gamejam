using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class RoketTower : Tower
{
    [SerializeField] private float exploadRadius;
    [SerializeField] private LayerMask enemyLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    public override void shootEnemy(Enemy enemy)
    {
        //base.shootEnemy(enemy);
        List<Enemy> enemy_list = getExploadedEnemies(enemy);
        foreach (Enemy enem in enemy_list)
        {
            enem.GetDamage(damage);
        }
    }
    private List<Enemy> getExploadedEnemies(Enemy enemy)
    {
        Collider[] colliders = Physics.OverlapSphere(enemy.transform.position, exploadRadius, enemyLayer);
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
