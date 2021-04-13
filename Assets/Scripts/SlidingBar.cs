using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingBar : MonoBehaviour
{
    public Transform bar;

    public bool sliding = false;

    public float slideTime = 2.0f;

    float timer = 0.0f;

    public float edgeOffset;

    Vector3 startPos;
    Vector3 endPos;

    private void Start()
    {
        float wHalf = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.extents.x - edgeOffset;

        startPos = new Vector3(-wHalf, 0, 0);
        endPos = new Vector3(wHalf, 0, 0);

        if(bar)
            bar.localPosition = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (sliding)
        {
            if (timer <= slideTime)
            {
                bar.localPosition = Vector3.Lerp(startPos, endPos, timer / slideTime);

                timer += Time.deltaTime;
            }
            else
            {
                bar.localPosition = endPos;
                sliding = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.M))
            StartSlide();
    }

    public void StartSlide()
    {
        sliding = true;
        timer = 0;

        if (bar)
            bar.localPosition = startPos;
    }
}
