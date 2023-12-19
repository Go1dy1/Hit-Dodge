using Cysharp.Threading.Tasks;
using UnityEngine;

namespace InteractiveObjects.Handlers
{
    public class EnemiesAttackHandler : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private MoveHandler _moveHandler;
       
        private async void OnEnable()
        {
            _moveHandler = GetComponentInChildren<MoveHandler>();
            await UniTask.WaitWhile(() => _moveHandler == null);
        }

        private void Update()
        {
            if (_moveHandler != null && _animator != null) Attacking();
        }

        private void Attacking()
        {
            if(_moveHandler._isCantMove)
            {
                print("Attack!");
                _animator.SetTrigger("Attack");
            }
        }
    }
}
