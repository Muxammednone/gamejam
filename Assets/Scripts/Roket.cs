using UnityEngine;

public class Roket : MonoBehaviour
{
    private Transform target;       // ���� ������
    private float speed;            // �������� ��������
    public float hitDistance = 0.5f; // ����������, �� ������� ������ �������� ����

    public void SetTarget(Transform target, float speed)
    {
        this.target = target;
        this.speed = speed;
    }

    void Update()
    {
        if (target == null)
        {
            // ���� ���� �������, ���������� ������
            Destroy(gameObject);
            return;
        }

        // ������� ������ � ����
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // ������� ������ �� ����������� ��������
        transform.rotation = Quaternion.LookRotation(direction);

        // ��������� ���������� �� ����
        if (Vector3.Distance(transform.position, target.position) <= hitDistance)
        {
            HitTarget();
            if (target.GetComponent<Enemy>() && target.GetComponent<Enemy>().dead)
            {
                Destroy(target.GetComponent<Enemy>().gameObject);
            }
        }
    }

    private void HitTarget()
    {
        Debug.Log("���� ��������!");
        Destroy(gameObject); // ���������� ������
    }
}
