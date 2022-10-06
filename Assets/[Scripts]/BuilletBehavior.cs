using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public enum BulletDirection
{
    UP,
    RIGHT,
    DOWN,
    LEFT
}

[System.Serializable]
public struct ScreenBounds
{
    public Boundary horizontal;
    public Boundary vertical;
}

public class BuilletBehavior : MonoBehaviour
{
    public BulletDirection bulletDirection;
    public float speed;
    
    public ScreenBounds bounds;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        SetDirection(bulletDirection);
    }

    public void SetDirection(BulletDirection direction)
    {
        switch (direction)
        {
            case BulletDirection.UP:
                velocity = Vector3.up;
                break;
            case BulletDirection.RIGHT:
                velocity = Vector3.right;
                break;
            case BulletDirection.DOWN:
                velocity = Vector3.down;
                break;
            case BulletDirection.LEFT:
                velocity = Vector3.left;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBound();
    }

    void Move()
    {
        transform.position += velocity * speed * Time.deltaTime;
    }

    void CheckBound()
    {
        if ((transform.position.x > bounds.horizontal.max) ||
            (transform.position.x < bounds.horizontal.min) ||
            (transform.position.y > bounds.vertical.max) ||
            (transform.position.y < bounds.vertical.min))
        {
            BulletManager.Instance.ReturnBullet(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletManager.Instance.ReturnBullet(this.gameObject);
    }
}
