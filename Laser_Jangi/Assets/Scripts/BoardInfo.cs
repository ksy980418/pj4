using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardInfo : MonoBehaviour
{
    private int pieceClass;
    private int pieceRoatation;

    public int getPieceClass() {
        return this.pieceClass;
    }

    public int getPieceRotation() {
        return this.pieceRoatation;
    }

    public void setpieceClass(int Class) {
        this.pieceClass = Class;
    }

    public void setpieceRotation(int Rotation) {
        this.pieceRoatation = Rotation;
    }
}
