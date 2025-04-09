using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Jugar();
        Salir();
        Menu();
        Créditos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Jugar()
    {

        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;

    }



   
    public void Menu()
    {

        SceneManager.LoadScene("Menu_inicio");

    }




    public void Créditos()
    {

        SceneManager.LoadScene("Credits");

    }


    public void Salir()
    {

        Application.Quit();
        Debug.Log("salio del juego");
    }


}
