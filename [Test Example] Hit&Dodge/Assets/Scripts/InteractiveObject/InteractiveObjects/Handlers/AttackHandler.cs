using System;
using Cysharp.Threading.Tasks;
using Implementations.Other;
using UnityEngine;

namespace InteractiveObjects.Character
{
    public class AttackHandler : AbstractHandler
    { 
        [Header("Animator")]
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        [Header("Attack Settings")] 
        [SerializeField] private Collider2D _rightHand;
        [SerializeField] private Collider2D _leftHand;
        [SerializeField] private Transform _rightHandAttack;
        [SerializeField] private Transform _leftHandAttack;
        
        private async void Update()
        {
            if (Input.GetKeyDown("left"))
            {
                _animator.SetTrigger("LeftAttack");
                await MoveHand(_leftHand, _leftHandAttack.position);

            }
            if (Input.GetKeyDown("right"))
            {
                _animator.SetTrigger("RightAttack");
                await MoveHand(_rightHand, _rightHandAttack.position);
                
            }
        }

        private async UniTask MoveHand(Collider2D handCollider, Vector2 targetPosition)
        {
            handCollider.gameObject.transform.position = Vector2.MoveTowards(
                handCollider.gameObject.transform.position,
                targetPosition, 10);

            await UniTask.Delay(200);

            handCollider.gameObject.transform.position = Vector2.MoveTowards(
                handCollider.gameObject.transform.position,
                transform.position, 10);
        }
    }
}