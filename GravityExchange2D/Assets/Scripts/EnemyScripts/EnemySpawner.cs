using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    private GameObject spawnedEnemy;
    private bool canspawn = true;
    void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(meteors());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawn()
    {
        while (true)
        {


            yield return new WaitForSeconds(Random.Range(4, 8));
            spawnedEnemy = Instantiate(enemy[Random.Range(0, 2)]);
            spawnedEnemy.transform.position = gameObject.transform.position;
        }
    }
    IEnumerator meteors()
    {
        while (true)
        {
            if (Usable.score > 1000)
            {
                yield return new WaitForSeconds(5);
            }else if(Usable.score > 600)
            {
                yield return new WaitForSeconds(6);
            }else if(Usable.score > 300)
            {
                yield return new WaitForSeconds(8);

            }
            else
            {
                yield return new WaitForSeconds(10);

            }
            spawnedEnemy = Instantiate(enemy[2]);
            spawnedEnemy.transform.position = gameObject.transform.position;

        }
    }
}
