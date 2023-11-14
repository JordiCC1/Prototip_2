using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private bool invert;
    private Transform cameraTrasform;

    private void Awake()
    {
        cameraTrasform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        if(invert) 
        { 
            Vector3 dirToCamera = (cameraTrasform.position - transform.position).normalized;
            transform.LookAt(transform.position + dirToCamera * -1);
        }else
        {
            transform.LookAt(cameraTrasform);

        }
    }
}
