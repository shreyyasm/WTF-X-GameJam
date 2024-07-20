using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SUPERCharacterAIO controller;

    //CanvasStuff
    public GameObject InteractUI;


    public Animator Anim;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        holding = false;
    }

    // Update is called once per frame
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
            Anim.SetBool("Idle", false);
            Anim.SetBool("Walk", true);
        }
        if(controller.Jumped)
        {
            Anim.SetBool("Jump", true);
            Anim.SetBool("Idle", false);
            Anim.SetBool("Walk", false);
        }
        if (Input.GetKeyDown(KeyCode.E) && !holding && touchBeaker)
        {
            data = refObject.gameObject.GetComponent<Beaker>().GetData();
            KnockBackSystem.Instance.ChemicalPickup(transform);
            holding = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && holding && touchMachine)
        {
            GM.Check(data);
            KnockBackSystem.Instance.ChemicalDrop(transform);
            //KnockBackSystem.Instance.ChemicalRinse();
            holding = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && holding && touchSink)
        {
            KnockBackSystem.Instance.ChemicalRinse();
            holding = false;
        }
    }
    [SerializeField] private FormulationLogic GM;

    [SerializeField] private bool holding;
    [SerializeField] private int data;
    public bool touchBeaker;
    public bool touchMachine;
    public bool touchSink;
    GameObject refObject;

    private void OnTriggerStay(Collider other)
    {

       
        if (other.CompareTag("Beaker"))
        {
            touchBeaker = true;
            refObject = other.gameObject;
            InteractUI.SetActive(true);        
        }

        if (other.CompareTag("Machine"))
        {
            touchMachine = true;          
            InteractUI.SetActive(true);
        }
        if (other.CompareTag("Sink"))
        {
            touchSink = true;           
            InteractUI.SetActive(true);
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
