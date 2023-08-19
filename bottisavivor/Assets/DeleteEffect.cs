using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteEffect: MonoBehaviour
{
    int time;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (time > 15)
        {
            Destroy(this.gameObject);
        }

        //timer
        time++;
    }
}
