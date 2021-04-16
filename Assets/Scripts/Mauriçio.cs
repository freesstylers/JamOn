using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pair<T, U>
{
    public Pair() { }
    public Pair(T first, U second)
    {
        this.First = first;
        this.Second = second;
    }

    public T First { get; set; }
    public U Second { get; set; }
}

public class Mauriçio : MonoBehaviour
{
    [Header("UI")]
    public GameObject arrowL_;
    public GameObject arrowR_;
    public GameObject arrowU_;
    public GameObject arrowD_;
    public Text textPhase_;

    public Transform commandBar_;

    int level_ = 0;

    List<Pair<int, float>> arrowsMauricio_ = new List<Pair<int, float>>();
    List<float> playerPoints = new List<float>();
    [Header("Enemy control")]
    [SerializeField]
    EnemySpawner enemySpawner;

    float timer_;

    List<Pair<int, float>> arrowsMauricio_ = new List<Pair<int, float>>();

    [Header("Tiempos de cancion")]
    public float beats = 4.0f;
    public float bpm = 135.0f;
    float timePatron_ = 2.0f;

    int num_;
    int numleft_;
    bool decided_ = false;

    float[] actPatron_;

    float CommandTime;

    List<GameObject> arrowObjects = new List<GameObject>();

    //Cosas gestion de input
    float delayCommandingPlayer; //Tiempo entre Commanding y Player
    float delayPlayerBattle; //Tiempo que va a estar en Battle
    float delayTransitionPlayerBattle; //Tiempo que se queda en Battle sin empezar, para que las notas no se borren inmediatamente
    float delayBattleAdvance; //Tiempo que va a estar en Advance
    float delayAdvanceCommanding; //Tiempo que va a estar en Commanding, pero esperando

    float margin;

    int vocal = 0;
    int inputsDone = 0;

    bool test = false;

    bool TransitionPlayerToBattle = false;

    int[] patrones;
    int currentPatron = 0;

    Color barBackup;
    Color transparent = new Color(0, 0, 0, 0);

    private void Start()
    {
        bpm = GameManager.GetInstance().getBPM(level_);
        delayCommandingPlayer = -2.0f * (60.0f / bpm);
        delayPlayerBattle = -10.0f * (60.0f / bpm); ;
        delayBattleAdvance = -5.0f * (60.0f / bpm); ;
        delayAdvanceCommanding = -4.0f * (60.0f / bpm);
        delayTransitionPlayerBattle = -2.0f * (60.0f / bpm);

        margin = 0.3f * (60.0f / bpm);

        timePatron_ = beats * (60.0f / bpm);

        Debug.Log("Tiempo de patron: " + timePatron_);

        barBackup = commandBar_.GetChild(0).GetComponent<SpriteRenderer>().color;

        patrones = GameManager.GetInstance().getLevelPatrons(GameManager.GetInstance().getLevel()); //Con esto se sacan la lista de notas que tendrá cada patron del nivel
    }

    void Update()
    {
        if (!test && Input.GetKeyDown(KeyCode.M)) test = true;

        if (test)
        {
            if (currentPatron < patrones.Length)
            {
                Phase phase = GameManager.GetInstance().GetPhase();

                textPhase_.text = phase.ToString();

                timer_ += Time.deltaTime;

                if (((decided_ && phase == Phase.COMMANDING) || phase == Phase.PLAYER) && timer_ >= 0.0f)
                    commandBar_.gameObject.GetComponent<SlidingBar>().UpdateSlidePosition(timer_);

                switch (phase)
                {
                    case Phase.COMMANDING:
                        if (timer_ > 0.0f)
                        {
                            if (!decided_)
                            {
                                decided_ = true;
                                //actPatron_ = Patrones.Patron.Ataques1[Random.Range(0, 3)];
                                actPatron_ = Patrones.Patron.getArray(patrones[currentPatron]); //Con esto se saca un array del numero de notas que marque currentPatron
                                num_ = actPatron_.Length;
                                numleft_ = num_;

                                commandBar_.gameObject.GetComponent<SlidingBar>().setSlideTime(timePatron_);

                                commandBar_.gameObject.GetComponent<SlidingBar>().UpdateSlidePosition(timer_);
                            }
                            Command();
                        }
                        break;
                    case Phase.PLAYER:
                        if (decided_)
                            decided_ = false;
                        if (timer_ >= 0)
                            Player();
                        break;
                    case Phase.BATTLE:
                        if (timer_ > 0.0f)
                        {
                            timer_ = delayBattleAdvance;
                            enemySpawner.Kill();
                            GameManager.GetInstance().SetPhase(Phase.ADVANCE);
                        }
                        break;
                    case Phase.ADVANCE:
                        if (timer_ > 0.0f)
                        {
                            currentPatron++;
                            arrowsMauricio_.Clear();

                            commandBar_.GetChild(0).GetComponent<SpriteRenderer>().color = barBackup;

                            timer_ = delayAdvanceCommanding;
                            enemySpawner.Spawn();
                            GameManager.GetInstance().SetPhase(Phase.COMMANDING);
                        }
                        break;
                }
            }

            else
                Debug.Log("No more patrones");
        }
    }

