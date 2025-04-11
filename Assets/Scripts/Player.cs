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

    [SerializeField] private float fallMultiplier = 2.5f;       // Caída más rápida
    [SerializeField] private float lowJumpMultiplier = 2.0f;    // Saltos cortos si sueltas rápido

    public TextMeshProUGUI txtContador;
    private int Contador;

    public GameObject gema;

    public TextMeshProUGUI txtTimer;
    private float timeValue;

    public GameObject ganaste;
    public GameObject perdiste;
    private PlayerHealth playerHealth;

    // Agregar referencia al AudioSource
    private AudioSource audioSource;
    public AudioClip recoleccionSonido; // Drag and drop your sound clip here in the inspector
    public AudioClip enemy;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>(); // Obtén el AudioSource

        Contador = 0;
        gema.gameObject.SetActive(true);

        timeValue = 100;

        ganaste.gameObject.SetActive(false);
        perdiste.gameObject.SetActive(false);
        playerHealth = Object.FindFirstObjectByType<PlayerHealth>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(horizontal * runSpeed * Time.deltaTime, 0, 0);

        txtContador.text = "" + Contador;
        timeValue -= Time.deltaTime;
        txtTimer.text = FormatearTiempo(timeValue);

        string FormatearTiempo(float timeValueo)
        {
            string minutos = Mathf.Floor(timeValue / 60).ToString("00");
            string segundos = Mathf.Floor(timeValue % 60).ToString("00");
            return "Time:" + minutos + ":" + segundos;
        }

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

        // SALTO con tolerancia
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.5f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }



        if (Contador == 6)

            if (rb.linearVelocity.y < 0)

            {
                rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.linearVelocity.y > 0 && !Input.GetKey(KeyCode.Space))
            {
                rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }

        if (timeValue <= 0)
        {
            perdiste.gameObject.SetActive(true);
            Time.timeScale = 0;
            runSpeed = 0;
            jumpForce = 0;
            txtTimer.gameObject.SetActive(false);
        }

        if (playerHealth.HealthCount == 0)
        {
            perdiste.gameObject.SetActive(true);
            Time.timeScale = 0;
            runSpeed = 0;
            jumpForce = 0;
            txtTimer.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Recolectar gema
        if (other.gameObject.CompareTag("gema"))
        {
            // Reproduce el sonido de recolección
            audioSource.PlayOneShot(recoleccionSonido);

            Destroy(other.gameObject);
            Contador += 1;
        }

        // Colisión con la meta para ganar
        if (other.gameObject.CompareTag("Meta"))
        {
            ganaste.gameObject.SetActive(true);
            runSpeed = 0;
            jumpForce = 0;
            Time.timeScale = 0;
            txtTimer.gameObject.SetActive(false);
        }


        if (other.gameObject.tag == "collider")
        {

            transform.position = new Vector3(-7, -3, 0);

        }

        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            audioSource.PlayOneShot(enemy);

        }

    }
    }
