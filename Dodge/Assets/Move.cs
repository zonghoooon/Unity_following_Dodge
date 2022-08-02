using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private FixedJoystick joy;
    public Rigidbody2D rb;
    private float speed=3f;
    private Vector2 vel;

    void Start()
    {
        joy = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
        if (transform.position.x < -9) transform.position = new Vector2(-9f,transform.position.y);
        if (transform.position.y < -5) transform.position = new Vector2(transform.position.x, -5f);
        if (transform.position.x >9) transform.position = new Vector2(9f,transform.position.y);
        if (transform.position.y >5) transform.position = new Vector2(transform.position.x, 5f);
    }
    private void move()
    {
        float X = joy.Horizontal * speed;
        float Y = joy.Vertical * speed;
        Vector2 Velocity = new Vector2(X, Y);
        vel = Velocity;
        rb.velocity = Velocity;
    }
}
