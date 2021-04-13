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
    enum Phase { COMMANDING, PLAYER, BATTLE }

    public GameObject arrowL_;
    public GameObject arrowR_;
    public GameObject arrowU_;
    public GameObject arrowD_;
    public Text textPhase_;
    public int bpm_;

    public Transform commandBar_;

    float timer_;

    List<Pair<int, float>> arrowsMauricio_ = new List<Pair<int, float>>();
    List<Pair<int, float>> arrowsPlayer_ = new List<Pair<int, float>>();

    Phase phase_ = Phase.COMMANDING;
    int num_;
    int numleft_;
    bool decided_ = false;
    public float offSet_;

    float[] actPatron_;

    void Update()
    {
        textPhase_.text = phase_.ToString();
        switch(phase_)
        {
            case Phase.COMMANDING:
                if(!decided_)
                {
                    decided_ = true;
                    actPatron_ = Patrones.Patron.Ataques1[Random.Range(0, 3)];
                    num_ = actPatron_.Length;
                    numleft_ = num_;
                }
                Command();
                break;
            case Phase.PLAYER:
                Player();
                break;
            case Phase.BATTLE:

                break;
        }
    }

    void Player()
    {
        timer_ += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            numleft_--;
            arrowsPlayer_.Add(new Pair<int, float>(0, timer_));
        } 
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            numleft_--;
            arrowsPlayer_.Add(new Pair<int, float>(1, timer_));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            numleft_--;
            arrowsPlayer_.Add(new Pair<int, float>(2, timer_));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            numleft_--;
            arrowsPlayer_.Add(new Pair<int, float>(3, timer_));
        }
        if (numleft_ == 0) phase_ = Phase.BATTLE;
    }

    void Command()
    {
        timer_ += Time.deltaTime;
        if (timer_ > actPatron_[num_-numleft_])
        {
            int aux = Random.Range(0, 4);
            float ini = CalculateExt(num_);
            GameObject arrow;
            switch (aux)
            {
                case 0:
                    arrow = Instantiate(arrowU_, commandBar_);
                    arrow.transform.position = new Vector3(ini + (num_-numleft_)* offSet_, commandBar_.position.y, commandBar_.position.z);
                    break;
                case 1:
                    arrow = Instantiate(arrowD_, commandBar_);
                    arrow.transform.position = new Vector3(ini + (num_ - numleft_) * offSet_, commandBar_.position.y, commandBar_.position.z);
                    break;
                case 2:
                    arrow = Instantiate(arrowL_, commandBar_);
                    arrow.transform.position = new Vector3(ini + (num_ - numleft_) * offSet_, commandBar_.position.y, commandBar_.position.z);
                    break;
                case 3:
                    arrow = Instantiate(arrowR_, commandBar_);
                    arrow.transform.position = new Vector3(ini + (num_ - numleft_) * offSet_, commandBar_.position.y, commandBar_.position.z);
                    break;
            }
            arrowsMauricio_.Add(new Pair<int, float>(aux, timer_));
            timer_ = 0;
            numleft_--;
            if (numleft_ == 0)
            {
                phase_ = Phase.PLAYER;
                numleft_ = num_;
            }
        }
    }

    float CalculateExt(int num)
    {
        return -((num-1)*offSet_)/2;
    }
    
}

