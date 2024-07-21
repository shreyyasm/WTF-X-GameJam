using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narration : MonoBehaviour
{
    public static Narration Instance;
    public AudioClip Narration1;
    public AudioClip Narration2;
    public AudioClip Narration3;
    public AudioClip Narration4;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        LeanTween.delayedCall(0.2f, () => { AudioSource.PlayClipAtPoint(Narration1, Camera.main.transform.position, 0.7f); });
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NarrationCall2()
    {
        AudioSource.PlayClipAtPoint(Narration2, Camera.main.transform.position, 0.7f);
    }
    public void NarrationCall3()
    {
        AudioSource.PlayClipAtPoint(Narration3, Camera.main.transform.position, 0.7f);
    }
    public void NarrationCall4()
    {
        AudioSource.PlayClipAtPoint(Narration4, Camera.main.transform.position, 0.7f);
    }
}
