using Core.Controllers;

namespace Core
{
    public class GameState : ITickable
    {
        protected CompositeController _stateControllers = new CompositeController();

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
            
        }
        
        public virtual void Tick()
        {
            _stateControllers.Tick();
        }
    }
}