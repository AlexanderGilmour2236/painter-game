using System;

namespace PainterTest.Services
{
    public interface IInputService
    {
        public event Action PointerDown;
        public event Action PointerUp;
        void SetIsEnabled(bool isEnabled);
        bool IsMouseButtonDown { get; }
    }
}