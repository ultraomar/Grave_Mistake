 using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject pause;

   



    void Start()
    {

       

    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))

        {
            pause.SetActive(true);
            
            Time.timeScale = 0f;
            
        }

    }

    public void Resume()
    {


        pause.SetActive(false);
      

       Time.timeScale = 1f;
      

    }
}
