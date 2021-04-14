using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Phase { COMMANDING, PLAYER, BATTLE, ADVANCE }

// ------------------------
// Clase Game Manager
// ------------------------
public class GameManager : MonoBehaviour
{
    static private GameManager _instancia;

    static public GameManager GetInstance()
    {
        if (_instancia == null)
        {
            // creamos un nuevo objeto llamado "_MiGameManager"
            GameObject go = new GameObject("GameManager");

            // anadimos el script "GameManager" al objeto
            go.AddComponent<GameManager>();
            _instancia = go.GetComponent<GameManager>();
            DontDestroyOnLoad(go);
        }

        // devolvemos la instancia
        // si no existia, en este punto ya la habra creado
        return _instancia;
    }


    Phase phase_ = Phase.COMMANDING;

    public Phase GetPhase() { return phase_; }
    public void SetPhase(Phase phase) { phase_ = phase; }


    // Constructor
    // Lo ocultamos el constructor para no poder crear nuevos objetos "sin control"
    protected GameManager() {}

}