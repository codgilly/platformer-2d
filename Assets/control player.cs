using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class controlplayer : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        int speed = 10;
    }

    // Update is called once per frame
    void Update()
    {

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
            
        }

    }

    void DoRunR()
    {
        if (Input.GetKey("d") == true)
        {
            int speed = 10;
            anim.SetBool(("run"), true);
            sr.flipX = false;
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        }
    }
    void DoRunL()
    {
        if (Input.GetKey("a") == true)
        {
            int speed = 10;
            anim.SetBool(("run"), true);
            sr.flipX = true;
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
        }
    }
}