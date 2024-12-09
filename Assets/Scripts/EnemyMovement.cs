using UnityEngine;
using System.Collections;
using System.Linq;
public class EnemyMovement : MonoBehaviour
{
    private Transform[] pathPoints;  // ������ ����� ����
    public int pathIndex = 0;
    [SerializeField] private Path _path;
    private float speed;
    private int currentPointIndex = 0;  // ������ ������� ����� ����
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

        // �������� ������� ����� ����
        Transform targetPoint = pathPoints[currentPointIndex];

        // ������� ����� � ������� �����
        MoveTowardsPoint(targetPoint);

        // ��������, ������ �� ���� ������� �����
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            // ������� � ��������� �����
            currentPointIndex++;

            // ���� �������� ��������� �����, �������� ���� ������
            if (currentPointIndex >= pathPoints.Length)
            {
                currentPointIndex = 0;
            }
        }
    }

    void MoveTowardsPoint(Transform targetPoint)
    {
        // ������� ����� � ��������� �����
        Vector3 direction = (targetPoint.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // ������� ����� � ������� ��������� �����
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
