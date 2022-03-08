using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadModel : MonoBehaviour
{
    public Object[] models;
    public Object model;
    public int modelNumber, maxIndexOfModels = -1;
    public ModelMovement modelMovement;

    void Awake()
    {
        modelNumber = 0;
        modelMovement = this.gameObject.GetComponent<ModelMovement>();
        models = Resources.LoadAll("Input", typeof(GameObject));
        maxIndexOfModels = MaxIndexOfModels(models);
        model = Instantiate(models[modelNumber], new Vector3(0, 0, 0), Quaternion.identity, this.gameObject.transform);
        modelMovement.modelTransform = this.gameObject.GetComponentInChildren<Transform>();
    }

    int MaxIndexOfModels(Object[] objects)
    {
        foreach (var obj in objects)
            maxIndexOfModels++;

        return maxIndexOfModels;
    }

    Object BackModel(Object[] objects)
    {
        Destroy(model);
        modelNumber--;
        if (modelNumber < 0)
        {
            modelNumber = maxIndexOfModels;
            return objects[modelNumber];
        }
        else
            return objects[modelNumber];
    }

    Object ForwardModel(Object[] objects)
    {
        Destroy(model);
        modelNumber++;
        if (modelNumber > maxIndexOfModels)
        {
            modelNumber = 0;
            return objects[modelNumber];
        }
        else
            return objects[modelNumber];
    }

    public void BackButton()
    {
        model = Instantiate(BackModel(models), new Vector3(0, 0, 0), Quaternion.identity, this.gameObject.transform);
        modelMovement.modelTransform = this.gameObject.GetComponentInChildren<Transform>();
    }

    public void ForwardButton()
    {
        model = Instantiate(ForwardModel(models), new Vector3(0, 0, 0), Quaternion.identity, this.gameObject.transform);
        modelMovement.modelTransform = this.gameObject.GetComponentInChildren<Transform>();
    }
}
