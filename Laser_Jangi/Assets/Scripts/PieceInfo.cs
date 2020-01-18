using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceInfo : MonoBehaviour {
    public int position;
    public int rotation;
    public int pieceClass;
    public bool killed;
    public BoardBehavior board;

    void Start() {
        this.position = -1;
        this.rotation = -1;
        this.pieceClass = -1;
        this.killed = false;
        this.board = GameObject.Find("Board").GetComponent<BoardBehavior>();
    }
}