using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] powerups;
    GameManager gameManager;
    //Spawn enemy for every 10 seconds using coroutine function
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void CoroutinesFunctions()
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(PowerUpSpawn());
    }
    IEnumerator EnemySpawn()
    {
        //Debug.Log(gameManager.gameOver);
        while (gameManager.gameOver==false)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-8f, 8f), 6f, 0f),Quaternion.identity);
            yield return new WaitForSeconds(10);
        }
    }
    IEnumerator PowerUpSpawn()
    {

        //Debug.Log(gameManager.gameOver);
        while (gameManager.gameOver==false)
        {
            //Debug.Log("Entered");
            int randomPowerUp = Random.Range(0, powerups.Length);
            Instantiate(powerups[randomPowerUp], new Vector3(Random.Range(-8f, 8f), 6f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(10);
        }
        
    }
}
