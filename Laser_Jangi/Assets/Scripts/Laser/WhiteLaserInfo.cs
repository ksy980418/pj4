using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteLaserInfo : MonoBehaviour
{
    public int rotation;
    public int position;
    public bool clicked;
    private GameObject Object;

    // Start is called before the first frame update
    void Start()
    {
        this.rotation = -1;
        this.position = -1;
        this.clicked = false;
        this.Object = GameObject.Find("White_Laser");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            BoxCollider temp = gameObject.GetComponent<BoxCollider>();
            float half_size_x = transform.localScale.x * (temp.size.x * 0.5f);
            float half_size_y = transform.localScale.y * (temp.size.y * 0.5f);
            Debug.Log(Input.mousePosition);
            if ((float)Input.mousePosition.x >= transform.position.x - half_size_x
                && (float)Input.mousePosition.x <= transform.position.x + half_size_x
                && (float)Input.mousePosition.y >= transform.position.y - half_size_y
                && (float)Input.mousePosition.y <= transform.position.y + half_size_y)
            {
                BoardBehavior board = GameObject.Find("Board").GetComponent<BoardBehavior>();
                if (board.nowClicked != 10) {
                    Debug.Log("WL Clicked");
                    
                    if (board.nowClicked != -1) {
                        GameObject piece = GameObject.Find(board.ClasstoStr(board.nowClicked));
                        board.circleInvis(board.ClasstoPos(board.nowClicked));
                        Debug.Log("WL asdf");
                    }
                    // board.circleVis(this.position);
                    board.nowClicked = 10; //Black King : 1
                    GameObject clockwise_btn = GameObject.Find("Clockwise");
                    clockwise_btn.GetComponent<SpriteRenderer>().enabled = true;
                    GameObject counterclockwise_btn = GameObject.Find("CounterClockwise");
                    counterclockwise_btn.GetComponent<SpriteRenderer>().enabled = true;
                }

                else {
                    Debug.Log("WL Unclick");
                    // board.circleInvis(this.position);
                    board.nowClicked = -1; //White King : 11
                    GameObject clockwise_btn = GameObject.Find("Clockwise");
                    clockwise_btn.GetComponent<SpriteRenderer>().enabled = false;
                    GameObject counterclockwise_btn = GameObject.Find("CounterClockwise");
                    counterclockwise_btn.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            temp = null;
        }
    }
}
