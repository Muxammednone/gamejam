using System;
using Unity.VisualScripting;
using UnityEngine;

public class SetupManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    public int setuppingIndex;
    private bool _canSetup;
    
    private void Setup(Vector3 point, int setup_index)
    {

    }
    private void makeVisual()
    {

    }
    void Start()
    {
        
    }

    
    private void Update()
    {
        if (_gameManager.isSetupping)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Проверяем, есть ли у объекта родитель
                Transform parentTransform = hit.collider.transform.parent;

                if (parentTransform != null && parentTransform.tag == "tile")
                {
                    Debug.Log("Попали в объект с родителем, тег которого 'tile'.");
                    // Ваш код обработки попадания в тайл
                }
                else
                {
                    Debug.Log("Попали, но родитель не найден или тег не совпадает.");
                }
            }
            else
            {
                Debug.Log("Луч никуда не попал.");
            }
        }
    }
}
