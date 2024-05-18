using UnityEngine;

public class PartCounter : MonoBehaviour
{
    public int partCount; // Публичное поле для счетчика деталей

    void Start()
    {
        partCount = 10; // Инициализация счетчика деталей со значением 10
    }

    public void AddParts(int amount)
    {
        partCount += amount;
    }

    public void RemoveParts(int amount)
    {
        partCount -= amount;
    }

    public int GetPartCount()
    {
        return partCount;
    }
}
