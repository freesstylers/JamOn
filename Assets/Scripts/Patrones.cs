using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Patrones
{
    class Patron
    {
        static float[] TiemposPosibles = {2.0f, 3.0f, 4.0f, 5.0f};

        static float[] Basico = {0.0f, 2.0f, 3.0f};
        static float[] Basico2 = { 0.3f, 0.4f, 1.0f };
        static float[] Basico3 = { 1f, 1.5f, 1.7f };
        static float[] Basico4 = { 0.57f,  1.14f, 1.71f };

        public static float[][] Ataques1 = {Basico, Basico2, Basico3, Basico4 };
        
        public static float[] getArray (int tam)
        {
            float[] array = new float[tam];
            array = Ataques1[Random.Range(0, Ataques1.Length)];
            return array;
        }
        public static Pair<float[], float> makePair(float[] array, float value)
        {
            Pair<float[], float> test = new Pair<float[], float>();
            int tam = Random.Range(2, 5);
            test.First = new float[tam];

            test.First = getArray(tam);

            test.Second = Random.Range(0, TiemposPosibles.Length);

            return test;
        }
    }
}
