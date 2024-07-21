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

    public AudioClip RotationSFX;
    public AudioClip JumpSound;
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
        Narration.Instance.audioSource.PlayOneShot(ChemicalPickupSFX, 1f);
    }
    public void ChemicalDrop()
    {
        Narration.Instance.audioSource.PlayOneShot(ChemicalDropSFX, 1f);
    }
    public void WrongCompund()
    {
        Narration.Instance.audioSource.PlayOneShot(WrongCompundSFX, 1f);
        Narration.Instance.audioSource.PlayOneShot(TestubeBurstSFX, 1f);
    }
    public void RightCompund()
    {
        Narration.Instance.audioSource.PlayOneShot(RightCompundSFX, 1f);
    }
    public void ChemicalRinse()
    {
        Narration.Instance.audioSource.PlayOneShot(ChemicalRinseSFX,  1f);
    }
    public void TestTubeBurst()
    {
        Narration.Instance.audioSource.PlayOneShot(TestubeBurstSFX, 1f);
    }
    public void AntidoteCreated()
    {
        Narration.Instance.audioSource.PlayOneShot(AntidoteCreatedSFX,  1f);
    }
    public void Rotationn()
    {
        Narration.Instance.audioSource.PlayOneShot(RotationSFX, 1f);
    }
    public void JumpSFX()
    {
        Narration.Instance.audioSource.PlayOneShot(JumpSound, 1f);
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
