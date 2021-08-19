using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("TurnLeft", true);
            anim.SetBool("TurnRight", false);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("TurnRight", true);
            anim.SetBool("TurnLeft", false);

        }
        else
        {
            anim.SetBool("TurnLeft", false);
            anim.SetBool("TurnRight", false);
        }
    }
}
