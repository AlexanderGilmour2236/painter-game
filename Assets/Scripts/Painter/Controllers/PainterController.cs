using Core;
using PainterTest.Services;
using UnityEngine;
using Zenject;

namespace PainterTest.Controllers
{
    public class PainterController : IGameController
    {
        private readonly ICameraService _cameraService;
        private readonly IInputService _inputService;

        private Painter _painter;
        
        private bool _isTryingToPaint;

        private const string TargetTag = "Paintable";

        [Inject]
        public PainterController(ICameraService cameraService, IInputService inputService)
        {
            _cameraService = cameraService;
            _inputService = inputService;
        }

        public void Start()
        {
            _painter = Object.FindObjectOfType<Painter>();
            
            _inputService.PointerDown += OnPaintingButtonDown;
            _inputService.PointerUp += OnPaintingButtonUp;
        }

        public void Stop()
        {
            _inputService.PointerDown -= OnPaintingButtonDown;
            _inputService.PointerUp -= OnPaintingButtonUp;
        }
        
        private void OnPaintingButtonDown()
        {
            _isTryingToPaint = true;
        }

        private void OnPaintingButtonUp()
        {
            _isTryingToPaint = false;
        }

        public void Tick()
        {
            if (_isTryingToPaint)
            {
                TryPaintFromMousePosition();
            }
        }

        public void TryPaintFromMousePosition()
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(_cameraService.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, float.MaxValue, 
                1 << LayerMask.NameToLayer(TargetTag)))
            {
                raycastHit.collider.GetComponent<Paintable>();
                Debug.Log("!!! PAINTING !!!");
            }
            else
            {
                Debug.Log("not painting :C");
            }
        }
    }
}