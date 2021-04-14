using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleTransition : MonoBehaviour
{
    public string scene;

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(scene);
    }
}
