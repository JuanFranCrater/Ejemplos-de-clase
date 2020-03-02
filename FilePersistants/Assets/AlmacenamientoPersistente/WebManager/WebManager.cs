using Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Utils;

public class WebManager : Singleton<WebManager>
{
    public string url = "https://www.example.com";

    private void Start()
    {
        DownloadFile();
    }

    public void DownloadFile()
    {
        DownloadFile(url);
    }

    public void DownloadFile(string url)
    {
        StartCoroutine(DonwloadFileRequest(url));
    }

    private IEnumerator DonwloadFileRequest(string url)
    {
        //Connect to server
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desird page.
            yield return webRequest.SendWebRequest();

            if (!webRequest.isNetworkError)
            {
                //We read it!
                string webText = webRequest.downloadHandler.text;
                FileManager.Instance.Write("Web", webText);
                Debug.Log("Bien hecho tio");
            }
            else
            {
                Debug.LogError("[DataManager.ERROR]: Network Error");
            }
        }
    }
}
