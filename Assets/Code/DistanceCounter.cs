using UnityEngine;

namespace Code
{
    public class DistanceCounter : MonoBehaviour
    {
        public float Distance { get; private set; }

        private Vector3 _lastPosition;

        private void Start()
        {
            _lastPosition = transform.position;
        }

        private void Update()
        {
            Vector3 position = transform.position;
            Distance += (position - _lastPosition).magnitude;
            _lastPosition = position;
        }
    }
}