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

    protected int BPM_;
    Phase phase_ = Phase.ADVANCE;

    public Phase GetPhase() { return phase_; }
    public void SetPhase(Phase phase) { phase_ = phase; }

    public int getBPM() { return BPM_; }
    public void SetBPM(int BPM) { BPM_ = BPM; }

    // Constructor
    // Lo ocultamos el constructor para no poder crear nuevos objetos "sin control"
    protected GameManager() {}

    static public int[] level1 = { 2, 3, 4, 5};

    static public int[][] levels = { level1 };

    protected int level_ = 0; //0,1,2

    public int[] getLevelPatrons (int level) { return levels[level];  }

    public int getLevel()   {   return level_;    }
    public void advanceLevel()   { level_++;    }

}