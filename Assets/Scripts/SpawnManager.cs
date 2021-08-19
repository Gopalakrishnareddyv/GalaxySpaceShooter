using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] powerups;
    GameManager gameManager;
    //Spawn enemy for every 5 seconds using coroutine function
    private void Start()
    {
        
        StartCoroutine("EnemySpawn");
        StartCoroutine("PowerUpSpawn");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void CoroutinesFunctions()
    {
        StartCoroutine("EnemySpawn");
        StartCoroutine("PowerUpSpawn");
    }
    IEnumerator EnemySpawn()
    {
        while (gameManager.gameOver==false)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-8f, 8f), 6f, 0f),Quaternion.identity);
            yield return new WaitForSeconds(10);
        }
    }
    IEnumerator PowerUpSpawn()
    {
        while (gameManager.gameOver==false)
        {
            int randomPowerUp = Random.Range(0, powerups.Length);
            Instantiate(powerups[randomPowerUp], new Vector3(Random.Range(-8f, 8f), 6f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(10);
        }
        
    }
}
