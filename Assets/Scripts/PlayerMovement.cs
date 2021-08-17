using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject laserPrefab;
    [SerializeField]float canfire=0f;
    [SerializeField]float fireRate=0.25f;
    Vector3 directionKey;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Player input movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.LeftArrow))
        {
            Key(Vector3.right, horizontal);
        }
        else if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.DownArrow))
        {
            Key(Vector3.up, vertical);
        }
        //Player  Boundarys
        XYDirection(transform.position.x,transform.position.y);
        //Instantiating laser
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButton(0))
        {
            if (Time.time > canfire)
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
                canfire = Time.time + fireRate;
            }

        }
      
    }

    private void XYDirection(float Xval,float Yval)
    {
        if (Yval > 0)
        {
            transform.position = new Vector3(Xval,0, 0);
        }
        else if (Yval < -4.1f)
        {
            transform.position = new Vector3(Xval,-4.1f, 0);
        }
        if (Xval >=10f)
        {
            transform.position = new Vector3(-10f, Yval, 0);
        }
        else if (Xval <= -10f)
        {
            transform.position = new Vector3(10f, Yval, 0);
        }
    }
    public void Key(Vector3 vector,float axis)
    {
      
        transform.Translate(vector * Time.deltaTime * moveSpeed * axis);
    }
}
