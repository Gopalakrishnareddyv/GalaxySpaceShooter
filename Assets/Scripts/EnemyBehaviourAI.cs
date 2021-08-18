using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourAI : MonoBehaviour
{
    [SerializeField] float enemySpeed;//enemey Speed
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
            anim.SetBool("EnemyDie", false);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            if (collision.transform.parent != null)
            {
                Destroy(collision.transform.gameObject);
            }
            Destroy(collision.gameObject);
            anim.SetBool("EnemyDie", true);
            //Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.Damage();
            }
            anim.SetBool("EnemyDie", true);

            //Destroy(this.gameObject);
        }
    }
}
