using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;
    private void Awake()
    {
        if(GameObject.FindGameObjectWithTag("Music") != null)
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
    }
    public void LoadGameScene()
    {
        if (sceneToLoad.Equals("Game"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Music"));
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}
