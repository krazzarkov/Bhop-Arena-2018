using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YbotController : MonoBehaviour
{
    CharacterController controller;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ///////// Run Forward //////////////
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("condition", 1);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("condition", 0);
        }
        //////////////////////////////////
        ///////// Run Backward //////////
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("condition", 2);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetInteger("condition", 0);
        }
        /////////////////////////////////
        //////////// Run Right ///////////
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("condition", 3);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("condition", 0);
        }
        ////////////////////////////////
        ////////// Run Left ///////////
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetInteger("condition", 4);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("condition", 0);
        }
    }
}
