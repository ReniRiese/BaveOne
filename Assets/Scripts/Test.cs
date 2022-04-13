using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Test
{
    public static int trees = 0;
    
    public static void SaveData()
    {
        PlayerPrefs.SetInt("trees", trees);
    }

    public static void ReadData()
    {
        Debug.Log(PlayerPrefs.GetInt("trees"));
    }
}
