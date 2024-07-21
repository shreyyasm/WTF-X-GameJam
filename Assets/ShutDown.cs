using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDown : MonoBehaviour
{
    public GameObject VideoPlayer;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.delayedCall(8f, () => { anim.SetBool("Idle", false);  });
        LeanTween.delayedCall(10f, () => { VideoPlayer.SetActive(false); });
        LeanTween.delayedCall(12f, () => { GameManager.Instance.GotoMainMenu(); });


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
