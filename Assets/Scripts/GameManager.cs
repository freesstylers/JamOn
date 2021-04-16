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
    Phase phase_ = Phase.COMMANDING;

    float[] scores_ = { 0.0f, 0.0f, 0.0f };
    int[] bpm_ = { 135, 135, 135 };

    public void AddScore(int level, float points) { scores_[level] += points; }
    public float GetFinalScore() {
        float res = scores_[0] + scores_[1] + scores_[2];
        if (PlayerPrefs.GetFloat("bestScore") < res) PlayerPrefs.SetFloat("bestScore", res);
        return res; 
    }

    public Phase GetPhase() { return phase_; }
    public void SetPhase(Phase phase) { phase_ = phase; }

    public int getBPM(int level) { return bpm_[level]; }

    // Constructor
    // Lo ocultamos el constructor para no poder crear nuevos objetos "sin control"
    protected GameManager() {}

}