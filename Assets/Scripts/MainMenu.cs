using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneName;
    public void SceneChange()
    {
        //load scene
        SceneManager.LoadScene(sceneName);
    }
}
