using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cinematica : MonoBehaviour
{
    public AudioClip[] audios;
    public Sprite[] images;

    public int[] textToChangeImage = { 0,1 };
    public int currentImage = 0;

    public Text screenText;
    public Image screenImage;

    public Material scaleGray;

    static string text1 = "Esta es la historia de una secta satánica tó refacherita";
    static string text2 = "Jose jose jose jose jose";
    static string text3 = "JOSE JOSE JOSE JOSE JOSE";
    
    string[] texts = { text1, text2, text3 };

    float t = 0.0f;
    //float tText = 0.0f;

    int i = 0;
    int currentText = 0;

    float delayLetra = 0.15f;
    float delayEntreTextos = -0.5f;

    AudioSource mauriçioHablame;

    // Start is called before the first frame update
    void Start()
    {
        mauriçioHablame = gameObject.GetComponent<AudioSource>();
        //screenImage.material = scaleGray;
        screenImage.sprite = images[currentImage];
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if (currentText < texts.Length)
            UpdateText();

        if (currentImage < images.Length && currentImage < textToChangeImage.Length)
            UpdateImage(currentText);
    }

    void UpdateImage(int text)
    {
        if (text == textToChangeImage[currentImage])
        {
            currentImage++;
            screenImage.sprite = images[currentImage];
        }
    }

    void UpdateText()
    {
        if (t > delayLetra)
        {
            if (currentText < texts.Length)
            {
                if (i < texts[currentText].Length)
                {
                    screenText.text += texts[currentText][i];
                    i++;

                    if (i % 3 == 0)
                    {
                        mauriçioHablame.clip = audios[Random.Range(0, audios.Length)];
                        mauriçioHablame.Play();
                    }

                    t = 0.0f;
                }
                else
                {
                    currentText++;

                    i = 0;

                    if (currentText < texts.Length)
                        screenText.text = "";

                    t = delayEntreTextos;
                }
            }
        }
    }
}
