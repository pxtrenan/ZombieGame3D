using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    public GameObject enemy;
    public int xPos;
    public int zPos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());    
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 20)
        {
            xPos = Random.Range(1, 30);
            zPos = Random.Range(1, 11);
            if (!Object.ReferenceEquals(enemy, null))
            {
                Instantiate(enemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
                enemyCount += 1;
            }
            yield return new WaitForSeconds (2f);
        }
    }

    void Update()
    {
        
    }
}