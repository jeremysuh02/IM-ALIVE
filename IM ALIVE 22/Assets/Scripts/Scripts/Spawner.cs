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
            for (int i = 0; i < 2; i++)
            {
                GameObject newEmpty = Instantiate(empty);
                newEmpty.transform.parent = transform;
                Waves.Add(newEmpty);
            }
        }
        
        if (transform.childCount == 2)
        {
            spawn();
        }
    }
    void spawn()
    {
        Instantiate(enemyWaves[Random.Range(0, enemyWaves.Length)]);
    }
}
