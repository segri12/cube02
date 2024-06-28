using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ExplosiveCube : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        TryGetComponent(out _rigidbody);
    }

    public Rigidbody GetRigidbody()
    {
        return _rigidbody;
    }
}