using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class controlplayer : MonoBehaviour
{

    private bool isFalling;
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        isFalling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }
        anim.SetBool("fall", isFalling);
        anim.SetBool("jump", false);
        anim.SetBool("run", false);
        anim.SetBool("idle", true);

        DoAttack();
        DoJump();
        DoRunL();
        DoRunR();


    }

     void DoAttack()
    {
        if (Input.GetKeyDown("v"))
        {
            anim.SetTrigger("attack");
        }
    }

    void DoJump()
    {
        if (Input.GetKey("space") == true)
        {
            anim.SetBool("jump", true);
            rb.AddForce(new Vector3(0, 1, 0), (ForceMode2D)ForceMode2D.Impulse);
            anim.SetBool("fall", isFalling);
        }

        

    }



    void DoRunR()
    {
        float speed = 7f;
        if (Input.GetKey("left shift") == true)
        {
            speed = speed * 2;
        }

        if (Input.GetKey("d") == true)
        {
           
            anim.SetBool(("run"), true);
            sr.flipX = false;
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        }

    }
    void DoRunL()
    {
        float speed = 7f;
        if (Input.GetKey("left shift") == true)
        {
            speed = speed * 2;
        }

        if (Input.GetKey("a") == true)
        {
            
            anim.SetBool(("run"), true);
            sr.flipX = true;
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
        }
       
    }
    

}