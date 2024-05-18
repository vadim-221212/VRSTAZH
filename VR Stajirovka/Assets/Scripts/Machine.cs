using UnityEngine;
using System.Collections;
public class Machine : MonoBehaviour
{
    public static Machine Instance; // Синглтон для доступа к станку
    public GameObject partPrefab; // Префаб детали, которую нужно создать
    public Transform releasePoint; // Точка, где деталь будет создана

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ReleasePart()
    {
        if (partPrefab != null && releasePoint != null)
        {
            Instantiate(partPrefab, releasePoint.position, Quaternion.identity);
            Debug.Log("Станок выдал деталь.");
        }
        else
        {
            Debug.LogError("Не задан префаб детали или точка выдачи.");
        }
    }
}