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
    //enum Phase { COMMANDING, PLAYER, BATTLE }

    public GameObject arrowL_;
    public GameObject arrowR_;
    public GameObject arrowU_;
    public GameObject arrowD_;
    public Text textPhase_;

    public Transform commandBar_;

    float timer_;

    List<Pair<int, float>> arrowsMauricio_ = new List<Pair<int, float>>();
    List<Pair<int, float>> arrowsPlayer_ = new List<Pair<int, float>>();

    //Phase phase_ = Phase.COMMANDING;
    int num_;
    int numleft_;
    bool decided_ = false;

    float[] actPatron_;

    //Cpsas gestion de input
    float delay = -0.5f;
    float margin = 0.3f;

    int fallos = 0;
    int inputsDone = 0;

    void Update()
    {
        Phase phase = GameManager.GetInstance().GetPhase();
        
        textPhase_.text = phase.ToString();

        timer_ += Time.deltaTime;

        if (timer_ >= 0)
            commandBar_.gameObject.GetComponent<SlidingBar>().UpdateSlidePosition(timer_);

        switch (phase)
        {
            case Phase.COMMANDING:
                if(!decided_)
                {
                    decided_ = true;
                    //actPatron_ = Patrones.Patron.Ataques1[Random.Range(0, 3)];
                    actPatron_ = Patrones.Patron.Ataques1[3];
                    num_ = actPatron_.Length;
                    numleft_ = num_;

                    commandBar_.gameObject.GetComponent<SlidingBar>().setSlideTime(2.0f);
                }
                Command();
                break;
            case Phase.PLAYER:
                if (timer_ >= 0)
                    Player();
                break;
            case Phase.BATTLE:
                //GameManager.GetInstance().SetPhase(Phase.ADVANCE);
                break;
            case Phase.ADVANCE:
                break;
        }
    }

    void Player()
    {
        if (timer_ < 0)
        {
            return;
        }

        if (inputsDone >= arrowsMauricio_.Count)
        {
            GameManager.GetInstance().SetPhase(Phase.BATTLE);
            return;
        }

        if (timer_ < 2.0f)
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

            if (distance <= margin) //Está dentro
            {
                if (p.First == arrowsMauricio_[inputsDone].First) //Tecla correcta
                {
                    Debug.Log("Ole");
                }
                else //Tecla erronea
                {
                    Debug.Log("Eres mas tonto que Grossi - Tecla incorrecta");
                }
            }
            else //Fuera, y por tanto erronea
            {
                Debug.Log("Eres mas tonto que Grossi - Tecla fuera de rango");
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                inputsDone++;
            }
        }
        else
        {
            GameManager.GetInstance().SetPhase(Phase.BATTLE);
        }
    }

    void Command()
    {
        if (numleft_ > 0 && timer_ >= actPatron_[num_-numleft_])
        {
            int aux = Random.Range(0, 4);
            GameObject arrow;
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
            //timer_ = 0;
            numleft_--;
        }

        if (timer_ >= 2.0f)
        {
            GameManager.GetInstance().SetPhase(Phase.PLAYER);
            timer_ = delay; //Reset para poder hacer inputs a cholon
            commandBar_.gameObject.GetComponent<SlidingBar>().UpdateSlidePosition(2.0f);
        }
    }
    /*
    void compareInputToOrder()
    {
        //Inicializacion y cosas auxiliares
        bool[] alreadyChecked = new bool[arrowsPlayer_.Count];

        for (int k = 0; k < arrowsPlayer_.Count; k++)
        {
            alreadyChecked[k] = false;
        }

        for (int i = 0; i < arrowsMauricio_.Count; i++)
        {
            //Compruebo inputs con margen dado en parametro (0.3 como inicial)
            for (int j = 0; j < arrowsPlayer_.Count; j++)
            {
                if (alreadyChecked[j] != true) //Si ya se ha marcado como fallada, da igual mirarla o no
                {
                    float distance = Mathf.Abs(arrowsPlayer_[j].Second - arrowsMauricio_[i].Second);

                    if (distance <= margin) //Está dentro
                    {
                        if (arrowsPlayer_[j].First == arrowsMauricio_[i].First) //Tecla correcta
                        {
                            Pair<Pair<int, float>, Pair<float, int>> pair = new Pair<Pair<int, float>, Pair<float, int>>();
                            pair.First = arrowsPlayer_[j];
                            pair.Second = new Pair<float, int>();
                            pair.Second.First = distance;
                            pair.Second.Second = j;
                            aux.Add(pair);
                        }
                        else //Tecla erronea
                        {
                            if (alreadyChecked[j] != true) //Si ya es true, no hace falta mirar mas
                                checkIfSuitableForNextOne(ref alreadyChecked, arrowsPlayer_[j], arrowsMauricio_[i], j, i);
                        }
                    }
                    else //Está fuera
                    {
                        if (alreadyChecked[j] != true) //Si ya es true, no hace falta mirar mas
                            checkIfSuitableForNextOne(ref alreadyChecked, arrowsPlayer_[j], arrowsMauricio_[i], j, i);
                    }
                }
            }

            if (aux.Count > 0)
            {
                int best = -1;
                float minDistance = Mathf.Infinity;

                //Cuando ya se han recorrido todas, se recorren las posibles buscando la distancia minima
                for (int l = 0; l < aux.Count; l++)
                {
                    if (aux[l].Second.First < minDistance)
                    {
                        minDistance = aux[l].Second.First;
                        best = l;
                    }
                }

                for (int z = 0; z < best; z++) //Previas a la que tiene distancia minima
                {
                    alreadyChecked[aux[z].Second.Second] = true;

                    fallos++;
                }

                for (int x = best + 1; x < aux.Count; x++) //Siguientes a la distancia minima //No se si el +1 va ahi
                {
                    if (alreadyChecked[aux[x].Second.Second] != true) //Si ya es true, no hace falta mirar mas
                        checkIfSuitableForNextOne(ref alreadyChecked, aux[x].First, arrowsMauricio_[i], aux[x].Second.Second, i);
                }

                //Sumar puntos por el acierto (FORMULA DE CALCULO DE PUNTOS)
                alreadyChecked[aux[best].Second.Second] = true;
                //NO FALLO

                aux.Clear(); //Para resetear de cara a la siguiente iteración
            }
        }
    }*/

    /*
    void checkIfSuitableForNextOne(ref bool[] alreadyChecked, Pair<int, float> player, Pair<int, float> Mauriçio, int itPlayer, int itMauriçio)
    {
        if (itMauriçio == arrowsMauricio_.Count - 1) //Si ya es la ultima nota, error
        {
            alreadyChecked[itPlayer] = true;
            fallos++;
        }
        else
        {
            float distanceAux = Mathf.Abs(arrowsPlayer_[itPlayer].Second - arrowsMauricio_[itMauriçio + 1].Second);

            if (distanceAux > margin) //No puede contarse para la siguiente nota tampoco, asi que a contarlo como fallo
            {
                alreadyChecked[itPlayer] = true;
                fallos++;
            }
        }
    }

    void checkAlreadyChecked(ref bool[] array, int valueToCheck)
    {
        if (array[valueToCheck] != true)
        {
            array[valueToCheck] = true;

            fallos++;
        }
    }
    */
    /*
    float CalculateExt(int num)
    {
        return -((num-1)*offSet_)/2;
    }*/
    
}

