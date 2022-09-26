using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour {
    public GameObject arrowBullet;
    public float currentTime = -5f;
    [SerializeField]public float nextFire = 0.1f;
    public Transform projectileSpawn;

    public void Start() {
        projectileSpawn = this.gameObject.transform;
    }

    public GameObject Fire() {
        GameObject bulletInstance = null;
        currentTime += Time.deltaTime;
        if (currentTime > nextFire) {
            nextFire += currentTime;
            bulletInstance = Instantiate(arrowBullet, projectileSpawn.position, Quaternion.identity);
            nextFire -= currentTime;
            currentTime = 0.0f;
        }
        return bulletInstance;
    }
    public void Update() {
        GameObject bInstance = Fire();
        if (bInstance != null) {
            destroyObject(bInstance);
        }
    }

    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Floor") {
            Destroy(arrowBullet);
        }
    }

    void destroyObject(GameObject obj) {
        if (obj.transform.position.y < GameObject.FindWithTag("Floor").transform.position.y) {
            Destroy(obj);
        }
    }
}