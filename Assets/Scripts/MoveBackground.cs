using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.0f;
    [SerializeField]
    private float offset;

    private Vector2 startPosition;
    private float newXposition;

    float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        //offset = Mathf.Abs(startPosition.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetInstance().GetPhase() == Phase.ADVANCE || GameManager.GetInstance().GetPhase() == Phase.ENDLEVEL1) //Para Advance y EndLevel
        {
            newXposition = Mathf.Repeat(t * -moveSpeed, offset);

            transform.position = startPosition + Vector2.right * newXposition;

            t += Time.deltaTime;
        }
    }
}
