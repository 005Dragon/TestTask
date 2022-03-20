using UnityEngine;

namespace Code
{
    public class MaxDistanceDestroyer : MonoBehaviour
    {
        public float MaxDistance
        {
            get => _maxDistance;
            set => _maxDistance = value;
        }
        
        [SerializeField] private float _maxDistance;

        private DistanceCounter _distanceCounter;

        private void Awake()
        {
            _distanceCounter = GetComponent<DistanceCounter>();
        }

        private void Update()
        {
            if (_distanceCounter == null)
            {
                return;
            }

            if (_distanceCounter.Distance > _maxDistance)
            {
                Destroy(gameObject);
            }
        }
    }
}