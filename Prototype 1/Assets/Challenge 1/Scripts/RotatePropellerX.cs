using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropellerX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * 180f);
    }
}
