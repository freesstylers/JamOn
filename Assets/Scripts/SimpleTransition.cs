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


    public void LoadSceneDeleteGamemanager()
    {
        SceneManager.LoadSceneAsync(scene);

        GameManager.GetInstance().reset();
    }

}
