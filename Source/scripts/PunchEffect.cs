using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effectPrefab;
    private List<ParticleCollisionEvent> _collisionEvents = new List<ParticleCollisionEvent>();
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        int eventCount = _particleSystem.GetCollisionEvents(other, _collisionEvents);

        if (eventCount > 0)
        {
            ParticleCollisionEvent collisionEvent = _collisionEvents[0];

            Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, collisionEvent.normal);

            Instantiate(_effectPrefab, collisionEvent.intersection, rotation);
        }
    }
}
