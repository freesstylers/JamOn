using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Patrones
{
    class Patron
    {
        static float[] TiemposPosibles = {2.0f, 3.0f, 4.0f, 5.0f};

        static float[] Test2Notas0 = { 1.0f, 3.0f};
        static float[] Test2Notas1 = { 2.0f, 3.0f};

        static float[] Basico = {1.0f, 2.0f, 3.0f};
        static float[] Basico2 = { 1.0f, 2.0f, 2.5f };
        static float[] Basico3 = { 1f, 1.5f, 3f };

        static float[] Test4Notas0 = { 0.0f, 1.0f, 2.0f, 3.0f };
        static float[] Test4Notas1 = { 0.0f, 1.0f, 3.0f, 3.5f };
        static float[] Test4Notas2 = { 1.0f, 2.0f, 3.0f, 3.5f };
        static float[] Test4Notas3 = { 1.0f, 2.0f, 2.5f, 3.0f };

        static float[] Test5Notas0 = { 0.0f, 2.0f, 3.0f, 4.0f, 6.0f };
        static float[] Test5Notas1 = { 0.0f, 1.0f, 3.0f, 4.0f, 6.0f };
        static float[] Test5Notas2 = { 1.0f, 2.0f, 3.0f, 4.0f, 6.0f };
        static float[] Test5Notas3 = { 1.0f, 3.0f, 4.0f, 5.0f, 6.0f };

        public static float[][] Ataques2 = { Test2Notas0, Test2Notas1};
        public static float[][] Ataques3 = {Basico, Basico2, Basico3};
        public static float[][] Ataques4 = { Test4Notas0, Test5Notas1, Test5Notas2, Test5Notas3 };
        public static float[][] Ataques5 = { Test5Notas0, Test5Notas1, Test5Notas2, Test5Notas3 };

        public static float[][][] Ataques = { Ataques2, Ataques3, Ataques4, Ataques5 };
        
        public static float[] getArray (int tam)
        {
            float[] array = new float[tam];
            array = Ataques[tam - 2][Random.Range(0, Ataques[tam - 2].Length)];
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
