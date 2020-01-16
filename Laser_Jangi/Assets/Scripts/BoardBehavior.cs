using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoardBehavior : MonoBehaviour
{
    enum BlackorWhite {
        Black,
        White
    }

    enum PieceClass {
        Laser,
        King,
        Semo1,
        Semo2,
        Semo3,
        Semo4,
        Semo5,
        Nemo1,
        Nemo2,
        Splitter
    }

    enum Position {
        AA, AB, AC, AD, AE, AF, AG, AH,
        BA, BB, BC, BD, BE, BF, BG, BH,
        CA, CB, CC, CD, CE, CF, CG, CH,
        DA, DB, DC, DD, DE, DF, DG, DH,
        EA, EB, EC, ED, EE, EF, EG, EH,
        FA, FB, FC, FD, FE, FF, FG, FH,
        GA, GB, GC, GD, GE, GF, GG, GH,
        HA, HB, HC, HD, HE, HF, HG, HH
    }

    BoardInfo[] current;

    // Start is called before the first frame update
    void Start()
    {
        current = new BoardInfo[64];
        System.Random r = new System.Random();
        for (int i=0; i<64; i++) {
            current[i] = new BoardInfo();
        }

        int side = r.Next(0, 2);
        //Black Side
        if (side == (int)BlackorWhite.Black) {
            current[(int)Position.AA].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Laser);
            current[(int)Position.AA].setPieceRotation(180);

            current[(int)Position.AB].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo1);
            current[(int)Position.AB].setPieceRotation(90);

            current[(int)Position.AC].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Nemo2);
            current[(int)Position.AC].setPieceRotation(180);

            current[(int)Position.AD].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.King);
            current[(int)Position.AD].setPieceRotation(180);

            current[(int)Position.AE].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Nemo1);
            current[(int)Position.AE].setPieceRotation(180);

            current[(int)Position.AF].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo2);
            current[(int)Position.AF].setPieceRotation(180);

            current[(int)Position.AH].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Splitter);
            current[(int)Position.AH].setPieceRotation(0);

            current[(int)Position.DD].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo4);
            current[(int)Position.DD].setPieceRotation(90);

            current[(int)Position.DE].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo3);
            current[(int)Position.DE].setPieceRotation(180);

            current[(int)Position.DH].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo5);
            current[(int)Position.DH].setPieceRotation(90);

            current[(int)Position.EA].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo5);
            current[(int)Position.EA].setPieceRotation(270);

            current[(int)Position.ED].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo3);
            current[(int)Position.ED].setPieceRotation(0);

            current[(int)Position.EE].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo4);
            current[(int)Position.EE].setPieceRotation(270);

            current[(int)Position.HA].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Splitter);
            current[(int)Position.HA].setPieceRotation(0);

            current[(int)Position.HC].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo2);
            current[(int)Position.HC].setPieceRotation(0);

            current[(int)Position.HD].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Nemo1);
            current[(int)Position.HD].setPieceRotation(0);

            current[(int)Position.HE].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.King);
            current[(int)Position.HE].setPieceRotation(0);

            current[(int)Position.HF].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Nemo2);
            current[(int)Position.HF].setPieceRotation(0);

            current[(int)Position.HG].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo1);
            current[(int)Position.HG].setPieceRotation(270);

            current[(int)Position.HH].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Laser);
            current[(int)Position.HH].setPieceRotation(0);
        }

        //Black Side
        else if (side == (int)BlackorWhite.Black) {
            current[(int)Position.AA].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Laser);
            current[(int)Position.AA].setPieceRotation(180);

            current[(int)Position.AB].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo1);
            current[(int)Position.AB].setPieceRotation(90);

            current[(int)Position.AC].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Nemo2);
            current[(int)Position.AC].setPieceRotation(180);

            current[(int)Position.AD].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.King);
            current[(int)Position.AD].setPieceRotation(180);

            current[(int)Position.AE].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Nemo1);
            current[(int)Position.AE].setPieceRotation(180);

            current[(int)Position.AF].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo2);
            current[(int)Position.AF].setPieceRotation(180);

            current[(int)Position.AH].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Splitter);
            current[(int)Position.AH].setPieceRotation(0);

            current[(int)Position.DD].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo4);
            current[(int)Position.DD].setPieceRotation(90);

            current[(int)Position.DE].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo3);
            current[(int)Position.DE].setPieceRotation(180);

            current[(int)Position.DH].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo5);
            current[(int)Position.DH].setPieceRotation(90);

            current[(int)Position.EA].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo5);
            current[(int)Position.EA].setPieceRotation(270);

            current[(int)Position.ED].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo3);
            current[(int)Position.ED].setPieceRotation(0);

            current[(int)Position.EE].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo4);
            current[(int)Position.EE].setPieceRotation(270);

            current[(int)Position.HA].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Splitter);
            current[(int)Position.HA].setPieceRotation(0);

            current[(int)Position.HC].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo2);
            current[(int)Position.HC].setPieceRotation(0);

            current[(int)Position.HD].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Nemo1);
            current[(int)Position.HD].setPieceRotation(0);

            current[(int)Position.HE].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.King);
            current[(int)Position.HE].setPieceRotation(0);

            current[(int)Position.HF].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Nemo2);
            current[(int)Position.HF].setPieceRotation(0);

            current[(int)Position.HG].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo1);
            current[(int)Position.HG].setPieceRotation(270);

            current[(int)Position.HH].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Laser);
            current[(int)Position.HH].setPieceRotation(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class BoardInfo {
        private int pieceClass;
        private int pieceRoatation;

        public BoardInfo() {
            this.pieceClass = -1;
            this.pieceRoatation = -1;
        }

        public BoardInfo(int Class, int Rotation) {
            this.pieceClass = Class;
            this.pieceRoatation = Rotation;
        }

        public int getPieceClass() {
            return this.pieceClass;
        }

        public int getPieceRotation() {
            return this.pieceRoatation;
        }

        public void setPieceClass(int Class) {
            this.pieceClass = Class;
        }

        public void setPieceRotation(int Rotation) {
            this.pieceRoatation = Rotation;
        }
    }
}
