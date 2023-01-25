using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromComponentInNewPrefab(playerPrefab).AsSingle().NonLazy();

        Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<InputManager>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<DataManager>().FromComponentInHierarchy().AsSingle().NonLazy();

        Container.Bind<UI_MainScreen>().FromComponentInHierarchy().AsSingle().NonLazy();

        Container.BindMemoryPool<Enemy, Enemy.Pool>().WithInitialSize(10)
       .FromComponentInNewPrefab(enemyPrefab).UnderTransformGroup("Enemy Pool");
    }
}