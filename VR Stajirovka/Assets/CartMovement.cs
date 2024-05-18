using UnityEngine;
using System.Collections.Generic;

public class CartMovement : MonoBehaviour
{
    public List<Transform> waypoints; // Список точек, через которые должна проехать вагонетка
    public float speed = 5f; // Скорость движения вагонетки
    private int waypointIndex = 0; // Текущий индекс в списке waypoints
    private bool isMoving = true; // Состояние движения вагонетки

    private void Update()
    {
        if (isMoving && waypointIndex < waypoints.Count)
        {
            Move();
        }
    }

    private void Move()
    {
        Transform targetWaypoint = waypoints[waypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (transform.position == targetWaypoint.position)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Count)
            {
                // Вагонетка достигла последней точки
                Machine.Instance.ReleasePart(); // Вызываем метод выдачи детали
                isMoving = false; // Останавливаем вагонетку
            }
        }
    }

    public void StopMovement()
    {
        isMoving = false; // Останавливаем вагонетку
    }

    public void StartMovement()
    {
        if (waypointIndex < waypoints.Count)
        {
            isMoving = true; // Возобновляем движение вагонетки
        }
    }
}