using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip ChemicalPickupSFX;
    public AudioClip ChemicalDropSFX;
    public AudioClip WrongCompundSFX;
    public AudioClip RightCompundSFX;
    public AudioClip ChemicalRinseSFX;
    public AudioClip TestubeBurstSFX;
    public AudioClip AntidoteCreatedSFX;

    public AudioClip machineTurnOnSFX;
    // [SerializeField] AudioClip punchSFX;
    //[SerializeField] AudioClip punchSFX;

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
    public void ChemicalPickup()
    {
        AudioSource.PlayClipAtPoint(ChemicalPickupSFX, Camera.main.transform.position, 0.4f);
    }
    public void ChemicalDrop()
    {
        AudioSource.PlayClipAtPoint(ChemicalDropSFX, Camera.main.transform.position, 0.4f);
    }
    public void WrongCompund()
    {
        AudioSource.PlayClipAtPoint(WrongCompundSFX, Camera.main.transform.position, 0.4f);
    }
    public void RightCompund()
    {
        AudioSource.PlayClipAtPoint(RightCompundSFX, Camera.main.transform.position, 0.4f);
    }
    public void ChemicalRinse()
    {
        AudioSource.PlayClipAtPoint(ChemicalRinseSFX, Camera.main.transform.position, 0.4f);
    }
    public void TestTubeBurst()
    {
        AudioSource.PlayClipAtPoint(TestubeBurstSFX, Camera.main.transform.position, 0.4f);
    }
    public void AntidoteCreated()
    {
        AudioSource.PlayClipAtPoint(AntidoteCreatedSFX, Camera.main.transform.position, 0.4f);
    }
    public void CallKeyPressSFX()
    {
        //AudioSource.PlayClipAtPoint(keyPressSFX, Camera.main.transform.position);
    }
    public void CallWrongKeySFX()
    {
        //AudioSource.PlayClipAtPoint(wrongKeySFX, Camera.main.transform.position);
    }
}
