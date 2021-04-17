using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCount : MonoBehaviour
{
    public Text txt;
    
    int counter = 0;

    private IEnumerator coroutine = null;

    public float duration = 0.5f;

    public void StartCounting(int maxPoints)
    {
        if(coroutine != null)
            StopCoroutine(coroutine);

        if (!txt) return;

        counter = 0;

        coroutine = CountTo(maxPoints);

        StartCoroutine(coroutine);
    }

    IEnumerator CountTo(int target)
    {
        int start = counter;
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            counter = (int)Mathf.Lerp(start, target, progress);

            txt.text = counter.ToString("D9");

            yield return null;
        }

        counter = target;
        txt.text = counter.ToString();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.M))
        //    StartCounting(Random.Range(0, 100000));
    }
}
