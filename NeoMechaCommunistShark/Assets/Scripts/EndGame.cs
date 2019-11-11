using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
public class EndGame : MonoBehaviour
{
    public void loadWin()
    {
        SceneManager.LoadScene("Win");
    }
}
