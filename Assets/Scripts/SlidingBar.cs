using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingBar : MonoBehaviour
{
    public Transform bar;

    public bool sliding = false;

    protected float slideTime_;

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
    }

    public void UpdateSlidePosition (float t)
    {
        if (t <= slideTime_)
        {
            bar.localPosition = Vector3.Lerp(startPos, endPos, t / slideTime_);

            //timer += Time.deltaTime;
        }
        else
        {
            bar.localPosition = endPos;
            //sliding = false;
        }
    }

    public void StartSlide()
    {
        sliding = true;
        timer = 0;

        if (bar)
            bar.localPosition = startPos;
    }

    public void setSlideTime(float SlideTime)
    {
        slideTime_ = SlideTime;
    }

    public float getSlideTime()
    {
        return slideTime_;
    }
}
