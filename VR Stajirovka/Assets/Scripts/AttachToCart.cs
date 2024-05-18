using UnityEngine;
using System.Collections;
public class AttachToCart : MonoBehaviour
{
    public GameObject brick; // Объект кирпича
    public GameObject cart; // Объект тележки
    public Vector3 attachmentPoint; // Точка присоединения на тележке

    public void AttachBrickToCart()
    {
        // Перемещаем кирпич к точке присоединения на тележке
        brick.transform.position = cart.transform.TransformPoint(attachmentPoint);
        
        // Делаем кирпич дочерним объектом тележки, чтобы он следовал за ней
        brick.transform.SetParent(cart.transform);
        
        // Отключаем Rigidbody, чтобы предотвратить дальнейшее взаимодействие с физикой
        Rigidbody brickRb = brick.GetComponent<Rigidbody>();
        if (brickRb != null)
        {
            brickRb.isKinematic = true;
        }
    }
}