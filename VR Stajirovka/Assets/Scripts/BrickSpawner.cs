using UnityEngine;
using System.Collections;


public class BrickSpawner : MonoBehaviour
{
    public GameObject brickPrefab; // Предварительно созданный префаб кирпича
    public GameObject cart; // Объект тележки
    public Transform targetPoint; // Точка, к которой должна подъехать тележка
    public float spawnDistance = 1f; // Расстояние, на котором должен появиться кирпич

    private bool hasSpawned = false; // Флаг, чтобы создать кирпич только один раз

    void Update()
    {
        // Проверяем, не создан ли уже кирпич и находится ли тележка достаточно близко к точке
        if (!hasSpawned && Vector3.Distance(cart.transform.position, targetPoint.position) <= spawnDistance)
        {
            // Создаем кирпич на тележке
            GameObject brick = Instantiate(brickPrefab, cart.transform.position, Quaternion.identity);
            brick.transform.parent = cart.transform; // Прикрепляем кирпич к тележке
            hasSpawned = true; // Устанавливаем флаг, чтобы больше не создавать кирпичи
        }
    }
}