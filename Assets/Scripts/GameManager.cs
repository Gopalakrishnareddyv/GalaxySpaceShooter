using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //if game over is true then press space key to respawn the player else gomeover title will be inactive
    public bool gameOver = true;
    public GameObject player;
    UIManager uiManager;
    SpawnManager spawnManager;
    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //gameover screen to be inacative and player needs to respawn
                Instantiate(player, Vector3.zero, Quaternion.identity);
                gameOver = false;
                uiManager.GameOverScreenOff();
            }
        }
    }
}
