using UnityEngine;
using System.Collections;
using System.Linq;
public class EnemyMovement : MonoBehaviour
{
    private Transform[] pathPoints;  // Массив точек пути
    public int pathIndex = 0;
    [SerializeField] private Path _path;
    private float speed;
    private int currentPointIndex = 0;  // Индекс текущей точки пути
    private void Start()
    {
        GameObject path = _path.paths[pathIndex];
        Transform[] points = path.GetComponentsInChildren<Transform>();
        pathPoints = points.Where(t => t != path.transform).ToArray();
    }
    void Update()
    {
        
        speed = GetComponent<Enemy>().speed;
        if (pathPoints == null)
        {
            Debug.LogError("Path points are not properly initialized!");
            return;
        }

        // Получаем текущую точку пути
        Transform targetPoint = pathPoints[currentPointIndex];

        // Двигаем врага к текущей точке
        MoveTowardsPoint(targetPoint);

        // Проверка, достиг ли враг текущей точки
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            // Переход к следующей точке
            currentPointIndex++;

            // Если достигли последней точки, начинаем путь заново
            if (currentPointIndex >= pathPoints.Length)
            {
                currentPointIndex = 0;
            }
        }
    }

    void MoveTowardsPoint(Transform targetPoint)
    {
        // Двигаем врага к следующей точке
        Vector3 direction = (targetPoint.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Поворот врага в сторону следующей точки
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
