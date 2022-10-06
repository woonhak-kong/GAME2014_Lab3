using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;

    public Boundary boundary;
    private Camera camera;

    public ScoreManager scoreManager;

    [Header("Bullet Properties")]
    public Transform bulletPosition;
    public float fireRate = 0.2f;
    public BulletManager bulletManager;
    



    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        bulletManager = FindObjectOfType<BulletManager>();

        transform.position = Vector2.zero;
        camera = Camera.main;

        InvokeRepeating("FireBullets", 0.0f, fireRate);
    }

    // Update is called once per frame
    void Update()
    {

        GetConventionalInput();
        GetMobileInput();

        if (Input.GetKeyDown(KeyCode.K))
        {
            scoreManager.AddPoint(10);
        }


    }

    public void GetConventionalInput()
    {
        float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");

        float moveSpeedX = x * speed * Time.deltaTime;
        //float moveSpeedY = y * speed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + moveSpeedX, -4);
        CheckBound();
    }

    public void CheckBound()
    {
        if (transform.position.x < boundary.min)
        {
            transform.position = new Vector2(boundary.min, transform.position.y);
        }

        if (transform.position.x > boundary.max)
        {
            transform.position = new Vector2(boundary.max, transform.position.y);
        }
    }

    public void GetMobileInput()
    {
       
        foreach(Touch touch in Input.touches)
        {
            Vector3 destination = camera.ScreenToWorldPoint(touch.position);
            //transform.position = new Vector3(destination.x, destination.y);
            //transform.position = touch.position;
            transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime * speed);
        }


        CheckBound();
    }

    void FireBullets()
    {
        bulletManager.GetBullet(bulletPosition.position, BulletDirection.UP);
    }
}
