using UnityEngine;

public class Roket : MonoBehaviour
{
    private Transform target;       // Цель ракеты
    private float speed;            // Скорость движения
    public float hitDistance = 0.5f; // Расстояние, на котором ракета поражает цель

    public void SetTarget(Transform target, float speed)
    {
        this.target = target;
        this.speed = speed;
    }

    void Update()
    {
        if (target == null)
        {
            // Если цель исчезла, уничтожаем ракету
            Destroy(gameObject);
            return;
        }

        // Двигаем ракету к цели
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Вращаем ракету по направлению движения
        transform.rotation = Quaternion.LookRotation(direction);

        // Проверяем расстояние до цели
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
        Debug.Log("Цель поражена!");
        Destroy(gameObject); // Уничтожаем ракету
    }
}
