using UnityEngine;

namespace InteractiveObjects.Handlers
{
    public class StopCharacterHandler : MonoBehaviour
    {
        [Header("Stop Enemies Settings")] [SerializeField]
        private LayerMask enemyLayer;

        [SerializeField] private float _detectionRadius = 5f;
        [SerializeField] private float _stopDistance = 1.5f;

        private void Update()
        {
            StopNearestCharacters();
        }

        private Collider2D[] FindCollidersInCircle()
        {
            return Physics2D.OverlapCircleAll(transform.position, _detectionRadius, enemyLayer);
        }

        private void StopNearestCharacters()
        {
            foreach (Collider2D collider in FindCollidersInCircle())
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                var currentCol = collider.GetComponentInChildren<MoveHandler>();
                if (distance < _stopDistance && currentCol != null)
                {
                    currentCol._isCantMove = true;
                }
                else if (distance > _stopDistance && currentCol != null)
                {
                    currentCol._isCantMove = false;
                }
            }
        }
    }
}