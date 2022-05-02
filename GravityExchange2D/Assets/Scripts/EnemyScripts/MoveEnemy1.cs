using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy1 : MonoBehaviour
{
    [SerializeField]private float speedHigh = 3f;
    [SerializeField]private float speedForward = 3f;
    public ParticleSystem p1;
    public ParticleSystem p2;
    public ParticleSystem p3;
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
        Move();
    }
    private void Move()
    {
        if (Usefull.isAlive)
            transform.position += new Vector3(-speedForward * Time.deltaTime, -speedHigh * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TriggerGround"))
        {
            speedHigh *= -1;
        }
        if (collision.gameObject.CompareTag("player") && Usefull.isGrounded == false)
        {
            sr.enabled = false;
            bc.enabled = false;
            p1.Play();
            p2.Play();
            p3.Play();
            Destroy(gameObject, 1f);
        }
    }
}
