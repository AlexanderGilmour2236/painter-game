using UnityEngine;

namespace PainterTest.Services
{
    public interface ICameraService
    {
        void SetMainCamera();
        void SetMainCamera(Camera camera);
        Camera MainCamera { get; }
    }
}