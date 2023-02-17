using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speedPipe;

    void Update()
    {
        movePipe();
    }

    private void movePipe()
    {
        // deltaTime = 1/fps
        // default speed regardless of jerk/lag
        transform.position += Vector3.left * speedPipe * Time.deltaTime;
    }
}
