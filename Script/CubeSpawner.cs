using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private ExplosiveCube _explosiveCubePrefab;
    [SerializeField] private float _newScale = 0.5f;
    [SerializeField] private int _minCreateValue = 2;
    [SerializeField] private int _maxCreateValue = 6;

    public List<Rigidbody> GetExplodableObjects()
    {
        List<Rigidbody> explodableObjects = new List<Rigidbody>();

        int count = Random.Range(_minCreateValue, _maxCreateValue);

        for (int i = 0; i < count; i++)
        {
            GameObject scaledObject = InitializeScaledObject();

            if (scaledObject.TryGetComponent(out Rigidbody rigidbody))
            {
                explodableObjects.Add(rigidbody);
            }
        }

        return explodableObjects;
    }

    private GameObject InitializeScaledObject()
    {
        GameObject scaledObject = Instantiate(_explosiveCubePrefab.gameObject);
        scaledObject.transform.localScale *= _newScale;
        return scaledObject;
    }
}