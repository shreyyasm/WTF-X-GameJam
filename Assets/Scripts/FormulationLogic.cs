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

	public GameObject PlayerTestTube;
	public GameObject[] MachineTestTube;
	public GameObject VortexPivot;
	private Vector3 VortexPos;
	public bool VortexAnim;

	public void Start()
	{
		VortexAnim = false;
		foreach(Transform b in Beakers.transform)
		{
			beaker_placeholder.Add(b.GetComponent<Beaker>());
		}
		
		SetChemicals();
	}
	private void FixedUpdate()
	{
		if (VortexAnim)
		{
			VortexPivot.transform.Rotate(0, 20f, 0, Space.World);
		}
		
	}
	bool Introduced;
    private void Update()
    {
		if(index < 6)
			board_placeholder[index].fontStyle = FontStyles.Underline;

		//for (int i = 0; i <= index; i++)
		//{
		//	//board_placeholder[i].color = new Color(0, 1, 0, 1);
		//}
		//for (int i = index; i <= 5; i++)
		//{
		//	board_placeholder[index].fontStyle = FontStyles.Underline;
		//	//board_placeholder[i].color = new Color(1, 1, 1, 1);

		//}
		//if (Player.Instance.Narrating && Introduced)
  //      {
		//	laser.SetActive(false);
  //      }
		//if(!Player.Instance.Narrating && Introduced)
		//{
			
		//	laser.SetActive(true); ;
		//}
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
	public Player playerScript;
	public GameObject laserCam;
	public GameObject laser;
	
	public void Check(int input,Color colour)
	{

		checkset[index % 2] = serial_no[index];
		MachineTestTube[index].GetComponent<Renderer>().material.SetFloat("_Liquidlevel", 1f);
		//Color col = PlayerTestTube.GetComponent<Renderer>().material.GetColor("_sidecolour");
		Debug.Log(colour);
		MachineTestTube[index].GetComponent<Renderer>().material.SetColor("_sidecolour", colour);
		MachineTestTube[index].GetComponent<Renderer>().material.SetColor("_topcolour", colour);


		chemicalset[index % 2] = input;
		if ((index + 1) % 2 == 0)
		{
			if (!Player.Instance.machineRun)
			{
				LeanTween.delayedCall(5f, () =>
				{
					Player.Instance.Narrating = true;
					Player.Instance.machineRun = true;
					dialogueTrigger4.TriggerDialogue();
					Narration.Instance.NarrationCall4();
					//Player.Instance.playerDead = true;
					LeanTween.delayedCall(8f, () => { laserCam.SetActive(false); DialogueManager.Instance.EndDialogue(); Player.Instance.playerDead = false; playerScript.GetComponent<Rigidbody>().isKinematic = false; Player.Instance.Narrating = false; Introduced = true; });
					Player.Instance.InteractUI.SetActive(false);
					//playerScript.GetComponent<Rigidbody>().isKinematic = true;

					playerScript.Anim.SetBool("Idle", true);
					playerScript.Anim.SetBool("Walk", false);

					laser.SetActive(true);
					laserCam.SetActive(true);
					
					machineRun = true;

				});
			}
			if (checkset[0] == chemicalset[0] && checkset[1] == chemicalset[1])
			{
				StartCoroutine(MachineAnimation(1));
				//MachineTT.GetComponent<Renderer>().material.SetFloat("_Liquidlevel", 1f);
				board_placeholder[index].color = new Color(0, 1, 0, 1);
				board_placeholder[index-1].color = new Color(0, 1, 0, 1);
				index++;
				
			}
			else
			{
				StartCoroutine(MachineAnimation(0));
                //MachineTT.GetComponent<Renderer>().material.SetFloat("_Liquidlevel", 0.5f);
                //KnockBackSystem.Instance.WrongCompund();
                
                Debug.Log("Failed");
				//index--;
			}
		}
		else
		{
			MachineTestTube[index].GetComponent<Renderer>().material.SetFloat("_Liquidlevel", 1f);
			index++;
		}

	}
	private IEnumerator MachineAnimation(int i)
	{

		VortexAnim = true;
		SoundManager.Instance.Rotationn();
		if(i == 1 )
        {
			if(index >= 5)
            {
				Debug.Log("work");
				KnockBackSystem.Instance.AntidoteSound();
				
            }
				
		}
		yield return new WaitForSeconds(3f);
		VortexAnim = false;
		if (i == 0)
		{
			MachineTestTube[index - 1].GetComponent<Renderer>().material.SetFloat("_Liquidlevel", 1f);
			MachineTestTube[index].GetComponent<Renderer>().material.SetFloat("_Liquidlevel", 1f);
			Debug.Log("anim fail");
			KnockBackSystem.Instance.WrongCompund();
			index--;
		
			for (int f = index + 1; f <= 5; f++)
			{
				board_placeholder[f].fontStyle &= ~FontStyles.Underline;
				//board_placeholder[i].color = new Color(1, 1, 1, 1);

			}
		}
		else if (i == 1)
		{
			MachineTestTube[index - 1].GetComponent<Renderer>().material.SetFloat("_Liquidlevel", 0f);
			if(index <  6)
				MachineTestTube[index].GetComponent<Renderer>().material.SetFloat("_Liquidlevel", 0f);
			Debug.Log("anim pass");
			
			if(index >= 6)
            {
				KnockBackSystem.Instance.AntidoteCreated();
				LeanTween.delayedCall(2f, () => { Scenes_Test.Instance.LoadEndScene(); });
			}
			else
            {
				KnockBackSystem.Instance.RightCompund();
			}
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
