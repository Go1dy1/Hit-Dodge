using UnityEngine;
namespace InteractiveObjects.Handlers
{
    public class MoveHandler : MonoBehaviour
    {
        [Header("Move Attribute")]
        [SerializeField] private Transform _discarding;
        [SerializeField] public bool _isCantMove;
        [SerializeField] private Animator _animator;
        
        private Vector3 _targetPoint = new Vector3(0, -2.82f, 0);
        public Transform Discarding{ get { return _discarding; } }
        private InteractiveObject _currentGamObject;
        private CharacterDisplay _enemyDataConfig;
        private float _speed;

        private void OnEnable()
        {
            _enemyDataConfig = GetComponentInParent<CharacterDisplay>();
            _currentGamObject = GetComponentInParent<InteractiveObject>();

            if (_enemyDataConfig != null) _speed = _enemyDataConfig._speedAttributte;
        }

        private void Update()
        {
            if (!_isCantMove)
            {
                Move();
                _animator.SetInteger("AnimState", 2);
            }
            else _animator.SetInteger("AnimState", 1);
            
        }

        private void Move()
        {
            if (_currentGamObject != null)
            {
                Vector3 direction = _targetPoint - _currentGamObject.transform.position;

                _currentGamObject.transform.Translate(direction.normalized * _speed * Time.deltaTime);
            }
        }
    }
}
