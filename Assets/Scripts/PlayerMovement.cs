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
    public bool tripleShot = false;
    [SerializeField] GameObject tripleLaserPrefab;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);//when we play the game player start from origin 
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

            }
            else
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
                canfire = Time.time + fireRate;
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
            transform.Translate(vector * Time.deltaTime * moveSpeed * axis);
        }
    public void TripleShotPowerUp()
    {
        tripleShot = true;
        StartCoroutine("TripleShotPowerDown");

    }
    public IEnumerator TripleShotPowerDown()
    {
        yield return new WaitForSeconds(2);
        tripleShot = false;
    }
    
}

