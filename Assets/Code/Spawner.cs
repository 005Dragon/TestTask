using UnityEngine;
using UnityEngine.Events;

namespace Code
{
    public class Spawner : MonoBehaviour
    {
        public UnityEvent<GameObject> Spawned;
        
        public float SpawnCooldown
        {
            get => _spawnCooldown;
            set => _spawnCooldown = value;
        }

        [SerializeField] private GameObject _gameObjectTemplate;
        [SerializeField] private float _spawnCooldown;

        private float _cooldown;

        private void Update()
        {
            _cooldown += Time.deltaTime;

            if (_cooldown > _spawnCooldown)
            {
                _cooldown = 0;

                var spawnedObject = Instantiate(
                    _gameObjectTemplate,
                    parent: transform,
                    worldPositionStays: false
                );
                
                spawnedObject.transform.SetParent(null);
                
                Spawned.Invoke(spawnedObject);
            }
        }
    }
}
