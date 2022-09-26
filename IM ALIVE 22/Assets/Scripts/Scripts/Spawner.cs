using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject FirstWave;
    public List<GameObject> Waves = new List<GameObject>();
    public GameObject[] enemyWaves;
    public int x = 0;
    int randomInt;
    public GameObject empty;
    // Start is called before the first frame update
    void Start()
    {
        randomInt = Random.Range(0, 2);
        GameObject newWave = Instantiate(FirstWave);
        newWave.transform.parent = transform;
        Waves.Add(newWave);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            Waves.Clear();
            
        }
        if (Waves.Count == 0)
        {
           
        }
        
       
    }
    void spawn()
    {
        GameObject w = enemyWaves[Random.Range(0, enemyWaves.Length)];
        Instantiate(w);
        
    }
}
