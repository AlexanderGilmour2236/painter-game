using Core;
using Core.Controllers;
using PainterTest.Controllers;
using PainterTest.Services;
using Zenject;

namespace PainterTest
{
    public class PaintingState : GameState
    {
        private readonly ICameraService _cameraService;

        [Inject]
        public PaintingState(PainterController painterController, ICameraService cameraService)
        {
            _cameraService = cameraService;
            _stateControllers = new CompositeController(
                painterController
            );
        }

        public override void Enter()
        {
            base.Enter();
            _cameraService.SetMainCamera();
            _stateControllers.Start();
        }

        public override void Exit()
        {
            base.Exit();
            _stateControllers.Stop();
        }

        public override void Tick()
        {
            base.Tick();
        }
    }
}