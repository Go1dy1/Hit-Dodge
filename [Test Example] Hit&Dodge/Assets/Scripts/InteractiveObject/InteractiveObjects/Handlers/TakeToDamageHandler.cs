using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace InteractiveObjects.Handlers
{
    public class TakeToDamageHandler : MonoBehaviour
    {
        [Header("Forces for Discard object")]
        [SerializeField] private float _forceDiscard;
        [SerializeField] private float _maxDiscard;
        
        private List<string> _tagToDamage;
        private int _damage;
        private void OnEnable()
        {
            DamageManager damageManager = FindObjectOfType<DamageManager>();

            if (damageManager != null)
            {
                _tagToDamage = damageManager.TagToDamage;
                _damage = damageManager.Damage;
            }
            else
            {
                _tagToDamage = new List<string>();
                _damage = 0;
            }
        }

        private async void OnTriggerEnter2D(Collider2D col)
        {
            foreach (var currentTag in _tagToDamage)
            {
                if (col.CompareTag(currentTag))
                {
                    var cur = col.GetComponent<Rigidbody2D>();
                    var positionDiscarding = col.GetComponentInChildren<MoveHandler>();
                    col.GetComponentInChildren<EnemiesTakeDamageHandler>().TakeDamage( _damage);

                    Vector2 force = positionDiscarding.Discarding.position * _forceDiscard;
                    cur.AddForce(Vector2.ClampMagnitude (force, _maxDiscard) , ForceMode2D.Impulse);

                    await Task.Delay(500);

                    break;
                }
            }
        }
    }
}