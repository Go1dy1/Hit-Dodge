using InteractiveObjects.Handlers;
using TMPro;
using UnityEngine;

namespace InteractiveObjects.Basics
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _score;
        private int counter;

        private void Start()
        {
            EnemiesTakeDamageHandler[] enemyHandlers = FindObjectsOfType<EnemiesTakeDamageHandler>();

            foreach (var enemyHandler in enemyHandlers)
            {
                enemyHandler.OnObjectDisable += HandleObjectDisable;
            }
        }

        private void HandleObjectDisable()
        {
            counter++;
            _score.text = counter.ToString();
        }
    }
}