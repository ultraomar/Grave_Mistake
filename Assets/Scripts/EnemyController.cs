using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
        [SerializeField] private float speed = 1.0f;
//        [SerializeField] private int hp = 2;
//        [SerializeField] private int attack = 1;
//        private Vector2 movement;
        public int direction = 1;
        public Vector2 CurPos;
        public float posX = 0.0f;
        private Animator anim;
        [SerializeField] private float initTime = 2.0f;
        private float totalTime;
        private bool coinIsHeads = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        totalTime = initTime;

        // Set default animation as Walk.
        anim.SetBool("Walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        // While total time has not expired, the Ant keep moving on the same direction.
        if (totalTime > 0)
        {
            //Subtract elapsed time every frame.
            totalTime -= Time.deltaTime;
        }
        // If total time has expired, restart timer and change direction.
        else
        {
            // Reset total time.
            totalTime = initTime;

            // Toss a coin to randomize the direction of the Fox to make it more unpredictable.
            coinIsHeads = Random.value < 0.5f;

            // Change direction and Flip the sprite accordingly.
            if (coinIsHeads == true)
            {
                direction = 1;
                // Change enemy orientation
                this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            }
            else
            {
                direction = -1;
                // Change enemy orientation
                this.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
            }
        }
    }

    private void FixedUpdate()
    {
        // Update Enemy position.
        CurPos = transform.position;
        posX = speed * Time.deltaTime;
        this.transform.Translate(new Vector3(posX, 0));
    }
}