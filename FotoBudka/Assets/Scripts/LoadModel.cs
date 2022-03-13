using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadModel : MonoBehaviour
{
    public Object[] models;
    public GameObject model;
    public int modelNumber, maxIndexOfModels = -1;

    void Awake()
    {
        modelNumber = 0;
        models = Resources.LoadAll("Input", typeof(GameObject));
        maxIndexOfModels = MaxIndexOfModels(models);
        model = (GameObject)Instantiate(models[modelNumber], new Vector3(0, 0, 0), Quaternion.identity, this.gameObject.transform);
        model.AddComponent<ModelMovement>();
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
        model = (GameObject)Instantiate(BackModel(models), new Vector3(0, 0, 0), Quaternion.identity, this.gameObject.transform);
        model.AddComponent<ModelMovement>();
    }

    public void ForwardButton()
    {
        model = (GameObject)Instantiate(ForwardModel(models), new Vector3(0, 0, 0), Quaternion.identity, this.gameObject.transform);
        model.AddComponent<ModelMovement>();
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
