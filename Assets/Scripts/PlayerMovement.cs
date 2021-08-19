using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;//speed of player to move 
    [SerializeField] GameObject laserPrefab;//prefab for instantiating
    float canfire = 0f;//counting with fire rate
    [SerializeField] float fireRate;//for how many seconds the laser instantiate
    public bool tripleShot = false;//varible for checking whether the tripleshot is collected or not
    [SerializeField] bool isSpeedPwerUpActive = false;//variable to know wheather player collected speed powerup or not
    [SerializeField] bool isPowerShield = false;//variable to know whether power shield is collected or not
    [SerializeField] GameObject tripleLaserPrefab;//accessing triple shot laser
    public int playerHealth=3;//starting power health
    //int powerShieldHealth;//power health after collecting powershield
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject shield;
    UIManager uiManager;
    GameManager gameManager;
    SpawnManager spawnManager;
    AudioSource audioSource;
    public AudioClip laserClip;
    public AudioClip shieldClip;
    public AudioClip playerExplosionClip;
    [SerializeField] GameObject[] engineFail;
    int hitCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);//when we play the game player start from origin 
        //powerShieldHealth = playerHealth;//initializing player health to powershiled
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        audioSource =GameObject.Find("SoundManager").GetComponent<AudioSource>();
        if (uiManager != null)
        {
            uiManager.UpdateLives(playerHealth);
        }
        if (spawnManager != null)
        {
            spawnManager.CoroutinesFunctions();
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Player input movement along axis
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            Key(Vector3.right, Input.GetAxis("Horizontal"));
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            Key(Vector3.up, Input.GetAxis("Vertical"));
        }
        //Player  Boundarys in x and y direction
        XYDirection(transform.position.x, transform.position.y);
        //Shooting laser using prefab and firerate
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();
        }
        //if powershield collected player health changes to starting player health
        
    }
    public void Shoot()
    {

        if (Time.time > canfire)
        {
            //if triple shot is true shoot three lasers if not one laser
            if (tripleShot==true)
            {

                Instantiate(tripleLaserPrefab, transform.position, Quaternion.identity);
                //Instantiate(laserPrefab, transform.position + new Vector3(0.65f, 0.2f, 0), Quaternion.identity);
                //Instantiate(laserPrefab, transform.position + new Vector3(-0.65f, 0.2f, 0), Quaternion.identity);
                canfire = Time.time + fireRate;
                audioSource.clip = laserClip;
                audioSource.Play();
            }
            //single shot
            else
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
                canfire = Time.time + fireRate;
                audioSource.clip = laserClip;
                audioSource.Play();
            }


        }
    }
        //Method for x and y boundarys for player
    public void XYDirection(float Xval, float Yval)
    {
            if (Yval > 0)
            {
                transform.position = new Vector3(Xval, 0, 0);
            }
            else if (Yval < -4.1f)
            {
                transform.position = new Vector3(Xval, -4.1f, 0);
            }
            if (Xval >= 10f)
            {
                transform.position = new Vector3(-10f, Yval, 0);
            }
            else if (Xval <= -10f)
            {
                transform.position = new Vector3(10f, Yval, 0);
            }
    }
    //method for player moving in axis
    public void Key(Vector3 vector, float axis)
    {
        //if speed power enabled then move 2x faster than normal speed else normal speed
        if (isSpeedPwerUpActive)
        {
            transform.Translate(vector * Time.deltaTime * moveSpeed*2 * axis);

        }
        else
        {
            transform.Translate(vector * Time.deltaTime * moveSpeed * axis);

        }
    }
    //this for when collected tripleshot object ,tripleshot shot bool will be true
    public void TripleShotPowerUp()
    {
        tripleShot = true;
        StartCoroutine("TripleShotPowerDown");

    }
    //method to enable speed power up and power down
    public void SpeedPowerUpOn()
    {
        isSpeedPwerUpActive = true;
        StartCoroutine("SpeedPowerDown");
    }
    //method to enable power shield
    public void PowerShieldOn()
    {
        //StartCoroutine("PowerShieldOff");
        isPowerShield = true;
        shield.SetActive(true);
        audioSource.clip = shieldClip;
        audioSource.Play();
    }
    IEnumerator TripleShotPowerDown()
    {
        yield return new WaitForSeconds(5);
        tripleShot = false;
    }
    IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(5);

        isSpeedPwerUpActive = false;
    }
    IEnumerator PowerShieldOff()
    {
        yield return new WaitForSeconds(5);

        isPowerShield = false;
    }
    //decreasing player health when collides with enemy
    public void Damage()
    {
        hitCount ++;
        if (hitCount == 1)
        {
            engineFail[0].SetActive(true);

        }
        else if (hitCount == 2)
        {
            engineFail[1].SetActive(true);
        }
        //if player has power shield no damage else damage
        if (isPowerShield)
        {
            isPowerShield = false;
            shield.SetActive(false);
            return;
            //StartCoroutine("PowerShieldOff");
        }
        else
        {
            playerHealth--;
            uiManager.UpdateLives(playerHealth);
            if (playerHealth <1)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                gameManager.gameOver = true;
                audioSource.clip = playerExplosionClip;
                audioSource.Play();
                Destroy(this.gameObject);
                uiManager.GameOverScreenOn();
            }
        }
        
    }
}

