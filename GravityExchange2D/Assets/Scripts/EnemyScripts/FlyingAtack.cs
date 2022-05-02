using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAtack : MonoBehaviour
{
    public float speed = 5f;
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public ParticleSystem p1;
    public ParticleSystem p2;
    public ParticleSystem p3;
    public ParticleSystem p4;
    private SpriteRenderer sr;
    private BoxCollider2D bc;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("player").transform;      
        bc = GetComponent<BoxCollider2D>();
        
    }

    private void Update()
    {
        if (Usefull.isAlive)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
            makeItHard();
        }
    }
    private void FixedUpdate()
    {
        if (Usefull.isAlive)
        {
         if (transform.position.x > 2)
        {
            moveForward();
        }
        else
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
            moveCharacter(movement);
        }
        }
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
    void moveForward()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player")&&Usefull.isGrounded == false)
        {
            sr.enabled = false;
            bc.enabled = false;
            p1.Play();
            p2.Play();
            p3.Play();
            p4.Play();
            Destroy(gameObject, 0.8f);
        }
    }
    void makeItHard()
    {
        if (Usable.score > 1000)
        {
            speed = 8f;
        }
        else if (Usable.score > 500)
        {
            speed = 7f;
        }
    }
   
}
