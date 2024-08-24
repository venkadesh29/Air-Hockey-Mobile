using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{ 
    public delegate void GoalHandler();
    public event GoalHandler OnGoal;

    public float deceleration;
    public float startingHorizontalPosition;
    
    private Rigidbody puckRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        puckRigidbody = gameObject.GetComponent<Rigidbody>();
        ResetPosition (true);
    }

    void FixedUpdate()
    {
        puckRigidbody.velocity = new Vector3 (
            puckRigidbody.velocity.x * deceleration,
            puckRigidbody.velocity.y * deceleration,
            puckRigidbody.velocity.z * deceleration
        );
    }

    
    void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "Goal")
        {
            if(OnGoal != null)
            {
                OnGoal();
            }
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    public void ResetPosition(bool isLeft)
    {
        transform.position = new Vector3 (
            startingHorizontalPosition * (isLeft ? -1 : 1),
            transform.position.y,
            transform.position.z
        );

        puckRigidbody.velocity = Vector3.zero;
    }
}
