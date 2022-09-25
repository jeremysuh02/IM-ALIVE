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

    public void Fire() {
        currentTime += Time.deltaTime;
        if (currentTime > nextFire) {
            nextFire += currentTime;
            Instantiate(arrowBullet, projectileSpawn.position, Quaternion.identity);
            nextFire -= currentTime;
            currentTime = 0.0f;
        }
    }
    public void Update() {
        Fire();
    }

    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Floor") {
            Destroy(arrowBullet);
        }
    }
}