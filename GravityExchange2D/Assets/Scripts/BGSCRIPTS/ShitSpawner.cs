using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitSpawner : MonoBehaviour
{
    public GameObject smth;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(smth);
        smth.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
