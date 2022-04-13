using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor.UnitTesting;
using UnityEngine;

public class CubeCounter : MonoBehaviour
{
    public int myOffset;

    public void AddOffset()
    {
        Test.trees += myOffset;
    }

    public void SaveData()
    {
        Test.SaveData();
    }

    public void ReadData()
    {
        Test.ReadData();
    }
    
}
