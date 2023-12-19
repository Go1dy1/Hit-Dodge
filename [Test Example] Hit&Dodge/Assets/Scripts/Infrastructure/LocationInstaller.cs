using UnityEngine;
using Zenject;

namespace Common.Infrastructure
{
    public class LocationInstaller : MonoInstaller
    {
        public Transform SpawnPoint;
        public GameObject KnightPrefab;
        
        public override void InstallBindings()
        {
            InteractiveObject _interactiveObject =Container.
                InstantiatePrefabForComponent<InteractiveObject>(KnightPrefab,SpawnPoint.position,Quaternion.identity,null);

            Container.Bind<InteractiveObject>()
                .FromInstance(_interactiveObject)
                .AsSingle();


        }
    }
}