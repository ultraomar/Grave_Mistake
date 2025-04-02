using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour


    
{


    private Rigidbody2D rb;
    private float horizontal;
    private Animator anim;

    [SerializeField] private float runSpeed = 5.0f;
    //[SerializeField] private float jumpForce = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(horizontal * runSpeed * Time.deltaTime, 0, 0);



        if (horizontal > 0)
        {
            anim.SetBool("Walk_R", true);
        }
        else
        {
            anim.SetBool("Walk_R", false);
        }
        if (horizontal < 0)
        {
            anim.SetBool("Walk_L", true);
        }
        else
        {
            anim.SetBool("Walk_L", false);
        }

    }
}
