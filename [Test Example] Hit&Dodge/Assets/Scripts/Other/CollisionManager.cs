using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] private string targetTag ;

    void Update()
    {
        // Находим все объекты с тегом targetTag
        GameObject[] objects = GameObject.FindGameObjectsWithTag(targetTag);

        // Проходим по каждому объекту и отключаем коллизии между ними
        for (int i = 0; i < objects.Length; i++)
        {
            for (int j = i + 1; j < objects.Length; j++)
            {
                Physics2D.IgnoreCollision(objects[i].GetComponent<Collider2D>(), objects[j].GetComponent<Collider2D>(), true);
            }
        }
    }
}