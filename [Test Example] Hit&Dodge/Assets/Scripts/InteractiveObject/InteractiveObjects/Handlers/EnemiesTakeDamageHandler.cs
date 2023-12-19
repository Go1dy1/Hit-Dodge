using System;
using System.Threading.Tasks;
using UnityEngine;

namespace InteractiveObjects.Handlers
{
    public class EnemiesTakeDamageHandler : MonoBehaviour
    {
        public event Action OnObjectDisable;
        [SerializeField] private GameObject BodyObject;
        [SerializeField] private Animator _animator;
        private CharacterDisplay _enemyDataConfig;
        private int _healthPoints;
        private bool _hasTakenDamage;

        private void OnEnable()
        {
            _enemyDataConfig = GetComponentInParent<CharacterDisplay>();
            if (_enemyDataConfig != null) _healthPoints = _enemyDataConfig._healthAttributte;
        }

        private void OnDisable()
        {
            OnObjectDisable?.Invoke();
            _healthPoints = _enemyDataConfig._healthAttributte;
        }

        public async void TakeDamage(int DamagePoints)
        {
            _animator.SetTrigger("Hurt");
            _healthPoints -= DamagePoints;
            _hasTakenDamage = true;
            
            if (_healthPoints <= 0)
            {
                _animator.SetTrigger("Death");
                await Task.Delay(500);
                BodyObject.SetActive(false);
            }
        }
        private void Update()
        {
            print(_hasTakenDamage);
        }
    }
}