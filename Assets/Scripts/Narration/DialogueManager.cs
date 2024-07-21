using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class DialogueManager : MonoBehaviour
{
	public static DialogueManager Instance;
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;

	public Animator animator;

	private Queue<string> sentences;

	public DialogueTrigger dialogueTrigger1;
	public DialogueTrigger dialogueTrigger2;
	public DialogueTrigger dialogueTrigger3;
	public DialogueTrigger dialogueTrigger4;
	public Image  BgBlack;

	bool start;
    private void Awake()
    {
		if (Instance == null)
			Instance = this;
		sentences = new Queue<string>();
		
	}
    // Use this for initialization
    void Start()
	{
		LeanTween.delayedCall(0.2f, () => { Player.Instance.playerDead = true; dialogueTrigger1.TriggerDialogue(); });
		
		LeanTween.delayedCall(20f, () => { EndDialogue(); Player.Instance.playerDead = false; });
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
	public float speed = 0.08f;
	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return new WaitForSeconds(speed);
		}
	}
	public GameManager gameManager;
	public void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
		//StartCoroutine(ChangeScene());
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
			
			
			//if (!GameManager.Instance.gameStarted)
			//	gameManager.OpenControlsCanvas();
		}
		

    }
    private void Update()
    {

		//if (sentences.Count == 0 && start)
		//{
		//	EndDialogue();

		//}

	}
}