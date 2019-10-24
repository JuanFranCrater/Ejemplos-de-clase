using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public List<string> sceneList;
	
    public void LoadScene(int n)
    {
        SceneManager.LoadScene(sceneList[n]);
    }
}
