using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int damage;
    public int price;
    public float hitTime;
    public Transform mainTowerTransform;
    private Enemy targetEnemy;
    private float timer;

    private List<Enemy> enemyList = new List<Enemy>();
    public void detectEnemy()
    {
        Enemy enemy = FindClosestEnemy(enemyList, mainTowerTransform.position);
        if (enemy!=null)
        {
            shootEnemy(enemy);
        }
    }
    public virtual void shootEnemy(Enemy enemy)
    {
        enemy.GetDamage(damage);
    }
    Enemy FindClosestEnemy(List<Enemy> objects, Vector3 point)
    {
        Enemy closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (Enemy obj in objects)
        {
            if (obj == null) continue; // Пропускаем null-объекты

            float distance = Vector3.Distance(obj.GetComponent<Transform>().position, point);
            if (distance < closestDistance)
            {
                closest = obj;
                closestDistance = distance;
            }
        }

        return closest;
    }
    void Update()
    {
        enemyList = GetComponentInChildren<DetectEnemy>().GetCollidersInside();
        timer += Time.deltaTime;
        if (timer > hitTime) {
            timer = 0;
            detectEnemy();
        }
    }
}
