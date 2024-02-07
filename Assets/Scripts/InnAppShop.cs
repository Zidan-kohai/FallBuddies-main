using UnityEngine;
using TMPro;

public class InnAppShop : MonoBehaviour
{
    public TMP_Text TextValueMoney;
    public TMP_Text TextValueHardMoney;
    public PlayerDataUIValue playerDataUIValue;


    void Start()
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


    }

    public void InnAppBuy(string tag)
    {
        Geekplay.Instance.RealBuyItem(tag);
    }

    public void BuyRareCard1() //вот это правильное назначение награды
    {
        Geekplay.Instance.PlayerData.PlayerHardMoney += 1000;
        CheckMoneyTextUI();
        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
    }

    public void BuyRareCard2()
    {
        Geekplay.Instance.PlayerData.Bodyparts[9] = 1;
        CheckMoneyTextUI();
        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
    }

    public void BuyRareCard3()
    {
        Geekplay.Instance.PlayerData.Gloves[3] = 1;
        Geekplay.Instance.PlayerData.Tails[6] = 1;
        Geekplay.Instance.PlayerData.PlayerMoney += 1000;
        CheckMoneyTextUI();
        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
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
        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
    }

    public void BuyCommonCard1()
    {
        Geekplay.Instance.PlayerData.PlayerHardMoney += 100;
        CheckMoneyTextUI();
        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
    }

    public void BuyCommonCard2()
    {
        Geekplay.Instance.PlayerData.Bodyparts[1] = 1;
        Geekplay.Instance.PlayerData.Horn[2] = 1;
        Geekplay.Instance.PlayerData.EyesFromHead[2] = 1;
        CheckMoneyTextUI();
        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
    }

    public void BuyCommonCard3()
    {
        Geekplay.Instance.PlayerData.PlayerHardMoney += 100;
        CheckMoneyTextUI();
        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
    }

    public void BuyEpicCard1()
    {
        Geekplay.Instance.PlayerData.Bodies[3] = 1;
        Geekplay.Instance.PlayerData.Bodyparts[2] = 1;
        Geekplay.Instance.PlayerData.Eyes[7] = 1;
        Geekplay.Instance.PlayerData.Gloves[3] = 1;
        Geekplay.Instance.PlayerData.Noise[0] = 1;
        Geekplay.Instance.PlayerData.Ears[2] = 1;
        Geekplay.Instance.PlayerData.PlayerMoney += 20000;
        Geekplay.Instance.PlayerData.PlayerHardMoney += 20000;
        CheckMoneyTextUI();
        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
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


        Geekplay.Instance.PlayerData.PlayerHardMoney += 30000;
        CheckMoneyTextUI();
        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
    }

    public void BuyMoney1()
    {
        Geekplay.Instance.PlayerData.PlayerMoney += 50000;
        CheckMoneyTextUI();
        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
    }

    public void BuyHardMoney1()
    {
        Geekplay.Instance.PlayerData.PlayerHardMoney += 50000;
        CheckMoneyTextUI();
        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
    }

    public void CheckMoneyTextUI() 
    {
        playerDataUIValue.TextValueHardMoney.text = "" + Geekplay.Instance.PlayerData.PlayerHardMoney;
        playerDataUIValue.TextValueMoney.text = "" + Geekplay.Instance.PlayerData.PlayerMoney;
        Debug.Log("Geekplay.Instance.RealBuyItem(string idOrTag)");
        Debug.Log("Geekplay.Instance.Save()");
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
