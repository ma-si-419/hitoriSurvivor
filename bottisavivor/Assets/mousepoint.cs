  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousepoint : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 mousePos;
    void Start()
    {
        mousePos = Input.mousePosition;   
    }
    
    // Update is called once per frame

    void Update()
    {
        mousePos = Input.mousePosition;


        this.transform.position = mousePos;



    }
}
