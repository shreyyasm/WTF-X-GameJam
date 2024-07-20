using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chemical Name", menuName = "Chemical Names", order = 1)]
public class ChemicalDataScriptable : ScriptableObject 
{
 	public List<ChemicalName> Chemical;
}



[System.Serializable]
public class ChemicalName
{
    public string Name; 
    
}