    void Player()
    {
        if (timer_ < 0)
        {
            return;
        }

        if (timer_ < timePatron_ )
        {
            if (inputsDone < arrowsMauricio_.Count)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) //Si hay input
                {
                    Pair<int, float> p = new Pair<int, float>();

                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        p.First = 0;
                        p.Second = timer_;
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        p.First = 1;
                        p.Second = timer_;
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        p.First = 2;
                        p.Second = timer_;
                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        p.First = 3;
                        p.Second = timer_;
                    }

                    float distance = Mathf.Abs(p.Second - arrowsMauricio_[inputsDone].Second);

                    Debug.Log("Distancia: " + distance + " Margen: " + margin);
                    if (distance <= margin) //Está dentro
                    {
                        if (p.First == arrowsMauricio_[inputsDone].First) //Tecla correcta
                        {
                            Debug.Log("Ole");
                            arrowObjects[inputsDone].GetComponent<Animator>().SetTrigger("Acierto2");
                        }
                        else //Tecla erronea
                        {
                            Debug.Log("Tecla incorrecta");
                            arrowObjects[inputsDone].GetComponent<Animator>().SetTrigger("Fallo");

                        }
                    }
                    else //Fuera, y por tanto erronea
                    {
                        Debug.Log("Fuera de rango");
                        arrowObjects[inputsDone].GetComponent<Animator>().SetTrigger("Fallo");
                    }

            if (distance <= margin) //Está dentro
            {
                if (p.First == arrowsMauricio_[inputsDone].First) //Tecla correcta
                {
                    float points;
                    if (distance != 0.0f) points = 100.0f;
                    else points = (1.0f-(distance/margin)) * 100.0f;
                    GameManager.GetInstance().AddScore(level_, points);
                    Debug.Log("Ole");
                    inputsDone++;
                }

                else //Si no hay input
                {
                    if (timer_ > (arrowsMauricio_[inputsDone].Second + margin))
                    {
                        Debug.Log("No pulsaste a tiempo");
                        arrowObjects[inputsDone].GetComponent<Animator>().SetTrigger("Fallo");

                        //Error

                        inputsDone++;
                    }
                }
            }

        }
        else
        {
            ExitPlayerState();
        }
    }

    void ExitPlayerState()
    {
        commandBar_.GetChild(0).GetComponent<SpriteRenderer>().color = transparent;

        if (!TransitionPlayerToBattle)
        {
            TransitionPlayerToBattle = true;
            timer_ = delayTransitionPlayerBattle;
        }

        if (timer_ > 0.0f)
        {
            foreach (GameObject a in arrowObjects)
            {
                Destroy(a);
            }

            arrowObjects.Clear();

            inputsDone = 0;
            TransitionPlayerToBattle = false;
            timer_ = delayPlayerBattle;
            GameManager.GetInstance().SetPhase(Phase.BATTLE);
        }
        return;
    }

    void Command()
    {
        if (numleft_ > 0 && timer_ >= actPatron_[num_-numleft_] * (60.0f / bpm))
        {
            int aux = Random.Range(0, 4);
            GameObject arrow = new GameObject(); ;
            vocal = aux + 1;
            switch (aux)
            {
                case 0:
                    arrow = Instantiate(arrowU_, commandBar_);
                    arrow.transform.position = new Vector3(commandBar_.GetChild(0).transform.position.x, commandBar_.position.y, commandBar_.position.z);
                    break;
                case 1:
                    arrow = Instantiate(arrowD_, commandBar_);
                    arrow.transform.position = new Vector3(commandBar_.GetChild(0).transform.position.x, commandBar_.position.y, commandBar_.position.z);
                    break;
                case 2:
                    arrow = Instantiate(arrowL_, commandBar_);
                    arrow.transform.position = new Vector3(commandBar_.GetChild(0).transform.position.x, commandBar_.position.y, commandBar_.position.z);
                    break;
                case 3:
                    arrow = Instantiate(arrowR_, commandBar_);
                    arrow.transform.position = new Vector3(commandBar_.GetChild(0).transform.position.x, commandBar_.position.y, commandBar_.position.z);
                    break;
            }
            arrowsMauricio_.Add(new Pair<int, float>(aux, timer_));
            arrowObjects.Add(arrow);
            //timer_ = 0;
            numleft_--;

        }

        if (timer_ >= timePatron_)
        {
            GameManager.GetInstance().SetPhase(Phase.PLAYER);
            timer_ = delayCommandingPlayer; //Reset para poder hacer inputs a cholon
            commandBar_.gameObject.GetComponent<SlidingBar>().UpdateSlidePosition(timePatron_);
            vocal = 0;
        }
    }
    
    public int getVocal() { return vocal; }
}

