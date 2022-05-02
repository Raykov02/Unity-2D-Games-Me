using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy1 : MonoBehaviour
{
    private float speed;
    public ParticleSystem p1;
    public ParticleSystem p2;
    public ParticleSystem p3;
    public ParticleSystem p4;
    public ParticleSystem p5;
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();   
    }
    private void move()
    {
        if (Usefull.isAlive)
        {
            if (Usable.score > 1000)
            {
                speed = Random.Range(4, 7);
                transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);

            }
            else if (Usable.score > 600)
            {
                speed = Random.Range(3, 6);
                transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
            }
            else if (Usable.score > 300)
            {
                speed = Random.Range(3, 5);
                transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
            }
            else
            {
                speed = Random.Range(2, 4);
                transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
            }           
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player") && Usefull.isGrounded == false)
        {
            sr.enabled = false;
            bc.enabled = false;
            p1.Play();
            p2.Play();
            p3.Play();
            p4.Play();
            p5.Play();
            Destroy(gameObject, 1f);
        }
    }
}
