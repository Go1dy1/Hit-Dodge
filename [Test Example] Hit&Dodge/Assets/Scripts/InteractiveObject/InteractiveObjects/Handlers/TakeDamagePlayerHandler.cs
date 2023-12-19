using UnityEngine;

namespace InteractiveObjects.Handlers
{
    public class TakeDamagePlayerHandler : MonoBehaviour
    {
        [SerializeField] private int _damagePoints;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                print("YES");
                var damageToHealth = col.GetComponentInChildren<HealthHandler>();
            }
        }
    }
}