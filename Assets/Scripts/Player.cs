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
    [SerializeField] private float jumpForce = 5.0f;

    //contador de gemas
    public TextMeshProUGUI txtContador;
    private int Contador;

    //gema
    public GameObject gema;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Contador = 0;
        gema.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        transform.Translate(horizontal * runSpeed * Time.deltaTime, 0, 0);

        txtContador.text = "" + Contador; //score

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

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.0001)
        {
            //anim.SetBool("Jump", true);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
           
        }
        // Set Jump animation based on vertical velocity
       /* if (Mathf.Abs(rb.velocity.y) > 0.85f)
        {
            anim.SetBool("Jump", true); // Player is in the air
        }
        else
        {
            anim.SetBool("Jump", false); // Player is on the ground
        }

        */

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("gema"))
        {
            //anillo.gameObject.SetActive(false);

            Destroy(other.gameObject);
            Contador += 1;
       
        }
       
    }
}
