using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private ExplosiveCube _explosiveCube;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private int _currentSplitChance = 1;
    [SerializeField] private int _chanceReductionFactor = 2;

    private void OnMouseDown() 
    {
        bool isSplit = Random.Range(0, _currentSplitChance) == 0;

        if (isSplit)
        {
            _explosion.BlowUp(_cubeSpawner.GetExplodableObjects(), true);
            _currentSplitChance *= _chanceReductionFactor;
        }
        else
        {
            List<Rigidbody> existingCubes = new List<Rigidbody> { _explosiveCube.GetRigidbody() };
            _explosion.BlowUp(existingCubes, false);
        }

        Destroy(_explosiveCube.gameObject);
    }
}