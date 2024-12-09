using UnityEngine;

public class Lunohod : MonoBehaviour
{
    public float givingTimer;
    public int poison;
    public int iron;
    private float timer = 0f;
    private GameManager manager;
    private void Start()
    {
        manager = FindFirstObjectByType<GameManager>();
    }
    private void Update()
    {
        if (!manager.isStarted) return;
        timer += Time.deltaTime;
        if (timer > givingTimer)
        {
            GetResourses();
            timer = 0f;
        }
    }


    private void GetResourses()
    {
        manager.poison += poison;
        manager.iron += iron;

    }
}
