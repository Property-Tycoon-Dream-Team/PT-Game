using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public GameManager manager;
    public GameObject propListParent;
    public Button[] gameButtons;

    List<BoardTile> playersTiles;

    public void UpdatePropertyList()
    {
        ToggleGameButtons(false);

        playersTiles = manager.activePlayer.ownedProperties;

        for (int i = 0; i < propListParent.transform.childCount; i++)
        {
            propListParent.transform.GetChild(i).GetComponent<Button>().interactable = true;
            if (i <= playersTiles.Count)
            {
                if (i == playersTiles.Count)
                {
                    propListParent.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = "Current Place";
                }
                else
                {
                    propListParent.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = playersTiles[i].name;
                }
                
                propListParent.transform.GetChild(i).gameObject.SetActive(true);
                continue;
            }
            propListParent.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ToggleGameButtons(bool toggleTo)
    {
        foreach (Button button in gameButtons)
        {
            button.interactable = toggleTo;
        }
    }

    public void PropertySelect(int childNum)
    {
        ToggleGameButtons(true);

        for (int i = 0; i < propListParent.transform.childCount; i++)
        {
            if (i == childNum)
            {
                propListParent.transform.GetChild(i).GetComponent<Button>().interactable = false;
            }
            else
            {
                propListParent.transform.GetChild(i).GetComponent<Button>().interactable = true;
            }
        }

        if (childNum == playersTiles.Count)
        {
            manager.selectedProperty = manager.getTileObject(manager.activePlayer.gamePiece.currentTile).GetComponent<BoardTile>();
        }
        else
        {
            manager.selectedProperty = playersTiles[childNum];
        }
    }

    public void OnUpgradeClicked()
    {
        manager.upgrade();
    }

    public void OnMortgageClicked()
    {
        Debug.Log("yo");
        manager.mortgage();
    }

    public void OnUnMortgageClicked()
    {
        manager.unMortgage();
    }

    public void OnSellClicked()
    {
        manager.sell();
    }

    public void OnRTDClicked()
    {
        manager.rollDice(true);
    }

    public void OnEndTurnClicked()
    {
        manager.endTurn();
    }

    public void OnPurchaseClicked()
    {
        manager.purchase();
    }

    public void OnAuctionClicked()
    {
        manager.auction();
    }

    public void OnUpgradeDropdownClicked()
    {
        
    }

    public void OnSellDropdownClicked()
    {

    }

    public void OnMortgageDropdownClicked()
    {

    }

    public void OnUnMortgageDropdownClicked()
    {

    }

    public void OnBackClicked()
    {
        // turn off popup things
        // turn back on main one
    }
}
