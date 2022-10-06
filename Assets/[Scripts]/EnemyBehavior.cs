using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Boundary HorizontalBoundary;
    public Boundary VerticalBoundary;
    public Boundary screenBounds;
    public float horizontalSpeed;
    public float verticalSpeed;
    
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ResetEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBound();
    }

    void Move()
    {
        var boundaryLength = HorizontalBoundary.max - HorizontalBoundary.min;
        transform.position = new Vector3(Mathf.PingPong(Time.time * horizontalSpeed, boundaryLength) - HorizontalBoundary.max, transform.position.y + -verticalSpeed * Time.deltaTime, 0);
    }

    public void CheckBound()
    {
        if (transform.position.y < screenBounds.min)
        {
            ResetEnemy();
        }

    }


    private void ResetEnemy()
    {
        var startingPosition = Random.Range(HorizontalBoundary.min, HorizontalBoundary.max);
        
        verticalSpeed = Random.Range(1.0f, 3.0f);
        horizontalSpeed = Random.Range(1.0f, 6.0f);
        transform.position = new Vector3(startingPosition, 3.0f, 0.0f);
        transform.position = new Vector2(0, screenBounds.max);

        List<Color> colorList = new List<Color>();
        colorList.Add(Color.red);
        colorList.Add(Color.yellow);
        colorList.Add(Color.magenta);
        colorList.Add(Color.cyan);
        colorList.Add(Color.white);

        Color ramdomColor = colorList[Random.Range(0, colorList.Count)];
        spriteRenderer.material.SetColor("_Color", ramdomColor);
    }
}
