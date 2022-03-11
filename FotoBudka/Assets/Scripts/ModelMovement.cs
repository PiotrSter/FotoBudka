using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMovement : MonoBehaviour
{
    Vector3 mPrevPos, mPosDelta;
    public Transform modelTransform;
    public Rigidbody rb;

    void Awake()
    {
        mPrevPos = Vector3.zero;
        mPosDelta = Vector3.zero;
        modelTransform = this.transform;
        rb = this.gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mPosDelta = Input.mousePosition - mPrevPos;
            if (Vector3.Dot(modelTransform.up, Vector3.up) >= 0)
                modelTransform.Rotate(modelTransform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
            else
                modelTransform.Rotate(modelTransform.up, Vector3.Dot(mPosDelta, Camera.main.transform.up), Space.World);

            modelTransform.Rotate(Camera.main.transform.right, Vector3.Dot(mPosDelta, Camera.main.transform.up), Space.World);
        }

        mPrevPos = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.W))
            rb.velocity = new Vector3(1f, 0, 0);
    }
}
