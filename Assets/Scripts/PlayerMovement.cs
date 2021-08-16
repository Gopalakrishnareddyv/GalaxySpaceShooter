using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject laserPrefab;
    [SerializeField]float canfire;
    [SerializeField]float fireRate=0.25f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed*horizontal);
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed*vertical);


        //Player Y Boundarys
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.1f)
        {
            transform.position = new Vector3(transform.position.x, -4.1f, 0);
        }
        //Player X Boundarys
        if (transform.position.x >=10f )
        {
            transform.position = new Vector3(-10f, transform.position.y, 0);
        }
        else if (transform.position.x <= -10f)
        {
            transform.position = new Vector3(10f,transform.position.y, 0);
        }
        
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButton(0))
        {
            if (Time.time > canfire)
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
                canfire = Time.time + fireRate;
            }

        }
    }
}
