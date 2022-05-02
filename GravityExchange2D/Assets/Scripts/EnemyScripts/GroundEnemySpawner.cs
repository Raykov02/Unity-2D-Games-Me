using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    private GameObject spawnedEnemy;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawn()
    {
        while (Usefull.isAlive)
        {
            yield return new WaitForSeconds(Random.Range(3, 6));
            if (Random.Range(1, 11) <= 8)
            {
                spawnedEnemy = Instantiate(enemy[0]);
                spawnedEnemy.transform.position = gameObject.transform.position;
            }
            else
            {
                spawnedEnemy = Instantiate(enemy[1]);
                spawnedEnemy.transform.position = gameObject.transform.position;
                if(spawnedEnemy.transform.position.y<0)
                spawnedEnemy.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.7f, gameObject.transform.position.z);
                else
                    spawnedEnemy.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.7f, gameObject.transform.position.z);

            }
        }
    }
}
