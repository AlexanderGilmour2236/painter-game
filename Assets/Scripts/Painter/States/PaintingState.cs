using Core;

namespace PainterTest
{
    public class PaintingState : GameState
    {
        private readonly Painter _painter;
        private readonly InputSystem _inputSystem;
        
        private bool _isTryingToPaint;

        public PaintingState(Painter painter, InputSystem inputSystem)
        {
            _painter = painter;
            _inputSystem = inputSystem;
        }

        public override void Enter()
        {
            base.Enter();
            
            _inputSystem.PointerDown += OnPaintingButtonDown;
            _inputSystem.PointerUp += OnPaintingButtonUp;
        }

        public override void Exit()
        {
            base.Exit();
            
            _inputSystem.PointerDown -= OnPaintingButtonDown;
            _inputSystem.PointerUp -= OnPaintingButtonUp;
        }

        private void OnPaintingButtonDown()
        {
            _isTryingToPaint = true;
        }

        private void OnPaintingButtonUp()
        {
            _isTryingToPaint = false;
        }

        public override void Tick()
        {
            base.Tick();
            if (_isTryingToPaint)
            {
                _painter.TryPaintFromMousePosition();
            }
        }
    }
}