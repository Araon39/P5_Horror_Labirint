using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed = 20;
    [SerializeField] int rotationSpeed = 90;

    void Update()
    {
        // �������� �������� ���� �� ����������
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // �������� �������� ��� �� ����
        float mouseHorizontal = Input.GetAxis("Mouse X");

        // ���������� ������ ������/����� � �����/������
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vertical);

        // ������� ������ ������ ��� Y �� �������������� ��� ����������
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontal);

        // ������� ������ ������ ��� Y �� �������������� ��� ����
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * mouseHorizontal);
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���������, ����������� �� �� � �������� � ����� "Ghost"
        if (other.gameObject.CompareTag("Ghost"))
        {
            // ���� ��, ���������� ���� ������
            Destroy(other.gameObject);
        }
        // ���������, ����������� �� �� � �������� � ����� "Finish"
        else if (other.gameObject.CompareTag("Finish"))
        {
            // ���� ��, ������� � ������� ��������� "Game Over"
            Debug.Log("Game Over");
        }
        // ���������, ����������� �� �� � �������� � ����� "Win"
        else if (other.gameObject.CompareTag("Win"))
        {
            // ���� ��, ������� � ������� ��������� "Win Game"
            Debug.Log("Win Game");
        }
    }

}

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float rotationSpeed = 90f;

    void Update()
    {
        // �������� �������� ���� �� ����������
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // �������� �������� ��� �� ����
        float mouseHorizontal = Input.GetAxis("Mouse X");

        // ���������� ������ ������/�����
        Vector3 movement = transform.forward * speed * Time.deltaTime * vertical;
        transform.Translate(movement, Space.World);

        // ������� ������ ������ ��� Y �� �������������� ��� ����������
        float rotation = rotationSpeed * Time.deltaTime * horizontal;
        transform.Rotate(Vector3.up, rotation);

        // ������� ������ ������ ��� Y �� �������������� ��� ����
        float mouseRotation = rotationSpeed * Time.deltaTime * mouseHorizontal;
        transform.Rotate(Vector3.up, mouseRotation);
    }
}
