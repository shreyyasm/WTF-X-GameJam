using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SUPERCharacterAIO controller;

    //CanvasStuff
    public GameObject InteractUI;


    Animator Anim;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        holding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isIdle)
        {
            //Anim.SetBool("Idle", true);
            //Anim.SetBool("Walk", false);
        }
        else
        {
           // Anim.SetBool("Idle", false);
            //Anim.SetBool("Walk", true);
        }
        if(controller.Jumped)
        {
            //Anim.SetBool("Jump", true);
            //Anim.SetBool("Idle", false);
            //Anim.SetBool("Walk", false);
        }
    }
    [SerializeField] private FormulationLogic GM;

    [SerializeField] private bool holding;
    [SerializeField] private int data;
    private void OnTriggerStay(Collider other)
    {
        
        //if(other.CompareTag("Jar"))
        //{
        //    InteractUI.SetActive(true);
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        Debug.Log("Picked");
        //        Pickup();
        //    }
        //}
        //if (other.CompareTag("Beaker"))
        //{
        //    InteractUI.SetActive(true);
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        Debug.Log("Beaker");
        //        Drop();
        //    }
        //}
        //if (other.CompareTag("Sink"))
        //{
        //    InteractUI.SetActive(true);
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        Debug.Log("Sink");
        //        Sink();
        //    }
        //}
        if (other.CompareTag("Beaker") )
        {
            if(Input.GetKeyDown(KeyCode.E) && !holding)
            {
                data = other.gameObject.GetComponent<Beaker>().GetData();
                holding = true;
            }
            InteractUI.SetActive(true);
            
        }
        else if (other.CompareTag("Machine"))
        {
            if (Input.GetKeyDown(KeyCode.E) && holding)
            {
                GM.Check(data);
                holding = false;
            }
            InteractUI.SetActive(true);
           
        }
        else if (other.CompareTag("Sink") )
        {
            if(Input.GetKeyDown(KeyCode.E) && holding)
            {
                holding = false;
            }
            InteractUI.SetActive(true);
           
        }

    }
    private void OnTriggerExit(Collider other)
    {
        InteractUI.SetActive(false);
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
