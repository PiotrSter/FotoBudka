using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform cameraTramsform;
    void Awake()
    {
        cameraTramsform = this.transform;
    }

    Vector3 ZoomPlus (Transform transform)
    {
        if (transform.position.z <= -1.9f)
            return transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y - 0.1f, transform.position.z + 0.1f);
        else
            return transform.position;
    }

    Vector3 ZoomMinus(Transform transform)
    {
        if (transform.position.z >= -4f)
            return transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y + 0.1f, transform.position.z - 0.1f);
        else
            return transform.position;
    }

    public void PlusZoomButton()
    {
        ZoomPlus(cameraTramsform);
    }

    public void MinusZoomButton()
    {
        ZoomMinus(cameraTramsform);
    }
}
