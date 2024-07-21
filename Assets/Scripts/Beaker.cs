using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Beaker : MonoBehaviour
{
    
    [SerializeField]private int data;
    public GameObject liquid ;
    
    public void SetData(int d,string s)
    {
        data = d;
        GetComponentInChildren<TMP_Text>().text = s;

        liquid.GetComponent<Renderer>().material.SetColor("_sidecolour", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
        liquid.GetComponent<Renderer>().material.SetColor("_topcolour", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));

    }
    public int GetData()
    {
        return data;
    }
    

}
