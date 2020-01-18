using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSplitterInfo : MonoBehaviour
{
    public int position;
    public int rotation;
    public bool clicked;
    private GameObject Object;
    
    // Start is called before the first frame update
    void Start()
    {
        this.position = -1;
        this.rotation = -1;
        this.clicked = false;
        this.Object = GameObject.Find("Black_Splitter");
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
                if (board.nowClicked != 9) {
                    Debug.Log("BS Clicked");
                    
                    if (board.nowClicked != -1) {
                        GameObject piece = GameObject.Find(board.ClasstoStr(board.nowClicked));
                        board.circleInvis(board.ClasstoPos(board.nowClicked));
                        Debug.Log("BS asdf");
                    }
                    board.circleVis(board.ClasstoPos(9));
                    board.nowClicked = 9; //White King : 11
                    GameObject clockwise_btn = GameObject.Find("Clockwise");
                    clockwise_btn.GetComponent<SpriteRenderer>().enabled = true;
                    GameObject counterclockwise_btn = GameObject.Find("CounterClockwise");
                    counterclockwise_btn.GetComponent<SpriteRenderer>().enabled = true;
                }

                else {
                    Debug.Log("BS Unclick");
                    board.circleInvis(board.ClasstoPos(9));
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
