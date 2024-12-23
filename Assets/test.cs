using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MyClass
{
    public long leScore;
    public WeightedList<string> laWeightedList;
}
public class test : MonoBehaviour
{
    // OK
    public List<MyClass> maList;
    // NOT OK
    //[SerializeField] private List<MyClass> maList2;
    public List<MyDictionary<int, string>> maDicList;
    // public MyDictionary<int, string> oui;
    // public MyDictionary<int, string> non;
}
