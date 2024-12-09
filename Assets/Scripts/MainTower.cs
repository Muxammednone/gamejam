using UnityEngine;

public class MainTower : MonoBehaviour
{
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Enemy>())
        {
            Destroy(other.gameObject);
            gameManager.hp -= 1;
        }
    }
}
