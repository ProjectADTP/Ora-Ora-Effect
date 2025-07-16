using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEffectCreator : MonoBehaviour
{
    [SerializeField] private ParticleSystem _clickEffectPrefab;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform _platform;
    [SerializeField] private LayerMask _platformLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            CreateClickEffect();
        }
    }

    private void CreateClickEffect()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _platformLayer))
        {
            Instantiate(_clickEffectPrefab,new Vector3(hit.point.x, hit.point.y, hit.point.z - 5), Quaternion.LookRotation(Vector3.forward));
        }
    }
}
