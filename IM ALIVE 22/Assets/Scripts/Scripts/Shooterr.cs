using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooterr : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float currentTime = 0.0f;
    [SerializeField]public float nextFire;
    public Transform projectileSpawn;

    public void Start()
    {
        projectileSpawn = this.gameObject.transform;
    }

    public void Fire()
    {
        currentTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && currentTime > nextFire)
        {
            nextFire += currentTime;

            Instantiate(bulletPrefab, projectileSpawn.position, Quaternion.identity);

            nextFire -= currentTime;
            currentTime = 0.0f;
        }
    }
    public void Update()
    {
        Fire();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
