using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    public GameObject alarmLight;
    public GameObject normalLight;
    public AudioClip siren;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            normalLight.SetActive(false);
            alarmLight.SetActive(true);
            AudioSource.PlayClipAtPoint(siren, Camera.main.transform.position, 0.4f);
            Debug.Log("GameOver");
            KnockBackSystem.Instance.PlayerDie();
            Player.Instance.playerDead = true;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<Player>().Anim.SetBool("Walk", false);
            other.gameObject.GetComponent<Player>().Anim.SetBool("Idle", true);
        }
    }
    
}
