using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    void LateUpdate()
    {
        // Look at a point that is a sum of the GameObject's current position and the camera's forward vector.
        transform.LookAt(transform.position + cam.forward);
    }
}
