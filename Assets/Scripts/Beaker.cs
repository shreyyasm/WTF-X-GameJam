using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Beaker : MonoBehaviour
{
    
    [SerializeField]private int data;
    public GameObject liquid ;
    private string chemicalName = " ";
    
    private void Start() {
        liquid.GetComponent<Renderer>().material.SetFloat("_Liquidlevel", Random.Range(0f,0.7f));
    }
    public void SetData(int d,string s)
    {
        data = d;
        chemicalName = s;
        GetComponentInChildren<TMP_Text>().text = s;

        liquid.GetComponent<Renderer>().material.SetColor("_sidecolour", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
        liquid.GetComponent<Renderer>().material.SetColor("_topcolour", liquid.GetComponent<Renderer>().material.GetColor("_sidecolour"));

    }
    public int GetData()
    {
        return data;
    }
    public string GetName()
    {
        return chemicalName;
    }

}
