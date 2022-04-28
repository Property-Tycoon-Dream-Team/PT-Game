using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameManager manager;
    public string title;
    public int amount; 
    public bool isActionComplete = false;
    public int tileIndex;
    public bool freepark; 
    public bool jailFree; 
    public bool jail; 
    public bool bday;
    public bool go;

    public void completeAction(Player p, Player b)
    {   
        if (freepark)
        {
            manager.addToFreeParking(-(amount));
            p.addCash(amount);
        }
        else 
        {
            if (amount > 0)
            {
                p.addCash(amount);
                b.addCash(-amount);
            }
            if (amount < 0)
            {
                p.addCash(-amount);
                b.addCash(+amount);
            }
            if (tileIndex != 0)
            {
                if (p.gamePiece.getCurrentTile() + tileIndex >= 40 && !(jail))
                {
                    p.addCash(200);
                }
                p.gamePiece.currentTile = tileIndex;
                p.gamePiece.moveHelper();
            }
            if (jailFree)
            {
                p.jailCards++;
            }

            if (go)
            {
                p.gamePiece.currentTile = 0;
                p.gamePiece.moveHelper();
                p.addCash(200);
            }

            if (bday)
            {
                foreach (Player a in manager.players)
                {
                    a.addCash(10);
                }
                p.addCash(-(manager.players.Length) * 10);
            }
        }
    }
}
    
