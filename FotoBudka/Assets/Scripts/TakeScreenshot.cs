using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour
{
    DateTime dateTime;
    int width, height;

    void Awake()
    {
        width = Screen.width;
        height = Screen.height;
    }
    void TakeAScreenshot()
    {
        /*dateTime = DateTime.Now;
        Texture2D screenshoot = new Texture2D(width, height);
        Rect rect = new Rect(0, 0, width, height);
        screenshoot.ReadPixels(rect, 0, 0);
        screenshoot.Apply();

        byte[] byteArray = screenshoot.EncodeToPNG();
        System.IO.File.WriteAllBytes($"{Application.persistentDataPath}/Output/{dateTime.ToString()}", byteArray);*/
        //ScreenCapture.CaptureScreenshot($"{Application.persistentDataPath}/Output/{dateTime.ToString()}");
    }

    public void PhotoButton()
    {
        TakeAScreenshot();
    }
}
