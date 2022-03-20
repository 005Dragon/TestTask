using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public class SpawnSettings : MonoBehaviour
    {
        [SerializeField] private InputField _spawnCooldownInputField;
        [SerializeField] private InputField _speedInputField;
        [SerializeField] private InputField _maxDistanceInputField;

        [SerializeField] private Spawner _spawner;

        private void Awake()
        {
            _spawner.Spawned.AddListener(SpawnerOnSpawned);
            _spawnCooldownInputField.onValueChanged.AddListener(SpawnCooldownInputFieldOnValueChanged);
        }

        public void Start()
        {
            if (float.TryParse(_spawnCooldownInputField.text, out float spawnCooldown))
            {
                _spawner.SpawnCooldown = spawnCooldown;
            }
        }

        private void SpawnCooldownInputFieldOnValueChanged(string value)
        {
            if (float.TryParse(value, out float spawnCooldown))
            {
                _spawner.SpawnCooldown = spawnCooldown;
            }
        }

        private void SpawnerOnSpawned(GameObject spawnedGameObject)
        {
            if (spawnedGameObject.TryGetComponent(out Movable movable))
            {
                if (float.TryParse(_speedInputField.text, out float speed))
                {
                    movable.Speed = speed;
                }
            }

            if (spawnedGameObject.TryGetComponent(out MaxDistanceDestroyer maxDistanceDestroyer))
            {
                if (float.TryParse(_maxDistanceInputField.text, out float maxDistance))
                {
                    maxDistanceDestroyer.MaxDistance = maxDistance;
                }
            }
        }

        private void OnDestroy()
        {
            _spawner.Spawned.RemoveAllListeners();
            _spawnCooldownInputField.onValueChanged.RemoveAllListeners();
        }
    }
}