using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class DialogueManager : MonoBehaviour
{

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;

	public Animator animator;

	private Queue<string> sentences;

	public DialogueTrigger dialogueTrigger1;
	public DialogueTrigger dialogueTrigger2;
	public DialogueTrigger dialogueTrigger3;
	public Image  BgBlack;
	
	// Use this for initialization
	void Start()
	{

		sentences = new Queue<string>();
		dialogueTrigger1.TriggerDialogue();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		if (BgBlack != null)
			BgBlack.enabled = true ;
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return new WaitForSeconds(0.08f);
		}
	}
	public GameManager gameManager;
	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
		StartCoroutine(ChangeScene());
	}
	IEnumerator ChangeScene()
    {
		yield return new WaitForSeconds(0.5f);
		if (!SceneManager.GetSceneByName("Game").isLoaded)
			gameManager.GoToGame();
		else
        {
			
				if (BgBlack != null)
					BgBlack.enabled = false;
			
			
			if (!GameManager.Instance.gameStarted)
				gameManager.OpenControlsCanvas();
		}
		

    }

}