using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<DataManager>().FromComponentInHierarchy().AsSingle().NonLazy();

        Container.Bind<UI_MainScreen>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}