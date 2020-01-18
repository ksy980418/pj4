using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBehavior : MonoBehaviour
{
    public bool visible;
    public bool clicked;
    public int position;

    // Start is called before the first frame update
    void Start()
    {
        this.visible = false;
        this.clicked = false;
        this.position = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}