using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class InnAppShop : MonoBehaviour
{
    public AudioSource buyedAudio;

    public TMP_Text TextValueMoney;
    public TMP_Text TextValueHardMoney;
    public PlayerDataUIValue playerDataUIValue;

    public Button buyUncommonCard1Button;
    public Button buyCommonCard2Button;
    public Button buyEpicCard1Button;
    public Button buyLegendatyCard1Button;
    public Button buyRareCard2Button;
    public Button buyRareCard3Button;

    public GameObject buyedUncommonCard1Panel;
    public GameObject buyedCommonCard2Panel;
    public GameObject buyedEpicCard1Panel;
    public GameObject buyedLegendatyCard1Panel;
    public GameObject buyedRareCard2Panel;
    public GameObject buyedRareCard3Panel;

    void OnEnable()
    {
        playerDataUIValue = FindObjectOfType<PlayerDataUIValue>();

        Geekplay.Instance.SubscribeOnPurshace("UncommonCard1", BuyUncommonCard1);
        Geekplay.Instance.SubscribeOnPurshace("CommonCard1", BuyCommonCard1);
        Geekplay.Instance.SubscribeOnPurshace("CommonCard2", BuyCommonCard2);
        Geekplay.Instance.SubscribeOnPurshace("CommonCard3", BuyCommonCard3);
        Geekplay.Instance.SubscribeOnPurshace("EpicCard1", BuyEpicCard1);
        Geekplay.Instance.SubscribeOnPurshace("LegendaryCard1", BuyLegendatyCard1);
        Geekplay.Instance.SubscribeOnPurshace("RareCard1", BuyRareCard1);
        Geekplay.Instance.SubscribeOnPurshace("RareCard2", BuyRareCard2);
        Geekplay.Instance.SubscribeOnPurshace("RareCard3", BuyRareCard3);
        Geekplay.Instance.SubscribeOnPurshace("Money1", BuyMoney1);
        Geekplay.Instance.SubscribeOnPurshace("HardMoney1", BuyHardMoney1);

        if(Geekplay.Instance.PlayerData.buyUncommonCard1)
        {
            Buyed(buyUncommonCard1Button, buyedUncommonCard1Panel);
        }
        if (Geekplay.Instance.PlayerData.buyCommonCard2)
        {
            Buyed(buyCommonCard2Button, buyedCommonCard2Panel);
        }
        if (Geekplay.Instance.PlayerData.buyEpicCard1)
        {
            Buyed(buyEpicCard1Button, buyedEpicCard1Panel);
        }
        if (Geekplay.Instance.PlayerData.buyLegendatyCard1)
        {
            Buyed(buyLegendatyCard1Button, buyedLegendatyCard1Panel);
        }
        if (Geekplay.Instance.PlayerData.buyRareCard2)
        {
            Buyed(buyRareCard2Button, buyedRareCard2Panel);
        }
        if (Geekplay.Instance.PlayerData.buyRareCard3)
        {
            Buyed(buyRareCard3Button, buyedRareCard3Panel);
        }

    }

    private void Buyed(Button button, GameObject buyedIcon)
    {
        button.interactable = false;
        buyedIcon.SetActive(true);
    }

    public void InnAppBuy(string tag)
    {
        Geekplay.Instance.RealBuyItem(tag);
    }

    public void BuyRareCard1() //вот это правильное назначение награды
    {
        Geekplay.Instance.PlayerData.PlayerMoney += 1000;
        CheckMoneyTextUI();

        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }

    public void BuyRareCard2()
    {
        Geekplay.Instance.PlayerData.Bodyparts[9] = 1;
        CheckMoneyTextUI();

        Buyed(buyRareCard2Button, buyedRareCard2Panel);

        Geekplay.Instance.PlayerData.buyRareCard2 = true;

        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }

    public void BuyRareCard3()
    {
        Geekplay.Instance.PlayerData.Gloves[3] = 1;
        Geekplay.Instance.PlayerData.Tails[6] = 1;
        Geekplay.Instance.PlayerData.PlayerMoney += 500;
        CheckMoneyTextUI();

        Buyed(buyRareCard3Button, buyedRareCard3Panel);

        Geekplay.Instance.PlayerData.buyRareCard3 = true;

        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }

    public void BuyUncommonCard1()
    {
        Geekplay.Instance.PlayerData.Bodies[2] = 1;
        Geekplay.Instance.PlayerData.Bodyparts[1] = 1;
        Geekplay.Instance.PlayerData.Gloves[1] = 1;
        Geekplay.Instance.PlayerData.Mounth[7] = 1;
        Geekplay.Instance.PlayerData.Eyes[5] = 1;
        Geekplay.Instance.PlayerData.Ears[0] = 1;
        CheckMoneyTextUI();

        Buyed(buyUncommonCard1Button, buyedUncommonCard1Panel);

        Geekplay.Instance.PlayerData.buyUncommonCard1 = true;

        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }

    public void BuyCommonCard1()
    {
        Geekplay.Instance.PlayerData.PlayerHardMoney += 500;
        CheckMoneyTextUI();

        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }

    public void BuyCommonCard2()
    {
        Geekplay.Instance.PlayerData.Bodyparts[1] = 1;
        Geekplay.Instance.PlayerData.Horn[2] = 1;
        Geekplay.Instance.PlayerData.EyesFromHead[2] = 1;
        CheckMoneyTextUI();


        Buyed(buyCommonCard2Button, buyedCommonCard2Panel);

        Geekplay.Instance.PlayerData.buyCommonCard2 = true;

        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }

    public void BuyCommonCard3()
    {
        Geekplay.Instance.PlayerData.PlayerHardMoney += 250;
        Geekplay.Instance.PlayerData.PlayerMoney += 500;
        CheckMoneyTextUI();

        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }

    public void BuyEpicCard1()
    {
        Geekplay.Instance.PlayerData.Bodies[3] = 1;
        Geekplay.Instance.PlayerData.Bodyparts[2] = 1;
        Geekplay.Instance.PlayerData.Eyes[7] = 1;
        Geekplay.Instance.PlayerData.Gloves[3] = 1;
        Geekplay.Instance.PlayerData.Noise[0] = 1;
        Geekplay.Instance.PlayerData.Ears[2] = 1;
        CheckMoneyTextUI();


        Buyed(buyEpicCard1Button, buyedEpicCard1Panel);

        Geekplay.Instance.PlayerData.buyEpicCard1 = true;

        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }

    public void BuyLegendatyCard1()
    {
        Geekplay.Instance.PlayerData.Bodies[0] = 1;
        Geekplay.Instance.PlayerData.Bodyparts[5] = 1;
        Geekplay.Instance.PlayerData.Eyes[9] = 1;
        Geekplay.Instance.PlayerData.Gloves[5] = 1;
        Geekplay.Instance.PlayerData.Noise[1] = 1;
        Geekplay.Instance.PlayerData.Ears[3] = 1;

        Geekplay.Instance.PlayerData.Bodies[5] = 1;
        Geekplay.Instance.PlayerData.Bodyparts[4] = 1;
        Geekplay.Instance.PlayerData.Eyes[8] = 1;
        Geekplay.Instance.PlayerData.Gloves[4] = 1;
        Geekplay.Instance.PlayerData.Mounth[9] = 1;
        Geekplay.Instance.PlayerData.Combs[0] = 1;


        Geekplay.Instance.PlayerData.PlayerMoney += 1000;
        CheckMoneyTextUI();


        Buyed(buyLegendatyCard1Button, buyedLegendatyCard1Panel);

        Geekplay.Instance.PlayerData.buyLegendatyCard1 = true;

        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }

    public void BuyMoney1()
    {
        Geekplay.Instance.PlayerData.PlayerMoney += 5000;
        CheckMoneyTextUI();
        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }

    public void BuyHardMoney1()
    {
        Geekplay.Instance.PlayerData.PlayerHardMoney += 5000;
        CheckMoneyTextUI();
        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }

    public void CheckMoneyTextUI() 
    {
        playerDataUIValue.TextValueHardMoney.text = "" + Geekplay.Instance.PlayerData.PlayerHardMoney;
        playerDataUIValue.TextValueMoney.text = "" + Geekplay.Instance.PlayerData.PlayerMoney;
        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();

        buyedAudio.Play();
    }

    private void OnDisable()
    {
        Geekplay.Instance.UnsubscribeOnPurshace("UncommonCard1", BuyUncommonCard1);
        Geekplay.Instance.UnsubscribeOnPurshace("CommonCard1", BuyCommonCard1);
        Geekplay.Instance.UnsubscribeOnPurshace("CommonCard2", BuyCommonCard2);
        Geekplay.Instance.UnsubscribeOnPurshace("CommonCard3", BuyCommonCard3);
        Geekplay.Instance.UnsubscribeOnPurshace("EpicCard1", BuyEpicCard1);
        Geekplay.Instance.UnsubscribeOnPurshace("LegendaryCard1", BuyLegendatyCard1);
        Geekplay.Instance.UnsubscribeOnPurshace("RareCard1", BuyRareCard1);
        Geekplay.Instance.UnsubscribeOnPurshace("RareCard2", BuyRareCard2);
        Geekplay.Instance.UnsubscribeOnPurshace("RareCard3", BuyRareCard3);
        Geekplay.Instance.UnsubscribeOnPurshace("Money1", BuyMoney1);
        Geekplay.Instance.UnsubscribeOnPurshace("HardMoney1", BuyHardMoney1);
    }
}
