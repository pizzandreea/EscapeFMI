using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    [SerializeField]
    private float xStart;

    [SerializeField]
    private float yStart;

    [SerializeField]
    private float xEnd;

    [SerializeField]
    private float yEnd;


    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float enemyInterval = 1f;

    [SerializeField]
    private int enemiesNumber = 5;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= enemiesNumber; i++)
        {
            var pos = new Vector3(Random.Range(-xStart, xEnd), Random.Range(-yStart, yEnd), 0);
            spawnEnemy(enemyInterval, enemyPrefab, pos);
        }
    }
    
    private void spawnEnemy(float interval, GameObject enemy, Vector3 pos)
    {
        //yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, pos, Quaternion.identity);
    }
}
