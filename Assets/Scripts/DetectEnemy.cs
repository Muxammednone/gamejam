using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    private List<Enemy> collidersInside = new List<Enemy>();

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.GetComponentInParent<Enemy>())
        {
            Enemy enemy = other.gameObject.GetComponentInParent<Enemy>();
            if (!collidersInside.Contains(enemy)) // Избегаем дубликатов
            {
                collidersInside.Add(enemy);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Enemy>())
        {
            Enemy enemy = other.gameObject.GetComponentInParent<Enemy>();
            if (collidersInside.Contains(enemy)) // Избегаем дубликатов
            {
                collidersInside.Remove(enemy);
            }
        }
    }

    private void Update()
    {
        Debug.Log($"Коллайдеров внутри триггера: {collidersInside.Count}");
    }

    public List<Enemy> GetCollidersInside()
    {
        return collidersInside;
    }
}
