using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Piece gamePiece;
    int playerId;
    int position;
    string playerName;
    bool banker;
    bool jailed;
    Card[] cardInventory;
    int cash;
    BoardTile[] ownedProperties;
    BoardTile[] mortgagedProperties;
    int numOfTilesMoved;

    void setJailStatus()
    {

    }

    void setNumOfTilesMoved()
    {

    }
}
