using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private void Awake()
    {
        player.transform.position = gameObject.transform.position;
        Instantiate(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
