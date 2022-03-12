using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMovement : MonoBehaviour
{
    Vector3 mPrevPos, mPosDelta, mOffset;
    float mZCoord;
    public Transform modelTransform;

    void Awake()
    {
        mPrevPos = Vector3.zero;
        mPosDelta = Vector3.zero;
        modelTransform = this.transform;
        BoxCollider boxCollider = this.gameObject.AddComponent<BoxCollider>();
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(modelTransform.position).z;

        mOffset = modelTransform.position - GetMouseWorldPos();
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        modelTransform.position = GetMouseWorldPos() + mOffset;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            mPosDelta = Input.mousePosition - mPrevPos;
            if (Vector3.Dot(modelTransform.up, Vector3.up) >= 0)
                modelTransform.Rotate(modelTransform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
            else
                modelTransform.Rotate(modelTransform.up, Vector3.Dot(mPosDelta, Camera.main.transform.up), Space.World);

            modelTransform.Rotate(Camera.main.transform.right, Vector3.Dot(mPosDelta, Camera.main.transform.up), Space.World);
        }

        mPrevPos = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.R))
        {
            modelTransform.position = new Vector3(0, 0, 0);
            modelTransform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
