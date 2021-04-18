using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cinematica : MonoBehaviour
{
    public AudioClip[] audiosFish;
    public AudioClip[] audiosMiau;

    public Sprite[] ImagesToChangeText1;
    public Sprite[] ImagesToChangeText2;
    public Sprite[] ImagesToChangeText3;
    public Sprite[] ImagesToChangeText4;

    Sprite[][] Images;

    int textToChangeImage = 2;
    public int currentImage = 0;

    public Text screenText;
    public Image screenImage;

    public Material scaleGray;

    static string c1_text1 = "Esta es la historia de un antiguo culto, los adoradores de...";
    static string c1_text2 = "\"El Gran Mauricius\", que resulta ser el pez que tienes delante";
    static string c1_text3 = "El deber de mis esbirros ahora es reclutar nuevos adeptos";
    static string c1_text4 = "Así podremos llevar a cabo el ritual del nacimiento";
    static string c1_text5 = "Para ello, deberán escoltar al feto allá donde vayan";
    static string c1_text6 = "Si siguen mis indicaciones, no habrá quien pueda detenernos...";
    
    static string c2_text1 = "Magnífico. Hemos conseguido todas las almas necesarias para llevar acabo el ritual";
    static string c2_text2 = "El siguiente paso es recolectar toda la sangre posible";
    static string c2_text3 = "Estoy seguro de que encontraremos muchos alegres donantes por el camino";
    static string c2_text4 = "Todo el planeta pagará por la terrible ofensa cometida a Mauricius";
    static string c2_text5 = "Los del piso de arriba debieron pensárselo dos veces antes de...";
    static string c2_text6 = "ponerse a mover muebles en plena hora de la siesta...";

    static string c3_text1 = "Ya está todo listo para llevar a cabo \"El Nacimiento\"";
    static string c3_text2 = "Cuando demos a luz al feto de la bestia primigénea, todo será erradicado del universo";
    static string c3_text3 = "No hay esperanza para aquellos que osan molestar ligeramente a Mauricius";
    static string c3_text4 = "¡Que comience el ritual!";
    
    static string c4_text1 = "Bueno ya hemos llegado a Las Vegas";
    static string c4_text2 = "Ahora que mi hijo ya ha nacido";
    static string c4_text3 = "Por fin podré celebrar decentemente el día de llevar a tu hijo al trabajo";
    static string c4_text4 = "THE END";

    static string[] textsCinematica0 = { c1_text1, c1_text2, c1_text3, c1_text4, c1_text5, c1_text6 };
    static string[] textsCinematica1 = { c2_text1, c2_text2, c2_text3, c2_text4, c2_text5, c2_text6 };
    static string[] textsCinematica2 = { c3_text1, c3_text2, c3_text3, c3_text4};
    static string[] textsCinematica3 = { c4_text1, c4_text2, c4_text3, c4_text4};
    
    string[][] cinematicas = { textsCinematica0, textsCinematica1, textsCinematica2, textsCinematica3 };

    string[] texts;

    float t = 0.0f;
    //float tText = 0.0f;

    int i = 0;
    int currentText = 0;

    public float delayLetra = 0.015f;
    float delayEntreTextos = -0.75f;

    bool betweenTexts = false;

    AudioSource mauriçioHablame;

    bool changingScene = false;

    // Start is called before the first frame update
    void Awake()
    {
        mauriçioHablame = gameObject.GetComponent<AudioSource>();
        screenImage.material = scaleGray;

        Images = new Sprite[][] { ImagesToChangeText1, ImagesToChangeText2, ImagesToChangeText3, ImagesToChangeText4 };

        screenImage.sprite = Images[GameManager.GetInstance().getCinematica()][currentImage];

        texts = cinematicas[GameManager.GetInstance().getCinematica()];

        if (GameManager.GetInstance().getMiauMode())
            MiauMode();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if(betweenTexts && t >= 0)
        {
            if (currentImage < Images.Length && currentImage < textToChangeImage)
                UpdateImage(currentText);

            betweenTexts = false;

            if (currentText < texts.Length)
                screenText.text = "";
        }

        if (currentText < texts.Length)
            UpdateText();
        
        else if (!changingScene)
        {
            changingScene = true;

            if (GameManager.GetInstance().getCinematica() < 3)
            {
                GameManager.GetInstance().setCinematica(GameManager.GetInstance().getCinematica() + 1);
                SceneManager.LoadSceneAsync(GameManager.GetInstance().getLevelScene(GameManager.GetInstance().getLevel()));
            }
            else
                SceneManager.LoadSceneAsync("LevelEnd");
            return;
        }
    }

    void UpdateImage(int text)
    {
        if (text == textToChangeImage)
        {
            currentImage++;
            screenImage.sprite = Images[GameManager.GetInstance().getCinematica()][currentImage/2 + 1];
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
                        if (GameManager.GetInstance().getMiauMode())
                        {
                            mauriçioHablame.clip = audiosMiau[Random.Range(0, audiosMiau.Length)];
                        }
                        else
                        {
                            mauriçioHablame.clip = audiosFish[Random.Range(0, audiosFish.Length)];
                        }

                        mauriçioHablame.Play();
                    }

                    t = 0.0f;
                }
                else
                {
                    currentText++;

                    i = 0;

                    betweenTexts = true;

                    t = delayEntreTextos;
                }
            }
        }
    }

    void MiauMode()
    {
        for (int i = 0; i < texts.Length; i++) //Para cada texto
        {
            string[] words = texts[i].Split(' ');

            string fin = "";

            for (int j = 0; j < words.Length; j++)
            {
                fin += "Miau ";
            }

            texts[i] = fin;
        }
    }
}
