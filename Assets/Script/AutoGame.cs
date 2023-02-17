using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGame : MonoBehaviour
{
    public GameObject perfabPipe;
    private float countDown;
    public float timeWait;
    public bool browserPipe;

    private void Awake()
    {
        countDown = 2f;
        browserPipe = false;
    }
    // Pipe production()
    void Update()
    {
        if (browserPipe == true)
        {
            // deltaTime = 1/fps
            countDown -= Time.deltaTime;
            // Reset
            if (countDown <= 0)
            {
                // Born object: perfabPipe
                // Postion coordinates: vector (x, y, z)
                // Rotation coordinates do not need
                Instantiate(perfabPipe, new Vector3(10, Random.Range(-1.2f, 2.1f), 0), Quaternion.identity);
                countDown = timeWait;
            }
        }
    }
}
