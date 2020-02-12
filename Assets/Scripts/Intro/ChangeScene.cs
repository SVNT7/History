using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMyScene : MonoBehaviour
{
    public void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
    }
    
}