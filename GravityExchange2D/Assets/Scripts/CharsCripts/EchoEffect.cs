using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class EchoEffect : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public GameObject echo;
    public GameObject charac;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = echo.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnEchos();
    }
    private void spawnEchos()
    {
        if (Usefull.isAlive)
        {
            if (Usefull.isGrounded == false)
            {
                if (timeBtwSpawns <= 0)
                {
                    GameObject instance = (GameObject)Instantiate(echo);
                    instance.transform.position = charac.transform.position;
                    Destroy(instance, 0.5f);
                    timeBtwSpawns = startTimeBtwSpawns;
                }
                if (CrossPlatformInputManager.GetButtonDown("Jump"))
                {
                    if (charac.transform.position.y > 0)
                    {
                        sr.flipY = false;
                    }
                    else if (charac.transform.position.y < 0)
                    {
                        sr.flipY = true;
                    }
                }
                else
                {
                    timeBtwSpawns -= Time.deltaTime;
                }
            }
        }
    }
}
