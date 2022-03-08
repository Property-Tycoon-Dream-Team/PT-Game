using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Piece gamePiece;
    public string playerName;
    public bool ai;
    public bool jailed;
    int jailCards;
    public int cash;
    public List<BoardTile> ownedProperties = new List<BoardTile>();
    public List<BoardTile> mortgagedProperties = new List<BoardTile>();
    bool bankrupt = false
    ;

    
    public bool getBankrupt()
    {
        return bankrupt;
    }

    public bool addToProperties(BoardTile bt)
    {
        if (ownedProperties.Contains(bt)){
            return false; 
        }
        else{
            ownedProperties.Add(bt);
            return true; 
        }
    }

    }
