using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public string enemyTag = "Ghost";

    void Update()
    {
        // ������� ������ ������
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // ��������� ������� ����
        if (other.gameObject.CompareTag(enemyTag))
        {
            // ���������� ������, � ������� �����������
            Destroy(other.gameObject);
            // ���������� ������, � �������� �������� ������
            Destroy(gameObject);
        }
    }
}
