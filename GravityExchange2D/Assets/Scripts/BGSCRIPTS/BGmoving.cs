using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmoving : MonoBehaviour
{
    public float moveSpeed = 5f;
    private GameObject[] sideBounds;
    private float cameraX;
    private float boundWIdth;
    private void Awake()
    {
        sideBounds = GameObject.FindGameObjectsWithTag("SideBound");
        cameraX = Camera.main.gameObject.transform.position.x-20;
        boundWIdth = GetComponent<BoxCollider2D>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Usefull.isAlive)
        {
            Move();
            Reposition();
        }
    }
    private void Move()
    {
        if (Usable.score > 1000)
        {
            moveSpeed = 8f;
            Vector3 temp = transform.position;
            temp.x -= moveSpeed * Time.deltaTime;
            transform.position = temp;

        }
        else if (Usable.score > 600)
        {
            moveSpeed = 7f;
            Vector3 temp = transform.position;
            temp.x -= moveSpeed * Time.deltaTime;
            transform.position = temp;
        }
        else if (Usable.score > 300)
        {
            moveSpeed = 6f;
            Vector3 temp = transform.position;
            temp.x -= moveSpeed * Time.deltaTime;
            transform.position = temp;
        }
        else
        {
            moveSpeed = 5f;
            Vector3 temp = transform.position;
            temp.x -= moveSpeed * Time.deltaTime;
            transform.position = temp;
        }
       
    }
    private void Reposition()
    {
        if (transform.position.x < cameraX)
        {
            float highestBoundsX = sideBounds[0].transform.position.x;
            for (int i = 1; i < sideBounds.Length; i++)
            {
                if(highestBoundsX < sideBounds[i].transform.position.x)
                {
                    highestBoundsX = sideBounds[i].transform.position.x;
                }
            }
            Vector3 temp = transform.position;
            temp.x = highestBoundsX+boundWIdth-0.5f;
            transform.position = temp;
        }
    }
}
