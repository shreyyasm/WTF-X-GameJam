using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Jump()
    {
        Narration.Instance.audioSource.PlayOneShot(SoundManager.Instance.JumpSound, 1f);
    }
}
