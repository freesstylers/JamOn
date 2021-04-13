using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mauriçio : MonoBehaviour
{
    enum Phase { COMMANDING, PLAYER, BATTLE }

    public GameObject arrowL_;
    public GameObject arrowR_;
    public GameObject arrowU_;
    public GameObject arrowD_;
    public int bpm_;

    public Transform commandBar_;

    float timer_;

    Phase phase_ = Phase.COMMANDING;
    int num_;
    int numleft_;
    bool decided_ = false;
    public float offSet_;

    void Update()
    {
        switch(phase_)
        {
            case Phase.COMMANDING:
                if(!decided_)
                {
                    num_ = Random.Range(1, 6);
                    numleft_ = num_;
                    decided_ = true;
                }
                Command();
                break;
            case Phase.PLAYER:

                break;
            case Phase.BATTLE:

                break;
        }
    }

    void Player()
    {

    }

    void Command()
    {
        timer_ += Time.deltaTime;
        if (timer_ > (60000 / bpm_) / 1000)
        {
            int aux = Random.Range(0, 4);
            float ini = CalculateExt(num_);
            GameObject arrow;
            switch (aux)
            {
                case 0:
                    arrow = Instantiate(arrowU_, commandBar_);
                    arrow.transform.position = new Vector3(ini + (num_-numleft_)* offSet_, commandBar_.position.y, commandBar_.position.z);
                    arrow.GetComponent<Arrow>().mauriçio_ = this;
                    break;
                case 1:
                    arrow = Instantiate(arrowD_, commandBar_);
                    arrow.transform.position = new Vector3(ini + (num_ - numleft_) * offSet_, commandBar_.position.y, commandBar_.position.z);
                    arrow.GetComponent<Arrow>().mauriçio_ = this;
                    break;
                case 2:
                    arrow = Instantiate(arrowL_, commandBar_);
                    arrow.transform.position = new Vector3(ini + (num_ - numleft_) * offSet_, commandBar_.position.y, commandBar_.position.z);
                    arrow.GetComponent<Arrow>().mauriçio_ = this;
                    break;
                case 3:
                    arrow = Instantiate(arrowR_, commandBar_);
                    arrow.transform.position = new Vector3(ini + (num_ - numleft_) * offSet_, commandBar_.position.y, commandBar_.position.z);
                    arrow.GetComponent<Arrow>().mauriçio_ = this;
                    break;
            }
            timer_ = 0;
            numleft_--;
            if (numleft_ == 0) phase_ = Phase.PLAYER;
        }
    }

    float CalculateExt(int num)
    {
        return -((num-1)*offSet_)/2;
    }
    
}
