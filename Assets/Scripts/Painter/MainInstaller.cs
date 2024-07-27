using PainterTest;
using PainterTest.Controllers;
using PainterTest.Services;
using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    [SerializeField] private InputService _inputService;
    
    public override void InstallBindings()
    {
        InstallServices();
        InstallControllers();
        InstallStates();
    }

    private void InstallServices()
    {
        Container.BindInterfacesAndSelfTo<CameraService>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<InputService>().FromInstance(_inputService).AsSingle().NonLazy();
    }

    private void InstallControllers()
    {
        Container.BindInterfacesAndSelfTo<PainterController>().AsSingle().NonLazy();
    }

    private void InstallStates()
    {
        Container.BindInterfacesAndSelfTo<PaintingState>().AsSingle().NonLazy();
    }
}
