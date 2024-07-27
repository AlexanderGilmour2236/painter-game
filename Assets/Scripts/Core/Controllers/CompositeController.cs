namespace Core.Controllers
{
    public class CompositeController : IGameController
    {
        private readonly IGameController[] _gameControllers;

        public CompositeController(params IGameController[] gameControllers)
        {
            _gameControllers = gameControllers;
        }
        
        public void Start()
        {
            foreach (IGameController gameController in _gameControllers)
            {
                gameController.Start();
            }
        }

        public void Stop()
        {
            foreach (IGameController gameController in _gameControllers)
            {
                gameController.Stop();
            }
        }

        public void Tick()
        {
            foreach (IGameController gameController in _gameControllers)
            {
                gameController.Tick();
            }
        }
    }
}