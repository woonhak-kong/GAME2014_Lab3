using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> bulletPool;
    public GameObject bulletPrefab;
    public GameObject bulletParent;
    public int bulletFired = 0;
    public int bulletLeft = 0;
    [Range(10, 200)]
    public int bulletNumber = 15;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new Queue<GameObject>();
        BuildBulletPool();
    }

    void BuildBulletPool()
    {
        for (int i = 0; i < bulletNumber; i++)
        {
            CreateBullet();
        }
    }

    private void CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false);
        bullet.transform.SetParent(bulletParent.transform);
        bulletPool.Enqueue(bullet);
        bulletLeft++;
    }

    public GameObject GetBullet(Vector2 position, BulletDirection direction)
    {
        if (bulletPool.Count < 1)
        {
            CreateBullet();
        }
        GameObject bullet = bulletPool.Dequeue();
        bulletFired++;
        bulletLeft--;
        bullet.SetActive(true);
        bullet.transform.position = position;
        bullet.GetComponent<BuilletBehavior>().SetDirection(direction);
        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
        bulletFired--;
        bulletLeft++;
    }

}
