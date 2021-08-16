using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(0, 0, 0);
        position.x = player.transform.position.x;
        position.y = player.transform.position.y;
        position.z = -10;

        cam.transform.position = position;
    }
}
