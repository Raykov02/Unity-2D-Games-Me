using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Usefull.isAlive)
        {
            if (Usable.score > 1000)
            {
                transform.position += new Vector3(-9f * Time.deltaTime, 0f, 0f);
            }
            else if (Usable.score > 600)
            {
                transform.position += new Vector3(-8f * Time.deltaTime, 0f, 0f);
            }
            else if (Usable.score > 300)
            {
                transform.position += new Vector3(-7f * Time.deltaTime, 0f, 0f);

            }
            else
            {
                transform.position += new Vector3(-6f * Time.deltaTime, 0f, 0f);

            }
        }
    }
}
