using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float dragSpeed = 5.0f;          // �������� ����������� ������ ������
    public float scrollSpeed = 10.0f;      // �������� ��������������� ������
    public Vector2 xLimits = new Vector2(-50, 50); // ����������� �� X
    public Vector2 zLimits = new Vector2(-50, 50); // ����������� �� Z
    public float minZoom = 10.0f;          // ����������� ������ ������
    public float maxZoom = 50.0f;          // ������������ ������ ������

    private Vector3 dragOrigin;            // ��������� ����� �����
    private bool isDragging = false;

    void Update()
    {
        HandleDrag();
        //HandleScroll();
    }

    private void HandleDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 difference = dragOrigin - currentMousePosition; // ������� ������� ��� �����

            // ��������� ������� � ������� ���������� (X � Z ������������� �������� ���������)
            Vector3 move = new Vector3(-difference.y, 0, difference.x) * dragSpeed * Time.deltaTime;
            transform.Translate(move, Space.World);

            // ��������� ��������� ����� ��� ���������� �����
            dragOrigin = currentMousePosition;

            // ������������ �������� ������ � �������� ������
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, xLimits.x, xLimits.y);
            clampedPosition.z = Mathf.Clamp(clampedPosition.z, zLimits.x, zLimits.y);
            transform.position = clampedPosition;
        }
    }

    private void HandleScroll()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            Vector3 position = transform.position;
            position.y -= scroll * scrollSpeed;
            position.y = Mathf.Clamp(position.y, minZoom, maxZoom); // ������������ ������ ������
            transform.position = position;
        }
    }
}
