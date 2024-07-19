using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] AudioClip punchSFX; 
    [SerializeField] AudioClip keyPressSFX;
    [SerializeField] AudioClip wrongKeySFX;
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
    public void CallPunchSFX()
    {
        AudioSource.PlayClipAtPoint(punchSFX, Camera.main.transform.position, 0.4f);
    }
    public void CallKeyPressSFX()
    {
        AudioSource.PlayClipAtPoint(keyPressSFX, Camera.main.transform.position);
    }
    public void CallWrongKeySFX()
    {
        AudioSource.PlayClipAtPoint(wrongKeySFX, Camera.main.transform.position);
    }
}
