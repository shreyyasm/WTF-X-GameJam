using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAi : MonoBehaviour
{
  
    public Transform pos1;
    public Transform pos2;

    // The target marker.
    public Transform target;


    public Transform Raytarget;
    public Transform Raypos1;
    public Transform Raypos2;
    // Angular speed in radians per sec.
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        target = pos1;
        Raytarget = Raypos1;
    }
    public float Movey;
    // Update is called once per frame
    void Update()
    {
        Movey = transform.rotation.y;
        if (transform.rotation.y > 0.7)
        {
            target = pos2;
        }
        if (transform.rotation.y < 0.3)
        {
            target = pos1;
        }

        Vector3 targetDirection = target.position - transform.position;
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        //transform.rotation = Quaternion.LookRotation(newDirection);
        Raycast();

        //origin.transform.Translate(Raytarget.position * speed* Time.deltaTime);
        var step = speed* Time.deltaTime; // calculate distance to move
        origin.position = Vector3.MoveTowards(origin.position, Raytarget.position, step);
        if (origin.transform.position == Raypos1.position)
        {
            Raytarget = Raypos2;
        }
        if (origin.transform.position == Raypos2.position)
        {
            Raytarget = Raypos1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("GameOver");
        }
    }
    public GameObject currentHitObject;
    public float sphereRadius;
    public float maxDistance;
    public LayerMask layermask;

    public Transform origin;
    public Vector3 direction;
    private float currentHitDistance;

    public GameObject alarmLight;
    public GameObject normalLight;
    public AudioClip siren;
    bool dead;
    public void Raycast()
    {
       
        
        RaycastHit hit;
        if(Physics.SphereCast(origin.position, sphereRadius,direction, out hit, maxDistance,layermask,QueryTriggerInteraction.UseGlobal))
        {
            currentHitObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;
            if(hit.collider.gameObject.CompareTag("Player") && !dead)
            {
                normalLight.SetActive(false);
                alarmLight.SetActive(true);
                AudioSource.PlayClipAtPoint(siren, Camera.main.transform.position, 0.4f);
                Debug.Log("GameOver");
                KnockBackSystem.Instance.PlayerDie();
                Player.Instance.playerDead = true;
                hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                hit.collider.gameObject.GetComponent<Player>().Anim.SetBool("Walk", false);
                hit.collider.gameObject.GetComponent<Player>().Anim.SetBool("Idle", true);
                dead = true;
            }

        }
        else
        {
            currentHitDistance = maxDistance;
            currentHitObject = null;
        }

    }
    public void GameOver()
    {

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin.position, origin.position + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin.position + direction * currentHitDistance, sphereRadius);
    }
}

