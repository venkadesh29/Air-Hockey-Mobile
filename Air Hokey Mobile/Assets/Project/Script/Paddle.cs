using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public int playerNumber;
    public float speed = 10f;

    private Rigidbody paddleRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        paddleRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        // Handle touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
            movement = new Vector3(touchPosition.x, 0, touchPosition.z);
        }

        // Move paddle with touch input
        paddleRigidbody.velocity = new Vector3(movement.x * speed, 0, movement.z * speed);
    }
}
