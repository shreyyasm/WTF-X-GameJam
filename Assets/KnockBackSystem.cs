using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackSystem : MonoBehaviour
{
    public static KnockBackSystem Instance;
    public GameObject MixingMachinePos;
    public GameObject MainBeakerPos;
    public GameObject SinkPos;
    

    //VFXs
    public GameObject ChemicalPickupVFX;
    public GameObject ChemicalDropVFX;
    public GameObject WrongCompundVFX;
    public GameObject RightCompundVFX;
    public GameObject ChemicalRinseVFX;
    public GameObject TestubeBurstVFX;
    public GameObject AntidoteCreatedVFX;

    public GameObject wrongVFX;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChemicalPickup(Transform Position)
    {
        Instantiate(ChemicalPickupVFX, Position.position, Quaternion.identity);
        SoundManager.Instance.ChemicalPickup();
    }
    public void ChemicalDrop(Transform Position)
    {
        Instantiate(ChemicalDropVFX, Position.position, Quaternion.identity);
        SoundManager.Instance.ChemicalDrop();
    }
    public void WrongCompund()
    {
        Instantiate(WrongCompundVFX, MixingMachinePos.transform.position, Quaternion.identity);
        //Instantiate(TestubeBurstVFX, MixingMachinePos.transform.position, Quaternion.identity);
        Instantiate(wrongVFX, MixingMachinePos.transform.position, Quaternion.identity);
        SoundManager.Instance.WrongCompund();
    }
    public void RightCompund()
    {
        Instantiate(RightCompundVFX, MixingMachinePos.transform.position, Quaternion.Euler(-90,0,0));
        SoundManager.Instance.WrongCompund();
    }
    public void ChemicalRinse()
    {
        Instantiate(ChemicalRinseVFX, SinkPos.transform.position, Quaternion.identity);
        SoundManager.Instance.ChemicalRinse();
    }
    public void TestTubeBurst(Transform Position)
    {
        Instantiate(TestubeBurstVFX, Position.position, Quaternion.identity);
        SoundManager.Instance.TestTubeBurst();
    }
    public void AntidoteCreated()
    {
        Instantiate(AntidoteCreatedVFX, MixingMachinePos.transform.position, Quaternion.identity);
        
    }
    public void AntidoteSound()
    {
        SoundManager.Instance.AntidoteCreated();
    }
    public GameObject GameOverCanvas;
    bool dead = false;
    public void PlayerDie()
    {
        if(!dead)
        {
            Instantiate(TestubeBurstVFX, transform.position, Quaternion.identity);
            SoundManager.Instance.TestTubeBurst();
            
            StartCoroutine(Gameover());
            dead = true;
        }
       
    }
    IEnumerator Gameover()
    {
        yield return new WaitForSeconds(4f);
        GameOverCanvas.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        //Time.timeScale = 0;
    }

}
