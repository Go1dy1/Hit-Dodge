using InteractiveObjects.Handlers;
using UnityEngine;

namespace InteractiveObjects.Handlers
{
    public class HealthHandler : MonoBehaviour
    {
        [SerializeField] private Transform bar;
        [SerializeField] private GameOverHandler gameOver;
        [SerializeField] private Animator animator;
        [SerializeField] private float MaxHealthPoints = 100;
        private float currentHealthPoints = 0;
        private bool isDead = false;

        private void Awake()
        {
            SetHealth(MaxHealthPoints);
            gameOver = FindObjectOfType<GameOverHandler>();
        }

        private void TakeDamage(int damagePoints)
        {
            var jumpHandler = FindObjectOfType<JumpHandler>();

            if (jumpHandler != null && jumpHandler._isGrounded)
            {
                currentHealthPoints -= damagePoints;
                UpdateHealthBar();

                if (currentHealthPoints <= 0 && !isDead )
                {
                    isDead = true; 
                    animator.SetTrigger("Death");
                    gameOver.gameObject.SetActive(true);
                }
            }
        }

        private void SetHealth(float health)
        {
            currentHealthPoints = health;
            UpdateHealthBar();
        }
    
        private void UpdateHealthBar()
        {
            float healthPercent = currentHealthPoints / MaxHealthPoints;
            bar.localScale = new Vector3(healthPercent, 1f, 1f);
        }
        public void InflictDamageOnPlayer(int damageAmount)
        {
            TakeDamage(damageAmount);
        }
    }
}