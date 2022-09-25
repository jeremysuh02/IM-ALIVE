using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroWave : MonoBehaviour
{
    public GameObject IntroCircleWave;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(IntroCircleWave);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
