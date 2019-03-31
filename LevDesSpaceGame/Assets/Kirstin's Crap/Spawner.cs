using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemySpawner;
    private GameObject theEnemy;

    float randX;
    float randZ;
    float randY;

    // Update is called once per frame
    void Update()
    {
        randX = Random.Range(-85, 100);
        randZ = Random.Range(-10, 20);
        randY = Random.Range(-40, 30);

        if(theEnemy == null)
        {
            theEnemy = Instantiate(enemySpawner) as GameObject;
            theEnemy.transform.position = new Vector3(randX, randY, randZ);

            float angle = Random.Range(0, 360);
            theEnemy.transform.Rotate(0, angle, 0);
        }
    }
}
