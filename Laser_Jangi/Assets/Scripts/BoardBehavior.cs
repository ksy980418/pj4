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

    static BoardInfo[] current;
    public int nowClicked;

    // Start is called before the first frame update
    void Start()
    {
        nowClicked = -1;
        current = new BoardInfo[64];
        System.Random r = new System.Random();
        for (int i=0; i<64; i++) {
            current[i] = new BoardInfo();
        }

        // int side = r.Next(0, 2);
        int side = (int)BlackorWhite.Black;
        //Black Side
        if (side == (int)BlackorWhite.Black) {
            current[(int)Position.AA].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Laser);
            current[(int)Position.AA].setPieceRotation(180);
            GameObject WL = GameObject.Find("White_Laser");
            WL.GetComponent<WhiteLaserInfo>().position = (int)Position.AA;
            WL.GetComponent<WhiteLaserInfo>().rotation = 180;

            current[(int)Position.AB].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo1);
            current[(int)Position.AB].setPieceRotation(90);
            GameObject BS1 = GameObject.Find("Black_Semo1");
            BS1.GetComponent<BlackSemoInfo1>().position = (int)Position.AB;
            BS1.GetComponent<BlackSemoInfo1>().rotation = 90;

            current[(int)Position.AC].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Nemo2);
            current[(int)Position.AC].setPieceRotation(180);
            GameObject WN2 = GameObject.Find("White_Nemo2");
            WN2.GetComponent<WhiteNemoInfo2>().position = (int)Position.AC;
            WN2.GetComponent<WhiteNemoInfo2>().rotation = 180;

            current[(int)Position.AD].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.King);
            current[(int)Position.AD].setPieceRotation(180);
            GameObject WK = GameObject.Find("White_King");
            WK.GetComponent<WhiteKingInfo>().position = (int)Position.AD;
            WK.GetComponent<WhiteKingInfo>().rotation = 180;

            current[(int)Position.AE].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Nemo1);
            current[(int)Position.AE].setPieceRotation(180);
            GameObject WN1 = GameObject.Find("White_Nemo1");
            WN1.GetComponent<WhiteNemoInfo1>().position = (int)Position.AE;
            WN1.GetComponent<WhiteNemoInfo1>().rotation = 180;

            current[(int)Position.AF].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo2);
            current[(int)Position.AF].setPieceRotation(180);
            GameObject WS2 = GameObject.Find("White_Semo2");
            WS2.GetComponent<WhiteSemoInfo2>().position = (int)Position.AF;
            WS2.GetComponent<WhiteSemoInfo2>().rotation = 180;

            current[(int)Position.AH].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Splitter);
            current[(int)Position.AH].setPieceRotation(0);
            GameObject BS = GameObject.Find("Black_Splitter");
            BS.GetComponent<BlackSplitterInfo>().position = (int)Position.AH;
            BS.GetComponent<BlackSplitterInfo>().rotation = 0;

            current[(int)Position.DD].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo4);
            current[(int)Position.DD].setPieceRotation(90);
            GameObject WS4 = GameObject.Find("White_Semo4");
            WS4.GetComponent<WhiteSemoInfo4>().position = (int)Position.DD;
            WS4.GetComponent<WhiteSemoInfo4>().rotation = 90;

            current[(int)Position.DE].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo3);
            current[(int)Position.DE].setPieceRotation(180);
            GameObject WS3 = GameObject.Find("White_Semo3");
            WS3.GetComponent<WhiteSemoInfo3>().position = (int)Position.DE;
            WS3.GetComponent<WhiteSemoInfo3>().rotation = 180;

            current[(int)Position.DH].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo5);
            current[(int)Position.DH].setPieceRotation(90);
            GameObject BS5 = GameObject.Find("Black_Semo5");
            BS5.GetComponent<BlackSemoInfo5>().position = (int)Position.DH;
            BS5.GetComponent<BlackSemoInfo5>().rotation = 90;

            current[(int)Position.EA].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo5);
            current[(int)Position.EA].setPieceRotation(270);
            GameObject WS5 = GameObject.Find("White_Semo5");
            WS5.GetComponent<WhiteSemoInfo5>().position = (int)Position.EA;
            WS5.GetComponent<WhiteSemoInfo5>().rotation = 270;

            current[(int)Position.ED].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo3);
            current[(int)Position.ED].setPieceRotation(0);
            GameObject BS3 = GameObject.Find("Black_Semo3");
            BS3.GetComponent<BlackSemoInfo3>().position = (int)Position.ED;
            BS3.GetComponent<BlackSemoInfo3>().rotation = 0;

            current[(int)Position.EE].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo4);
            current[(int)Position.EE].setPieceRotation(270);
            GameObject BS4 = GameObject.Find("Black_Semo4");
            BS4.GetComponent<BlackSemoInfo4>().position = (int)Position.EE;
            BS4.GetComponent<BlackSemoInfo4>().rotation = 270;

            current[(int)Position.HA].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Splitter);
            current[(int)Position.HA].setPieceRotation(0);
            GameObject WS = GameObject.Find("White_Splitter");
            WS.GetComponent<WhiteSplitterInfo>().position = (int)Position.HA;
            WS.GetComponent<WhiteSplitterInfo>().rotation = 0;

            current[(int)Position.HC].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo2);
            current[(int)Position.HC].setPieceRotation(0);
            GameObject BS2 = GameObject.Find("Black_Semo2");
            BS2.GetComponent<BlackSemoInfo2>().position = (int)Position.HC;
            BS2.GetComponent<BlackSemoInfo2>().rotation = 0;

            current[(int)Position.HD].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Nemo1);
            current[(int)Position.HD].setPieceRotation(0);
            GameObject BN1 = GameObject.Find("Black_Nemo1");
            BN1.GetComponent<BlackNemoInfo1>().position = (int)Position.HD;
            BN1.GetComponent<BlackNemoInfo1>().rotation = 0;

            current[(int)Position.HE].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.King);
            current[(int)Position.HE].setPieceRotation(0);
            GameObject BK = GameObject.Find("Black_King");
            BK.GetComponent<BlackKingInfo>().position = (int)Position.HE;
            BK.GetComponent<BlackKingInfo>().rotation = 0;

            current[(int)Position.HF].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Nemo2);
            current[(int)Position.HF].setPieceRotation(0);
            GameObject BN2 = GameObject.Find("Black_Nemo2");
            BN2.GetComponent<BlackNemoInfo2>().position = (int)Position.HF;
            BN2.GetComponent<BlackNemoInfo2>().rotation = 0;

            current[(int)Position.HG].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo1);
            current[(int)Position.HG].setPieceRotation(270);
            GameObject WS1 = GameObject.Find("White_Semo1");
            WS1.GetComponent<WhiteSemoInfo1>().position = (int)Position.HG;
            WS1.GetComponent<WhiteSemoInfo1>().rotation = 270;

            current[(int)Position.HH].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Laser);
            current[(int)Position.HH].setPieceRotation(0);
            GameObject BL = GameObject.Find("Black_Laser");
            BL.GetComponent<BlackLaserInfo>().position = (int)Position.HH;
            BL.GetComponent<BlackLaserInfo>().rotation = 0;
            Debug.Log(WN2.GetComponent<WhiteNemoInfo2>().position);
        }

        //Black Side
        else if (side == (int)BlackorWhite.White) {
            current[(int)Position.AA].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Laser);
            current[(int)Position.AA].setPieceRotation(180);
            GameObject BL = GameObject.Find("Black_Laser");
            BL.GetComponent<BlackLaserInfo>().position = (int)Position.AA;
            BL.GetComponent<BlackLaserInfo>().rotation = 180;

            current[(int)Position.AB].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo1);
            current[(int)Position.AB].setPieceRotation(90);
            GameObject WS1 = GameObject.Find("White_Semo1");
            WS1.GetComponent<WhiteSemoInfo1>().position = (int)Position.AB;
            WS1.GetComponent<WhiteSemoInfo1>().rotation = 90;

            current[(int)Position.AC].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Nemo2);
            current[(int)Position.AC].setPieceRotation(180);
            GameObject BN2 = GameObject.Find("Black_Nemo2");
            BN2.GetComponent<BlackNemoInfo2>().position = (int)Position.AC;
            BN2.GetComponent<BlackNemoInfo2>().rotation = 180;

            current[(int)Position.AD].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.King);
            current[(int)Position.AD].setPieceRotation(180);
            GameObject BK = GameObject.Find("Black_King");
            BK.GetComponent<BlackKingInfo>().position = (int)Position.AD;
            BK.GetComponent<BlackKingInfo>().rotation = 180;

            current[(int)Position.AE].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Nemo1);
            current[(int)Position.AE].setPieceRotation(180);
            GameObject BN1 = GameObject.Find("Black_Nemo1");
            BN1.GetComponent<BlackNemoInfo1>().position = (int)Position.AE;
            BN1.GetComponent<BlackNemoInfo1>().rotation = 180;

            current[(int)Position.AF].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo2);
            current[(int)Position.AF].setPieceRotation(180);
            GameObject BS2 = GameObject.Find("Black_Semo2");
            BS2.GetComponent<BlackSemoInfo2>().position = (int)Position.AF;
            BS2.GetComponent<BlackSemoInfo2>().rotation = 180;

            current[(int)Position.AH].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Splitter);
            current[(int)Position.AH].setPieceRotation(0);
            GameObject WS = GameObject.Find("White_Splitter");
            WS.GetComponent<WhiteSplitterInfo>().position = (int)Position.AH;
            WS.GetComponent<WhiteSplitterInfo>().rotation = 0;

            current[(int)Position.DD].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo4);
            current[(int)Position.DD].setPieceRotation(90);
            GameObject BS4 = GameObject.Find("Black_Semo4");
            BS4.GetComponent<BlackSemoInfo4>().position = (int)Position.DD;
            BS4.GetComponent<BlackSemoInfo4>().rotation = 90;

            current[(int)Position.DE].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo3);
            current[(int)Position.DE].setPieceRotation(180);
            GameObject BS3 = GameObject.Find("Black_Semo3");
            BS3.GetComponent<BlackSemoInfo3>().position = (int)Position.DE;
            BS3.GetComponent<BlackSemoInfo3>().rotation = 180;

            current[(int)Position.DH].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo5);
            current[(int)Position.DH].setPieceRotation(90);
            GameObject WS5 = GameObject.Find("White_Semo5");
            WS5.GetComponent<WhiteSemoInfo5>().position = (int)Position.DH;
            WS5.GetComponent<WhiteSemoInfo5>().rotation = 90;

            current[(int)Position.EA].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo5);
            current[(int)Position.EA].setPieceRotation(270);
            GameObject BS5 = GameObject.Find("Black_Semo5");
            BS5.GetComponent<BlackSemoInfo5>().position = (int)Position.EA;
            BS5.GetComponent<BlackSemoInfo5>().rotation = 270;

            current[(int)Position.ED].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo3);
            current[(int)Position.ED].setPieceRotation(0);
            GameObject WS3 = GameObject.Find("White_Semo3");
            WS3.GetComponent<WhiteSemoInfo3>().position = (int)Position.ED;
            WS3.GetComponent<WhiteSemoInfo3>().rotation = 0;

            current[(int)Position.EE].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo4);
            current[(int)Position.EE].setPieceRotation(270);
            GameObject WS4 = GameObject.Find("White_Semo4");
            WS4.GetComponent<WhiteSemoInfo4>().position = (int)Position.EE;
            WS4.GetComponent<WhiteSemoInfo4>().rotation = 270;

            current[(int)Position.HA].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Splitter);
            current[(int)Position.HA].setPieceRotation(0);
            GameObject BS = GameObject.Find("Black_Splitter");
            BS.GetComponent<BlackSplitterInfo>().position = (int)Position.HA;
            BS.GetComponent<BlackSplitterInfo>().rotation = 0;

            current[(int)Position.HC].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Semo2);
            current[(int)Position.HC].setPieceRotation(0);
            GameObject WS2 = GameObject.Find("White_Semo2");
            WS2.GetComponent<WhiteSemoInfo2>().position = (int)Position.HC;
            WS2.GetComponent<WhiteSemoInfo2>().rotation = 0;

            current[(int)Position.HD].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Nemo1);
            current[(int)Position.HD].setPieceRotation(0);
            GameObject WN1 = GameObject.Find("White_Nemo1");
            WN1.GetComponent<WhiteNemoInfo1>().position = (int)Position.HD;
            WN1.GetComponent<WhiteNemoInfo1>().rotation = 0;

            current[(int)Position.HE].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.King);
            current[(int)Position.HE].setPieceRotation(0);
            GameObject WK = GameObject.Find("White_King");
            WK.GetComponent<WhiteKingInfo>().position = (int)Position.HE;
            WK.GetComponent<WhiteKingInfo>().rotation = 0;

            current[(int)Position.HF].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Nemo2);
            current[(int)Position.HF].setPieceRotation(0);
            GameObject WN2 = GameObject.Find("White_Nemo2");
            WN2.GetComponent<WhiteNemoInfo2>().position = (int)Position.HF;
            WN2.GetComponent<WhiteNemoInfo2>().rotation = 0;

            current[(int)Position.HG].setPieceClass((int)BlackorWhite.Black * 10 + (int)PieceClass.Semo1);
            current[(int)Position.HG].setPieceRotation(270);
            GameObject BS1 = GameObject.Find("Black_Semo1");
            BS1.GetComponent<BlackSemoInfo1>().position = (int)Position.HG;
            BS1.GetComponent<BlackSemoInfo1>().rotation = 270;

            current[(int)Position.HH].setPieceClass((int)BlackorWhite.White * 10 + (int)PieceClass.Laser);
            current[(int)Position.HH].setPieceRotation(0);
            GameObject WL = GameObject.Find("White_Laser");
            WL.GetComponent<WhiteLaserInfo>().position = (int)Position.HH;
            WL.GetComponent<WhiteLaserInfo>().rotation = 0;
        }
        Debug.Log(current[(int)Position.HG].getPieceClass());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void circleVis(int pos) {
        int[] visList = {-1, -1, -1, -1, -1, -1, -1, -1};
        visList[0] = pos-9;
        visList[1] = pos-8;
        visList[2] = pos-7;
        visList[3] = pos-1;
        visList[4] = pos+1;
        visList[5] = pos+7;
        visList[6] = pos+8;
        visList[7] = pos+9;
        Debug.Log(pos);
        for (int i=0; i<8; i++) {
            if (visList[i] < 0) {
                continue;
            }
            else if (visList[i] >= 64) {
                continue;
            }

            if (pos % 8 == 0 && (i==0 || i==5 || i==3)) {
                continue;
            }
            else if (pos % 8 == 7 && (i==4 || i==7 || i==2)) {
                continue;
            }

            if (current[visList[i]].getPieceClass() == -1) {
                GameObject c = GameObject.Find("Circle"+PostoStr(visList[i]));
                Debug.Log("Circle"+PostoStr(visList[i]));
                c.GetComponent<CircleBehavior>().visible = true;
                c.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    public void circleInvis(int pos) {
        int[] visList = {-1, -1, -1, -1, -1, -1, -1, -1};
        visList[0] = pos-9;
        visList[1] = pos-8;
        visList[2] = pos-7;
        visList[3] = pos-1;
        visList[4] = pos+1;
        visList[5] = pos+7;
        visList[6] = pos+8;
        visList[7] = pos+9;

        for (int i=0; i<8; i++) {
            if (visList[i] < 0) {
                continue;
            }
            else if (visList[i] >= 64) {
                continue;
            }
            
            if (pos % 8 == 0 && (i==0 || i==5 || i==3)) {
                continue;
            }
            else if (pos % 8 == 7 && (i==4 || i==7 || i==2)) {
                continue;
            }

            if (current[visList[i]].getPieceClass() == -1) {
                GameObject c = GameObject.Find("Circle"+PostoStr(visList[i]));
                Debug.Log("Circle"+PostoStr(visList[i]));
                c.GetComponent<CircleBehavior>().visible = false;
                c.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    public String PostoStr(int pos) {
        String[] posStrList = {"AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", 
                                "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", 
                                "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", 
                                "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", 
                                "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", 
                                "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", 
                                "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", 
                                "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH"};
        
        return posStrList[pos];
    }

    public String ClasstoStr(int c) {
        String[] classStrList = {"Black_Laser", "Black_King", "Black_Semo1", "Black_Semo2", "Black_Semo3",
                                "Black_Semo4", "Black_Semo5", "Black_Nemo1", "Black_Nemo2", "Black_Splitter",
                                "White_Laser", "White_King", "White_Semo1", "White_Semo2", "White_Semo3",
                                "White_Semo4", "White_Semo5", "White_Nemo1", "White_Nemo2", "White_Splitter"};
        
        return classStrList[c];
    }

    public int ClasstoPos(int c) {
        for (int i=0; i<64; i++) {
            if (current[i].getPieceClass() == c) {
                return i;
            }
        }
        return -1;
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
