using System;
using System.IO;
using System.Collections;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour
{
    DateTime dateTime;
    int width, height;
    Canvas canvas;

    void Awake()
    {
        width = Screen.width;
        height = Screen.height;
        canvas = FindObjectOfType<Canvas>();
    }

    IEnumerator TakeAScreenshot()
    {
        yield return new WaitForEndOfFrame();

        dateTime = DateTime.Now;
        string path = $"{Application.persistentDataPath}/Output";
        DirectoryInfo directoryInfo;
        string fileName = dateTime.ToString("yyyy/MM/dd H-mm-ss");
        if (!Directory.Exists(path))
            directoryInfo = Directory.CreateDirectory(path);
        if (!File.Exists($"{fileName}.png"))
        {
            Texture2D screenshoot = new Texture2D(width, height);
            Rect rect = new Rect(0, 0, width, height);
            screenshoot.ReadPixels(rect, 0, 0);
            screenshoot.Apply();
            byte[] byteArray = screenshoot.EncodeToPNG();
            File.WriteAllBytes($"{path}/{fileName}.png", byteArray);
        }
        canvas.enabled = true;
    }

    public void PhotoButton()
    {
        canvas.enabled = false;
        StartCoroutine(TakeAScreenshot());
    }
}
