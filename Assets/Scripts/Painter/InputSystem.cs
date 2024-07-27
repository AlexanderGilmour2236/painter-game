﻿using System;
using UnityEngine;

namespace PainterTest
{
    public class InputSystem : MonoBehaviour
    {
        private bool _enabled = true;
        private bool _isMouseButtonDown = false;

        public event Action PointerDown;
        public event Action PointerUp;
        
        public void SetIsEnabled(bool isEnabled)
        {
            _enabled = isEnabled;
        }

        void Update()
        {
            if (!_enabled)
            {
                return;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                _isMouseButtonDown = true;
                PointerDown?.Invoke();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _isMouseButtonDown = false;
                PointerUp?.Invoke();
            }
        }

        public bool isMouseButtonDown
        {
            get { return _isMouseButtonDown; }
        }
    }
}