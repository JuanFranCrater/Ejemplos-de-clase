using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;
	
    public void LoadGameScene()
    {
        if (sceneToLoad.Equals("Game"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Music"));
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}
