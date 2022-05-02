using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public static class Usefull
{
    public static bool isGrounded;
    public static bool isAlive;
}
public class CharacterScripts : MonoBehaviour
{
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private GameObject endpan;
    private GameObject pausebut;
    [SerializeField] private float force;
    private Animator anim;
    private bool facingUp;
    private Shake shake;
    private BoxCollider2D bc;
    private void Awake()
    {
        Usefull.isAlive = true;
    }
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        Usefull.isGrounded = true;
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        endpan = GameObject.Find("endPannel");
        endpan.SetActive(false);
        pausebut = GameObject.Find("PauseBUtt");
        pausebut.SetActive(true);
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
 
    }

    // Update is called once per frame
    void Update()
    {
        changeGravity();
        moveForward();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("grounding"))
        {
            Usefull.isGrounded = true;
            anim.SetBool("inAir", false);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (Usefull.isGrounded == false)
            {
                Usable.score += 10;
                Usable.enemiesKilled++;
            }
            else
            {
                StartCoroutine(death());
            }
        }
        if (collision.gameObject.CompareTag("Meteor"))
        {
            StartCoroutine(death());
        }
    }
    public void changeGravity()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump") && Usefull.isGrounded == true && Usefull.isAlive) 
        {
            myBody.gravityScale = -myBody.gravityScale;
            shake.CamShake();
            if (transform.localScale.y>0)
            {
                    myBody.AddForce(new Vector2(0f, force), ForceMode2D.Impulse);
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
                    facingUp = false;
            }
            else
            {
                    myBody.AddForce(new Vector2(0f, -force), ForceMode2D.Impulse);
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
                    facingUp = true;
            }
            Usefull.isGrounded = false;
            anim.SetBool("inAir", true);
        }
    }
    void moveForward()
    {
        if(transform.position.x< -5)
        {
            transform.position += new Vector3(2 * Time.deltaTime, 0f, 0f);
        }
    }
    IEnumerator death()
    {
        Usefull.isAlive = false;
        shake.DeathShake();
        pausebut.SetActive(false);
        anim.SetBool("deathUp", true);
        bc.isTrigger = true;
        myBody.gravityScale = 1;
        myBody.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(2);
        endpan.SetActive(true);
        Destroy(gameObject);
       
    }
}
