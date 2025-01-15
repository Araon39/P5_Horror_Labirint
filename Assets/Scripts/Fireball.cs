using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public string enemyTag = "Ghost";

    void Update()
    {
        // Двигаем объект вперед
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем наличие тега
        if (other.gameObject.CompareTag(enemyTag))
        {
            // Уничтожаем объект, с которым столкнулись
            Destroy(other.gameObject);
            // Уничтожаем объект, к которому привязан скрипт
            Destroy(gameObject);
        }
    }
}
