using UnityEngine;
using Zenject;

namespace Common.Infrastructure
{
    public class SceneInstaller : MonoInstaller
    {
        // Название сцены, которую вы хотите загрузить
        public string SceneToLoad = "GameScene";

        public override void InstallBindings()
        {
            // Вызываем загрузку сцены при установке зависимостей
            LoadScene(SceneToLoad);
        }

        private void LoadScene(string sceneName)
        {
            // Загружаем сцену по её имени
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}