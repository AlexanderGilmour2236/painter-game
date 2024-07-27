using UnityEngine;

namespace PainterTest.Services
{
    public class CameraService : ICameraService
    {
        private Camera _mainCamera;

        public void SetMainCamera()
        {
            SetMainCamera(Object.FindObjectOfType<Camera>());
        }

        public void SetMainCamera(Camera camera)
        {
            _mainCamera = camera;
        }

        public Camera MainCamera
        {
            get { return _mainCamera; }
        }
    }
}