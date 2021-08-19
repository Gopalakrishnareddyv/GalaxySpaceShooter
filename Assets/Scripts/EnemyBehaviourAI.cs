using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourAI : MonoBehaviour
{
    [SerializeField] float enemySpeed;//enemey Speed
    [SerializeField] GameObject enemyExplosion;
    UIManager uiManager;
    AudioSource sound;
    public AudioClip explosionClip;
    //[SerializeField] AudioClip explosionClip;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        sound = GameObject.Find("SoundManager").GetComponent<AudioSource>();
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
            uiManager.UpdateScore();
            Destroy(collision.gameObject);
            sound.clip = explosionClip;
            sound.Play();
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
            //audioSource.clip = explosionClip;
            //audioSource.Play();
            Destroy(this.gameObject);
        }
    }
}
