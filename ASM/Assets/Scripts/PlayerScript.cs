using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    //move force tốc độ di chuyển, jumForce độ nhảy
    public SoundManager audioSource;
    public float moveForce = 40f;
    public float jumForce = 400f;
    //tốc độ tối thiểu
    public float maxVelocity = 4f;
    //animation 
    private Animator anim;
    //giridbody
    private Rigidbody2D myBody;
    bool grounded;
    //hàm này để khởi tạo 
    private void Awake()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        //int mang= 3; istrigger tag destroy mang = mang -1
        // neu mang =0, destroy game object
        //cho 1 tranfrom.position hồi sinh

    }
    // Use this for initialization
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        RunPlayer();
    }

    void RunPlayer()
    {
        //bàn đầu cho force x= tốc độ di chuyển, for x độ nhảy
        float forceX = 0f;
        float forceY = 0f;
        //Mathf.Abs đưa về giá trị dương
        float vel = Mathf.Abs(myBody.velocity.x);//tinh van toc hien tai

        float h = Input.GetAxisRaw("Horizontal");//di chuyen theo chieu ngang
        //h > 0 la phim phai, h<0 phim trai, h =0 k bam
        if (h > 0)
        {
            //neu van toc hien tai nho hon van toc toi thiểu
            if (vel < maxVelocity)
            {
                //neu cham dat tag ground
                if (grounded)
                {
                    //set forcex
                    forceX = moveForce;
                }
                else
                {
                    forceX = moveForce * 1.1f;
                }
            }

            Vector3 scale = transform.localScale;
            //1f là qua phải , -1f thì ngược lại
            scale.x = 1f;
            transform.localScale = scale;


        }
        else if (h < 0)
        {

            //neu van toc hien tai nho hon van toc toi da
            if (vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = -moveForce;
                }
                else
                {
                    forceX = -moveForce * 1.1f;
                }
            }

            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;



        }
        else
        {
            //neu van toc hien tai nho hon van toc toi da



        }
        //khi chúng ta nhấn space
        if (Input.GetKey(KeyCode.Space))
        {
            audioSource.Playsound("jump");
            if (grounded)
            {
                //xet độ nhảy
                forceY = jumForce;
                //grounded = false
                grounded = false;

                anim.SetBool("jump", true);

            }
        }
        //temp positon vị trí player
        Vector3 temp = transform.position;
        //forceX, ForceY
        myBody.AddForce(new Vector2(forceX, forceY));
    }
    //OnCollision  nếu có trigger thì dùng cái này

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            //có va chạm với ground => true
            grounded = true;
            anim.SetBool("jump", false);


        }
        else if(collision.gameObject.tag == "Dead")
        {
            audioSource.Playsound("destroy");
            Destroy(gameObject);
            if (BntPause.insance != null) {
                BntPause.insance.panelDead.SetActive(true);
            }
            Time.timeScale = 0;
            if (PlayerPrefs.HasKey("highscore"))
            {
                if (PlayerPrefs.GetFloat("highscore") < CountCoin.instance.Total_coin)
                {
                    PlayerPrefs.SetFloat("highscore", CountCoin.instance.Total_coin);
                }
            }
            else
            {
                PlayerPrefs.SetFloat("highscore", CountCoin.instance.Total_coin);
            }
        }

    }

   
}
