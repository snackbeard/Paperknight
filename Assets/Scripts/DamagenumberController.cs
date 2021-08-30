using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagenumberController : MonoBehaviour
{
    public float ttl;
    private float timer = 0;
    // Update is called once per frame
    void Update()
    {
        this.timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > ttl)
        {
            Destroy(gameObject);
        }
    }
}
