using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAi : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;

    // The target marker.
    public Transform target;

    // Angular speed in radians per sec.
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        target = pos1;
    }
    // Update is called once per frame
    void Update()
    {
       
        if (transform.rotation.y > 0.5)
        {
            target = pos2;
        }
        if (transform.rotation.y < -0.5)
        {
            target = pos1;
        }

        Vector3 targetDirection = target.position - transform.position;
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        transform.rotation = Quaternion.LookRotation(newDirection);

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("GameOver");
        }
    }
}

