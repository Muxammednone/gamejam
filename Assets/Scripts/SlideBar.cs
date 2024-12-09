using UnityEngine;

public class SlideBar : MonoBehaviour
{
    public Transform panelTransform; // ��������� ������
    public Vector3 hiddenPosition;   // ������� ������ ����� (������)
    public Vector3 visiblePosition;  // ������� ������ ������� (������)
    public float animationSpeed = 5f; // �������� ����������/����������

    private bool isPanelVisible = false; // ������� ������ ������

    void Update()
    {
        // ������� �������� ������ � ������ �������
        Vector3 targetPosition = isPanelVisible ? visiblePosition : hiddenPosition;
        panelTransform.localPosition = Vector3.Lerp(panelTransform.localPosition, targetPosition, Time.deltaTime * animationSpeed);
    }

    public void TogglePanel()
    {
        
        isPanelVisible = !isPanelVisible;
    }

}
