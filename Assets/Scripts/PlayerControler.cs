using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed = 20;
    [SerializeField] int rotationSpeed = 90;

    void Update()
    {
        // Получаем значения осей от клавиатуры
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Получаем значение оси от мыши
        float mouseHorizontal = Input.GetAxis("Mouse X");

        // Перемещаем объект вперед/назад и влево/вправо
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vertical);

        // Вращаем объект вокруг оси Y по горизонтальной оси клавиатуры
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontal);

        // Вращаем объект вокруг оси Y по горизонтальной оси мыши
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * mouseHorizontal);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, столкнулись ли мы с объектом с тегом "Ghost"
        if (other.gameObject.CompareTag("Ghost"))
        {
            // Если да, уничтожаем этот объект
            Destroy(other.gameObject);
        }
        // Проверяем, столкнулись ли мы с объектом с тегом "Finish"
        else if (other.gameObject.CompareTag("Finish"))
        {
            // Если да, выводим в консоль сообщение "Game Over"
            Debug.Log("Game Over");
        }
        // Проверяем, столкнулись ли мы с объектом с тегом "Win"
        else if (other.gameObject.CompareTag("Win"))
        {
            // Если да, выводим в консоль сообщение "Win Game"
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
        // Получаем значения осей от клавиатуры
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Получаем значение оси от мыши
        float mouseHorizontal = Input.GetAxis("Mouse X");

        // Перемещаем объект вперед/назад
        Vector3 movement = transform.forward * speed * Time.deltaTime * vertical;
        transform.Translate(movement, Space.World);

        // Вращаем объект вокруг оси Y по горизонтальной оси клавиатуры
        float rotation = rotationSpeed * Time.deltaTime * horizontal;
        transform.Rotate(Vector3.up, rotation);

        // Вращаем объект вокруг оси Y по горизонтальной оси мыши
        float mouseRotation = rotationSpeed * Time.deltaTime * mouseHorizontal;
        transform.Rotate(Vector3.up, mouseRotation);
    }
}
