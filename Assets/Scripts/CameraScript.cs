using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public GameObject player;
    public Transform deadzoneLeft;
    public Transform deadzoneRight;

    public Transform worldBorderLeft;
    public Transform worldBorderCheckLeft;

    public Transform worldBorderRight;
    public Transform worldBorderCheckRight;

    public bool leftReached = false;
    public bool rightReached = false;


    private Vector3 old = new Vector3(0, 0, 0);
    private void Start()
    {
        Vector3 position = new Vector3(0, 0, 0);
        position.x = this.player.transform.position.x;
        position.y = this.player.transform.position.y;
        position.z = -10;
        this.cam.transform.position = position;
    }
    // Update is called once per frame
    void Update()
    {

        if (this.worldBorderCheckLeft.position.x <= this.worldBorderLeft.position.x)
        {
            // Debug.Log("Border Left");
            this.leftReached = true;
        }

        if (this.worldBorderCheckRight.position.x >= this.worldBorderRight.position.x)
        {
            // Debug.Log("Border Right");
            this.rightReached = true;
        }

        if (player.transform.position.x <= deadzoneLeft.position.x || player.transform.position.x >= deadzoneRight.position.x)
        {
            if (player.transform.position.x <= deadzoneLeft.position.x)
            {
                if (this.leftReached)
                {
                    Vector3 position = this.old;
                    position.y = this.player.gameObject.transform.position.y;
                    this.cam.transform.position = position;
                    this.old = position;
                } else
                {
                    this.rightReached = false;

                    Vector3 position = new Vector3(0, 0, 0);
                    position.x = this.player.transform.position.x + 1.5f;
                    position.y = this.player.transform.position.y;
                    position.z = -10;
                    this.cam.transform.position = position;

                    this.old = position;
                }
                
            }

            if (player.transform.position.x >= deadzoneRight.position.x)
            {
                if (this.rightReached)
                {
                    Vector3 position = this.old;
                    position.y = this.player.gameObject.transform.position.y;
                    this.cam.transform.position = position;
                    this.old = position;
                }
                else
                {
                    this.leftReached = false;

                    Vector3 position = new Vector3(0, 0, 0);
                    position.x = this.player.transform.position.x - 1.5f;
                    position.y = this.player.transform.position.y;
                    position.z = -10;
                    this.cam.transform.position = position;

                    this.old = position;
                }
            }
        }
        else
        {
            
            Vector3 position = new Vector3(0, 0, 0);
            position.x = this.old.x;
            position.y = this.player.transform.position.y;
            position.z = this.old.z;

            cam.transform.position = position;
            
        }
    }
}
