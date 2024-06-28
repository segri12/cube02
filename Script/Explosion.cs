using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour 
{
    [SerializeField] private float _explodeRadius = 10f;
    [SerializeField] private float _explodeForce = 100;

    public void BlowUp(List<Rigidbody> explodableObjects, bool isSplit) 
    {
        foreach (var explodableObject in explodableObjects)
        {
            if (isSplit)
            {
                explodableObject.AddExplosionForce(_explodeForce, transform.position, _explodeRadius);
            }
            else
            {
                float force = CalculateExplosionForce(explodableObject.transform.position, explodableObject.transform.localScale.x);
                explodableObject.AddForce(transform.position - explodableObject.transform.position * force, ForceMode.Impulse);
            }
        }
    }

    public float CalculateExplosionForce(Vector3 targetPosition, float cubeScale) 
    {
        float distance = Vector3.Distance(transform.position, targetPosition);
        float forceMultiplier = 1f / cubeScale;
        float force = (_explodeForce * forceMultiplier) / distance;
        return force;
    }
}