using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Piece gamePiece;
    int playerId;
    int position;
    string playerName;
    bool ai;
    public bool jailed;
    int jailCards;
    int cash;
    BoardTile[] ownedProperties;
    BoardTile[] mortgagedProperties;
    public int numOfTilesMoved;
    bool bankrupt;
}
