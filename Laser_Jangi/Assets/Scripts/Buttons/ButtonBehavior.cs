using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public bool anyItemClicked;
    // Start is called before the first frame update
    void Start()
    {
        this.anyItemClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BKclick() {
        Debug.Log("BK Clicked");
        GameObject BK = GameObject.Find("Black_King");
        BoardBehavior board = GameObject.Find("Board").GetComponent<BoardBehavior>();
        board.circleVis(BK.GetComponent<BlackKingInfo>().position);
    }

    public void clockwiseRotation() {

    }

    public void counterclockwiseRotation() {
        
    }
}
