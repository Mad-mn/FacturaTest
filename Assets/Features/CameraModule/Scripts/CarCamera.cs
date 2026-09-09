using System;
using Unity.Cinemachine;
using UnityEngine;

public class CarCamera : MonoBehaviour {
    private Transform _target;
    private bool _hasTarget;
    
    public void SetupTarget(Transform target) {
        _target = target;
        transform.position = _target.position;
        transform.rotation = _target.rotation;
        _hasTarget = true;
    }

    private void Update() {
        if(!_hasTarget)
            return;
        transform.position = new Vector3(transform.position.x, transform.position.y, _target.position.z);
    }
}

