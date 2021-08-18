using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourAI : MonoBehaviour
{
    [SerializeField] float enemySpeed;//enemey Speed
    [SerializeField] GameObject enemyExplosion;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        //MoveDown
        transform.Translate(Vector2.down * enemySpeed * Time.deltaTime);
        //When enemy off the screen on the bottom need to respawn with random new position of x 
        if (transform.position.y <= -6f)
        {
            transform.position = new Vector3(Random.Range(-8f, 8f), 6f, 0);
            

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision with laser
        if (collision.tag == "Laser")
        {
            if (collision.transform.parent != null)
            {
                Destroy(collision.transform.gameObject);
            }
            Destroy(collision.gameObject);
            Instantiate(enemyExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        //collision with player
        else if (collision.tag == "Player")
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.Damage();
            }
            
            Destroy(this.gameObject);
        }
    }
}
