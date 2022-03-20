using UnityEngine;

namespace Code
{
    public class Movable : MonoBehaviour
    {
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }
        
        [SerializeField] private float _speed;
        
        private void Update()
        {
            Transform cachedTransform = transform; 
            cachedTransform.localPosition += cachedTransform.forward * _speed;
        }
    }
}