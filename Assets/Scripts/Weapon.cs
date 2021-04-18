using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    SpriteRenderer sprite;
    bool attacking = false;

    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetInstance().paused) return;

        sprite.sortingOrder = GetComponentInParent<SpriteRenderer>().sortingOrder;    
        
        if (GameManager.GetInstance().GetPhase() == Phase.PLAYER && !attacking)
        {
            attacking = true;
            AttackAnimation();
        }
    }

    void AttackAnimation()
    {
        LeanTween.rotate(gameObject, new Vector3(0, 0, -60), Random.Range(0.3f, 0.8f)).setLoopPingPong(Random.Range(1, 4)).setOnComplete(endAttack);
    }

    void endAttack()
    {
        attacking = false;
    }

}
