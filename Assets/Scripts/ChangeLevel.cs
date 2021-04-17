using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("CAMBIO NIVEL");

        GameManager.GetInstance().setCurrentPatron(-1); //Reset de patron
        GameManager.GetInstance().SetPhase(Phase.ADVANCE); //Reset de fase

        if (GameManager.GetInstance().getLevel() < 2)
        {
            GameManager.GetInstance().advanceLevel(); //Avanza el nivel
            SceneManager.LoadSceneAsync(GameManager.GetInstance().getLevelScene(GameManager.GetInstance().getLevel()));
        }
        else
        {
            //SceneManager.LoadSceneAsync(sceneToTransitionTo)
            //Escena final?
            Debug.Log("final de juego");
        }

    }
}
