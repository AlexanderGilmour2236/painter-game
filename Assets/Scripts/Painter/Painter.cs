using UnityEngine;

namespace PainterTest
{
    public class Painter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private string _targetTag = "Paintable";

        public void TryPaintFromMousePosition()
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out raycastHit, float.MaxValue, 
                1 << LayerMask.NameToLayer(_targetTag)))
            {
                Debug.Log("!!! PAINTING !!!");
            }
            else
            {
                Debug.Log("not painting :C");
            }
        }
    }

}
