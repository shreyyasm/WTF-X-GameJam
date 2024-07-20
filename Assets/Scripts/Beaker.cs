using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Beaker : MonoBehaviour
{
    
    [SerializeField]private int data;

    
    public void SetData(int d,string s)
    {
        data = d;
        GetComponentInChildren<TMP_Text>().text = s;
    }
    public int GetData()
    {
        return data;
    }
    

}
