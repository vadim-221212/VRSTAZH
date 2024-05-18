using UnityEngine;
using System.Collections;

public class CartStop : MonoBehaviour
{
    public Transform targetWaypoint; // Точка, у которой должна остановиться вагонетка
    public float proximityThreshold = 1f; // Расстояние, на котором вагонетка начнет останавливаться
    public GameObject device; // Ссылка на прибор, который должен повернуться

    private bool isWaiting = false;

    void Update()
    {
        if (!isWaiting && Vector3.Distance(transform.position, targetWaypoint.position) <= proximityThreshold)
        {
            isWaiting = true;
            GetComponent<CartMovement>().StopMovement(); // Останавливаем вагонетку
            device.GetComponent<DeviceRotate>().StartRotation(); // Запускаем поворот прибора
        }
    }

    public void ContinueMovement()
    {
        isWaiting = false;
        GetComponent<CartMovement>().StartMovement(); // Возобновляем движение вагонетки
    }
}