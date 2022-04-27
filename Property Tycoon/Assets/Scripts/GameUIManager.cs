using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public GameManager manager;
    public GameObject propListParent;

    public void UpdatePropertyList()
    {
        //manager;
    }

    public void PropertySelect(int childNum)
    {
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
    }

    public void OnUpgradeClicked()
    {
        manager.upgrade();
    }

    public void OnMortgageClicked()
    {
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
