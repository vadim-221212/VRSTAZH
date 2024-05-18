using UnityEngine;
using System.Collections;

public class DeviceRotate : MonoBehaviour
{
    public Transform table; // Ссылка на стол, в сторону которого должен повернуться прибор
    public float rotationSpeed = 95f; // Скорость поворота в градусах в секунду
    private CartStop cartStop; // Ссылка на скрипт CartStop

    void Start()
    {
        cartStop = FindObjectOfType<CartStop>(); // Находим скрипт CartStop на сцене
    }

    public void StartRotation()
    {
        StartCoroutine(RotateTowardsTable());
    }

    private IEnumerator RotateTowardsTable()
    {
        Quaternion targetRotation = Quaternion.LookRotation(table.position - transform.position);

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }

        Debug.Log("Поворот завершен, вызываем ContinueMovement");
        cartStop.ContinueMovement(); // Вызываем метод ContinueMovement у скрипта CartStop
    }
}

// Остальные классы остаются без изменений