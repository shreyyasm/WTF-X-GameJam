using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FormulationLogic : MonoBehaviour
{
	[SerializeField]private ChemicalDataScriptable Chemicals;
	public TMP_Text[] board_placeholder = new TMP_Text[6];
	[SerializeField]private List<int> serial_no = new List<int>();
	[SerializeField]private GameObject Beakers;
	[SerializeField]private List<Beaker> beaker_placeholder = new List<Beaker>();
	private int index =0;

	[SerializeField] private int[] chemicalset = new int[2];
	[SerializeField] private int[] checkset = new int[2];

  

    public void Start()
	{
		foreach(Transform b in Beakers.transform)
		{
			beaker_placeholder.Add(b.GetComponent<Beaker>());
		}
		
		SetChemicals();
	}

	public GameObject MachineTT;
	public int SetChemicals()
	{

		#region FormulaOnBoard
		int r=0;
		int temp=0;
			
        for(int i =0; i<board_placeholder.Length; i++)
		{
			r = Random.Range(0,Chemicals.Chemical.Count);	
			if(r == temp){
				r = Random.Range(0,Chemicals.Chemical.Count);

				Debug.Log("r = " + r);
                board_placeholder[i].text = Chemicals.Chemical[r].Name;
			}
			else{
				Debug.Log("r = " + r);
                board_placeholder[i].text = Chemicals.Chemical[r].Name;
			}
			serial_no.Add(r);
			temp = r;
		}
		#endregion


		#region Beakers
		Shuffle(beaker_placeholder);

		int q = Chemicals.Chemical.Count-1;
		for(int i=0; i<=beaker_placeholder.Count-1; i++)
		{
			beaker_placeholder[i].SetData(q,Chemicals.Chemical[q].Name);
			
			if(q==0){q=Chemicals.Chemical.Count-1;}
			else{q--;}
		}

		#endregion



		return 0;
	}
	public bool machineRun = false;
	public DialogueTrigger dialogueTrigger4;
	public void Check(int input)
	{

		checkset[index] = serial_no[index];
		chemicalset[index] = input;
		if ((index + 1) % 2 == 0)
		{
			if (!machineRun)
			{

				dialogueTrigger4.TriggerDialogue();
				Narration.Instance.NarrationCall4();
				Player.Instance.playerDead = true;
				LeanTween.delayedCall(8f, () => { DialogueManager.Instance.EndDialogue(); Player.Instance.playerDead = false; });
				machineRun = true;

			}
			if (checkset[0] == chemicalset[0] && checkset[1] == chemicalset[1])
			{
				MachineTT.GetComponent<Renderer>().material.SetFloat("_Liquidlevel", 1f);
				KnockBackSystem.Instance.RightCompund();
				index++;

			}
			else
			{
				MachineTT.GetComponent<Renderer>().material.SetFloat("_Liquidlevel", 0.5f);
				KnockBackSystem.Instance.WrongCompund();
				Debug.Log("Failed");
				index--;
			}
		}
		else
		{
			MachineTT.GetComponent<Renderer>().material.SetFloat("_Liquidlevel", 1f);
			index++;
		}

	}

	void Shuffle<T>(List<T> list)
	{
		System.Random random = new System.Random();
		int n = list.Count;
		for(int i = n-1; i>0;i--)
		{
			int j = random.Next(0,i+1);
			T temp = list[i];
			list[i] = list[j];
			list[j] = temp;
		}
	}
}
