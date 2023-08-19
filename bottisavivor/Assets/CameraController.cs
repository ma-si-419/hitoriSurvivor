using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPos = this.player.transform.position;
        if(PlayerPos.x < -40)
        {
            PlayerPos.x = -40;
        }
        if(PlayerPos.x > 40)
        {
            PlayerPos.x = 40;
        }
        if(PlayerPos.y < -50)
        {
            PlayerPos.y = -50;
        }
        if(PlayerPos.y > 50)
        { 
            PlayerPos.y = 50; 
        }

        transform.position = new Vector3(PlayerPos.x,PlayerPos.y,transform.position.z);
       
         
    }
}
