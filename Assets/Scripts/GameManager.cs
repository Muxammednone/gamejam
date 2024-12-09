using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isStarted;
    public bool isSetupping = false;
    public int iron;
    public int poison;
    public int hp = 10;

    void Start()
    {
        
    }

    
    void Update()
    {
        Debug.Log(iron);
        Debug.Log(poison);
    }
}
