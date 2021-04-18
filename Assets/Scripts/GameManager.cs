using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum Phase { COMMANDING, PLAYER, BATTLE, ADVANCE, ENDLEVEL1, ENDLEVEL2}

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



    bool lose_ = false;

    public bool GetLose() { 
        return lose_; 
    }
    public void SetLose(bool lose) { lose_ = lose; }

    protected int BPM_;
    Phase phase_ = Phase.ADVANCE;

    float patronPerformance = 0.0f;
    float[] scores_ = { 0.0f, 0.0f, 0.0f };
    int[] bpm_ = { 135, 125, 110 };

    int currentPatron = -1;
    public void AddScore(int level, float points) { scores_[level] += points; }
    public float GetFinalScore() {
        float res = scores_[0] + scores_[1] + scores_[2];
        if (PlayerPrefs.GetFloat("bestScore") < res) PlayerPrefs.SetFloat("bestScore", res);
        scores_[0] = 0.0f;
        scores_[1] = 0.0f;
        scores_[2] = 0.0f;
        return res; 
    }
    public float GetLevelScore(int level) { return scores_[level]; }

    public Phase GetPhase() { return phase_; }
    public void SetPhase(Phase phase) { phase_ = phase; }

    public int getBPM(int level) { return bpm_[level]; }

    public void addBPM(int level, int bpm)
    {
        bpm_[level] += bpm;
    }

    // Constructor
    // Lo ocultamos el constructor para no poder crear nuevos objetos "sin control"
    protected GameManager() {}

    static public int[] level1 = { 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4};
    static public int[] level2 = { 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 5, 5, 5};
    static public int[] level3 = { 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6};

    static public int[][] levels = { level1, level2, level3 };

    public string[] levelScenes = { "Level1", "Level2", "Level3"};

    protected int level_ = 0; //0,1,2

    protected int cinematica = 0; //0,1,2...

    public void setCinematica (int value)
    {
        cinematica = value;
    }

    public int getCinematica()
    {
        return cinematica;
    }

    protected int combo_ = 1;
    public int GetCombo() { return combo_; }
    public void AddCombo() { if (combo_ < 10) combo_++; }
    public void ResetCombo() { combo_ = 1; }

    public float GetPatronPerformance() { return patronPerformance; }
    public void SetPatronPerformance(float perf) {
        if (patronPerformance == 0.0f) patronPerformance = perf;
        else if (perf == 0.0f) patronPerformance = 0.0f;
        else
        {
            patronPerformance = (patronPerformance + perf) / 2;
        }
    }

    public int[] getLevelPatrons (int level) { return levels[level];  }

    public int getLevel()   {   return level_;    }
    public void advanceLevel()   { 
        level_++;
        bpm_[0] = 135;
        bpm_[1] = 125;
        bpm_[2] = 110;
    }

    public void setCurrentPatron(int value) { currentPatron = value; }

    public bool patronsLeft()
    {
        if (currentPatron < levels[level_].Length)
            return true;
        else
            return false;
    }

    public string getLevelScene(int level)
    {
        return levelScenes[level];
    }

    protected bool miauMode = true;

    public void setMiauMode(bool value)
    {
        miauMode = value;
        PlayerPrefs.SetInt("MiauMode", value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public bool getMiauMode()
    {
        return miauMode;
    }

    protected bool discoMode = true;

    public void setDiscoMode(bool value)
    {
        discoMode = value;
        PlayerPrefs.SetInt("DiscoMode", value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public bool getDiscoMode()
    {
        return discoMode;
    }

    public AudioMixer mixer;

    private void SetValues()
    {
        mixer = Resources.Load<AudioMixer>("Mixer");

        miauMode = PlayerPrefs.GetInt("MiauMode", 0) == 1 ? true : false;
        discoMode = PlayerPrefs.GetInt("DiscoMode", 0) == 1 ? true : false;

        int w = PlayerPrefs.GetInt("ScreenWidth", Screen.currentResolution.width);

        Screen.SetResolution(w, PlayerPrefs.GetInt("ScreenHeight", Screen.currentResolution.height), PlayerPrefs.GetInt("FullScreen", Screen.fullScreen ? 1 : 0) == 1, PlayerPrefs.GetInt("ScreenRefresh", Screen.currentResolution.refreshRate));

        if (mixer)
        {
            float mus = PlayerPrefs.GetFloat("MusicVol", 0.75f);

            mixer.SetFloat("MusicVol", Mathf.Log10(mus) * 20);
            mixer.SetFloat("SFXVol", Mathf.Log10(PlayerPrefs.GetFloat("SFXVol", 0.75f)) * 20);
        }
    }

    private void Start()
    {
        _instancia.SetValues();
    }

    Color[] colors = new Color[256];

    void ChangeColors()
    {
        for (int i = 0; i < 255; i++)
        {
            colors[i] = Random.ColorHSV();
        }
    }

    public Color[] getColors()
    {
        return colors;
    }

}