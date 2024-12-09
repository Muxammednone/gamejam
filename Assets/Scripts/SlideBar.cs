using UnityEngine;

public class SlideBar : MonoBehaviour
{
    public Transform panelTransform; // Трансформ панели
    public Vector3 hiddenPosition;   // Позиция панели внизу (скрыта)
    public Vector3 visiblePosition;  // Позиция панели наверху (видима)
    public float animationSpeed = 5f; // Скорость выдвижения/задвижения

    private bool isPanelVisible = false; // Текущий статус панели

    void Update()
    {
        // Плавное движение панели к нужной позиции
        Vector3 targetPosition = isPanelVisible ? visiblePosition : hiddenPosition;
        panelTransform.localPosition = Vector3.Lerp(panelTransform.localPosition, targetPosition, Time.deltaTime * animationSpeed);
    }

    public void TogglePanel()
    {
        
        isPanelVisible = !isPanelVisible;
    }

}
