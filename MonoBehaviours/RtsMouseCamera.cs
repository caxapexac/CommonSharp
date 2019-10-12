using UnityEngine;


namespace Client.Scripts.Algorithms.MonoBehaviours
{
    public class RtsMouseCamera : MonoBehaviour
    {
        public float Sensitivity;

        private Vector3 _lastPosition;

        private void LateUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastPosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                var delta = (_lastPosition - Input.mousePosition);
                var deltaxz = new Vector3(delta.x, 0f, delta.y);
                var position = transform.position;
                position = Vector3.Lerp(position, position + deltaxz, Sensitivity * Time.deltaTime);
                transform.position = position;
                _lastPosition = Input.mousePosition;
            }
        }
    }
}