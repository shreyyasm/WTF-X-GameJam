using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public GameObject player;
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        //pos = transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));

        ///transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
    }
}
