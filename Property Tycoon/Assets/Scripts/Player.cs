using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Piece gamePiece;
    int position;
    public string playerName;
    public bool ai;
    public bool jailed;
    int jailCards;
    public int cash;
    BoardTile[] ownedProperties;
    BoardTile[] mortgagedProperties;
    public int numOfTilesMoved;
    bool bankrupt;
}
