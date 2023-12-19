using UnityEngine;

namespace InteractiveObjects.Handlers
{
    public class GameOverHandler : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void ShowGameOverUI()
        {
            gameObject.SetActive(true);
        }
    }
}