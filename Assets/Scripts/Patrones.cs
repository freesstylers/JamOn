using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Patrones
{
    class Patron
    {
        static float[] TiemposPosibles = {2.0f, 3.0f, 4.0f, 5.0f};

        static float[] p_2_0 = { 1.0f, 2.0f };
        static float[] p_2_1 = { 1.0f, 3.0f };
        static float[] p_2_2 = { 1.0f, 3.5f };
        static float[] p_2_3 = { 2.0f, 3.0f };
        static float[] p_2_4 = { 2.0f, 3.5f };
        static float[] p_2_5 = { 3.0f, 3.5f };

        static float[] p_3_0 = { 1.00f, 1.50f, 2.00f };
        static float[] p_3_1 = { 1.00f, 1.50f, 2.50f };
        static float[] p_3_2 = { 1.00f, 1.50f, 3.00f };
        static float[] p_3_3 = { 1.00f, 1.50f, 3.50f };
        static float[] p_3_4 = { 1.00f, 1.50f, 3.50f };
        static float[] p_3_5 = { 1.00f, 2.00f, 2.50f };
        static float[] p_3_6 = { 1.00f, 2.00f, 3.00f };
        static float[] p_3_7 = { 1.00f, 2.00f, 3.50f };
        static float[] p_3_8 = { 1.00f, 2.00f, 3.50f };
        static float[] p_3_9 = { 1.00f, 2.50f, 3.00f };
        static float[] p_3_10 = { 1.00f, 2.50f, 3.50f };
        static float[] p_3_11 = { 1.00f, 2.50f, 3.50f };
        static float[] p_3_12 = { 1.00f, 3.00f, 3.50f };
        static float[] p_3_13 = { 1.00f, 3.00f, 3.50f };
        static float[] p_3_14 = { 1.00f, 3.00f, 3.50f };
        static float[] p_3_15 = { 1.50f, 2.50f, 3.00f };
        static float[] p_3_16 = { 1.50f, 2.50f, 3.50f };
        static float[] p_3_17 = { 1.50f, 2.50f, 3.50f };
        static float[] p_3_18 = { 1.50f, 3.00f, 3.50f };
        static float[] p_3_19 = { 1.50f, 3.00f, 3.50f };
        static float[] p_3_20 = { 1.50f, 3.00f, 3.50f };
        static float[] p_3_21 = { 2.00f, 3.00f, 3.50f };
        static float[] p_3_22 = { 2.00f, 3.00f, 3.50f };
        static float[] p_3_23 = { 2.00f, 3.00f, 3.50f };
        static float[] p_3_24 = { 2.50f, 3.00f, 3.50f };

        static float[] p_4_0 = { 1.00f, 1.50f, 2.00f, 2.50f };
        static float[] p_4_1 = { 1.00f, 1.50f, 2.00f, 3.00f };
        static float[] p_4_2 = { 1.00f, 1.50f, 2.00f, 3.50f };
        static float[] p_4_3 = { 1.00f, 1.50f, 2.00f, 3.50f };
        static float[] p_4_4 = { 1.00f, 1.50f, 2.50f, 3.00f };
        static float[] p_4_5 = { 1.00f, 1.50f, 2.50f, 3.50f };
        static float[] p_4_6 = { 1.00f, 1.50f, 2.50f, 3.50f };
        static float[] p_4_7 = { 1.00f, 1.50f, 3.00f, 3.50f };
        static float[] p_4_8 = { 1.00f, 1.50f, 3.00f, 3.50f };
        static float[] p_4_9 = { 1.00f, 1.50f, 3.00f, 3.50f };
        static float[] p_4_10 = { 1.00f, 2.00f, 3.00f, 3.50f };
        static float[] p_4_11 = { 1.00f, 2.00f, 3.00f, 3.50f };
        static float[] p_4_12 = { 1.00f, 2.00f, 3.00f, 3.50f };
        static float[] p_4_13 = { 1.00f, 2.50f, 3.00f, 3.50f };
        static float[] p_4_14 = { 1.50f, 2.50f, 3.00f, 3.50f };

        static float[] p_5_0 = { 0.50f, 1.50f, 2.00f, 2.50f, 3.00f };
        static float[] p_5_1 = { 0.50f, 1.50f, 2.00f, 2.50f, 3.50f };
        static float[] p_5_2 = { 0.50f, 1.50f, 2.00f, 2.50f, 3.50f };
        static float[] p_5_3 = { 0.50f, 1.50f, 2.00f, 3.00f, 3.50f };
        static float[] p_5_4 = { 0.50f, 1.50f, 2.00f, 3.00f, 3.50f };
        static float[] p_5_5 = { 0.50f, 1.50f, 2.00f, 3.00f, 3.50f };
        static float[] p_5_6 = { 0.50f, 1.50f, 2.50f, 3.00f, 3.50f };
        static float[] p_5_7 = { 1.00f, 1.50f, 2.00f, 2.50f, 3.00f };
        static float[] p_5_8 = { 1.00f, 1.50f, 2.00f, 2.50f, 3.50f };
        static float[] p_5_9 = { 1.00f, 1.50f, 2.00f, 2.50f, 3.50f };
        static float[] p_5_10 = { 1.00f, 1.50f, 2.00f, 3.00f, 3.50f };
        static float[] p_5_11 = { 1.00f, 1.50f, 2.00f, 3.00f, 3.50f };
        static float[] p_5_12 = { 1.00f, 1.50f, 2.00f, 3.00f, 3.50f };
        static float[] p_5_13 = { 1.00f, 1.50f, 2.50f, 3.00f, 3.50f };

        static float[] p_6_0 = { 0.50f, 0.90f, 1.30f, 1.70f, 2.10f, 2.50f };
        static float[] p_6_1 = { 0.50f, 0.90f, 1.30f, 1.70f, 2.10f, 2.90f };
        static float[] p_6_2 = { 0.50f, 0.90f, 1.30f, 1.70f, 2.10f, 3.30f };
        static float[] p_6_3 = { 0.50f, 0.90f, 1.30f, 1.70f, 2.10f, 3.70f };
        static float[] p_6_4 = { 0.50f, 0.90f, 1.30f, 1.70f, 2.50f, 2.90f };
        static float[] p_6_5 = { 0.50f, 0.90f, 1.30f, 1.70f, 2.50f, 3.30f };
        static float[] p_6_6 = { 0.50f, 0.90f, 1.30f, 1.70f, 2.50f, 3.70f };
        static float[] p_6_7 = { 0.50f, 0.90f, 1.30f, 1.70f, 2.90f, 3.30f };
        static float[] p_6_8 = { 0.50f, 0.90f, 1.30f, 1.70f, 2.90f, 3.70f };
        static float[] p_6_9 = { 0.50f, 0.90f, 1.30f, 1.70f, 3.30f, 3.70f };
        static float[] p_6_10 = { 0.50f, 0.90f, 1.30f, 2.10f, 2.90f, 3.30f };
        static float[] p_6_11 = { 0.50f, 0.90f, 1.30f, 2.10f, 2.90f, 3.70f };
        static float[] p_6_12 = { 0.50f, 0.90f, 1.30f, 2.10f, 3.30f, 3.70f };
        static float[] p_6_13 = { 0.50f, 0.90f, 1.30f, 2.50f, 3.30f, 3.70f };
        static float[] p_6_14 = { 0.50f, 0.90f, 1.70f, 2.50f, 3.30f, 3.70f };
        static float[] p_6_15 = { 0.50f, 1.00f, 1.50f, 2.00f, 2.50f, 3.00f };
        static float[] p_6_16 = { 0.50f, 1.00f, 1.50f, 2.00f, 2.50f, 3.50f };
        static float[] p_6_17 = { 0.50f, 1.00f, 1.50f, 2.00f, 3.00f, 3.50f };

        public static float[][] Ataques2 = { p_2_0, p_2_1, p_2_2, p_2_3, p_2_4, p_2_5 };
        public static float[][] Ataques3 = { p_3_0, p_3_1, p_3_2, p_3_3, p_3_4, p_3_5, p_3_6, p_3_7, p_3_8, p_3_9, p_3_10, p_3_11, p_3_12, p_3_13, p_3_14, p_3_15, p_3_16, p_3_17, p_3_18, p_3_19, p_3_20, p_3_21, p_3_22, p_3_23, p_3_24 };
        public static float[][] Ataques4 = { p_4_0, p_4_1, p_4_2, p_4_3, p_4_4, p_4_5, p_4_6, p_4_7, p_4_8, p_4_9, p_4_10, p_4_11, p_4_12, p_4_13, p_4_14 };
        public static float[][] Ataques5 = { p_5_0, p_5_1, p_5_2, p_5_3, p_5_4, p_5_5, p_5_6, p_5_7, p_5_8, p_5_9, p_5_10, p_5_11, p_5_12, p_5_13 };
        public static float[][] Ataques6 = { p_6_0, p_6_1, p_6_2, p_6_3, p_6_4, p_6_5, p_6_6, p_6_7, p_6_8, p_6_9, p_6_10, p_6_11, p_6_12, p_6_13, p_6_14, p_6_15, p_6_16, p_6_17 };

        public static float[][][] Ataques = { Ataques2, Ataques3, Ataques4, Ataques5, Ataques6 };
        
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
