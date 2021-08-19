using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotAndPowerUp : MonoBehaviour
{
    [SerializeField]float tripleShotPowerup=3f;
    [SerializeField]int powerUpID;//0=tripleshot,1=speed boost,2=powershield
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * tripleShotPowerup);
        if (transform.position.y <= -6f)
        {
            //transform.position = new Vector3(Random.Range(-8f, 8f), 6f, 0);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
            {
                if (powerUpID == 0)
                {
                    //for tripleshot
                    player.TripleShotPowerUp();
                }
                else if (powerUpID == 1)
                {
                    //for powerboost
                    player.SpeedPowerUpOn();
                }
                else if (powerUpID == 2)
                {
                    //for shields
                    player.PowerShieldOn();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
