using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public SUPERCharacterAIO controller;

    //CanvasStuff
    public GameObject InteractUI;


    public Animator Anim;
    public bool playerDead;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        holding = false;
        
    }
    public GameObject TesttubeLiquid;
    // Update is called once per frame
    public bool ChemicalTaken = false;
    public bool PipeWalk = false;
    public bool machineRun = false;

    public bool Narrating = false;
    void Update()
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && Anim.GetCurrentAnimatorStateInfo(0).IsName("PROTO BONE|Jump"))
        {
            Anim.SetBool("Jump", false);
        }
        if(controller.isIdle)
        {
            Anim.SetBool("Idle", true);
            Anim.SetBool("Walk", false);
            
        }
        else
        {
            if(!playerDead)
            {
                Anim.SetBool("Idle", false);
                Anim.SetBool("Walk", true);
            }
           
        }
        if(controller.Jumped && !playerDead)
        {
            Anim.SetBool("Jump", true);
            Anim.SetBool("Idle", false);
            Anim.SetBool("Walk", false);
        }
        if (Input.GetKeyDown(KeyCode.E) && !holding && touchBeaker)
        {
            data = refObject.gameObject.GetComponent<Beaker>().GetData();
            KnockBackSystem.Instance.ChemicalPickup(transform);
            
            TesttubeLiquid.GetComponent<Renderer>().material.SetColor("_sidecolour", refObject.GetComponentInChildren<Renderer>().material.GetColor("_sidecolour"));
            TesttubeLiquid.GetComponent<Renderer>().material.SetColor("_topcolour", refObject.GetComponentInChildren<Renderer>().material.GetColor("_topcolour"));
            TesttubeLiquid.GetComponent<Renderer>().material.SetFloat("_Liquidlevel", 0.45f);
            //Debug.Log(refObject.GetComponent<Beaker>().liquid.GetComponent<Renderer>().material.GetColor("_sidecolour"));
            if(!ChemicalTaken)
            {
                Narrating = true;
                InteractUI.SetActive(false);
                dialogueTrigger2.TriggerDialogue();
                Narration.Instance.NarrationCall2();
                Player.Instance.playerDead = true;
                GetComponent<Rigidbody>().isKinematic = true;
                LeanTween.delayedCall(20f, () => { DialogueManager.Instance.EndDialogue(); Player.Instance.playerDead = false; GetComponent<Rigidbody>().isKinematic = false; Narrating = false; });
                Anim.SetBool("Idle", true);
                Anim.SetBool("Walk", false);
                ChemicalTaken = true;
            }

            holding = true;

        }

        if (Input.GetKeyDown(KeyCode.E) && holding && touchMachine)
        {
           
            KnockBackSystem.Instance.ChemicalDrop(transform);
            TesttubeLiquid.GetComponent<Renderer>().material.SetFloat("_Liquidlevel", 0f);

            Color chemcolor = TesttubeLiquid.GetComponent<Renderer>().material.GetColor("_sidecolour");
            //Debug.Log("side color is " + chemcolor);
            //GM.MachineTT.GetComponent<Renderer>().material.SetColor("_sidecolour", chemcolor);
            //GM.MachineTT.GetComponent<Renderer>().material.SetColor("_topcolour", chemcolor);
            GM.Check(data, chemcolor);
            
            //KnockBackSystem.Instance.ChemicalRinse();
            holding = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && holding && touchSink)
        {
            KnockBackSystem.Instance.ChemicalRinse();
            TesttubeLiquid.GetComponent<Renderer>().material.SetFloat("_Liquidlevel", 0f);
            holding = false;
        }
        if (playerDead)
            controller.enabled = false;
        else
            controller.enabled = true;
    }
    [SerializeField] private FormulationLogic GM;

    [SerializeField] private bool holding;
    [SerializeField] private int data;
    public bool touchBeaker;
    public bool touchMachine;
    public bool touchSink;
    public GameObject refObject;
    public DialogueTrigger dialogueTrigger2;
    public DialogueTrigger dialogueTrigger3;
    public DialogueTrigger dialogueTrigger4;


    private void OnTriggerStay(Collider other)
    {

       
        if (other.CompareTag("Beaker"))
        {
            touchBeaker = true;
            refObject = other.gameObject;
            if(!Narrating)
                InteractUI.SetActive(true);        
        }

        if (other.CompareTag("Machine"))
        {
            touchMachine = true;
            if (!Narrating)
                InteractUI.SetActive(true);
        }
        if (other.CompareTag("Sink"))
        {
            touchSink = true;
            if (!Narrating)
                InteractUI.SetActive(true);
        }
        if (other.CompareTag("Pipe"))
        {
            if(!PipeWalk)
            {
                Narrating = true;
                InteractUI.SetActive(false);
                dialogueTrigger3.TriggerDialogue();
                Narration.Instance.NarrationCall3();
                Player.Instance.playerDead = true;
                GetComponent<Rigidbody>().isKinematic = true;
                LeanTween.delayedCall(24f, () => { DialogueManager.Instance.EndDialogue(); Player.Instance.playerDead = false; GetComponent<Rigidbody>().isKinematic = false; Narrating = false; });
                Anim.SetBool("Idle", true);
                Anim.SetBool("Walk", false);
                PipeWalk = true;
            }
            
        }

    }
    private void OnTriggerExit(Collider other)
    {
        InteractUI.SetActive(false);
        touchBeaker = false;
        touchMachine = false;
        touchSink = false;
    }
    public void Pickup()
    {

    }
    public void Drop()
    {

    }
    public void Sink()
    {

    }
}
