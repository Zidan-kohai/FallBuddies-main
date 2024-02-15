using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SocialPlatforms;


public class MainMenuUI : MonoBehaviour
{
    public GameObject CameraTargetStart;
    public GameObject CameraTargetTimeShop;
    public GameObject CmVcam;
    public GameObject PlayerUILevelExp;
    public GameObject ButtonMenu;
    public GameObject ButtonMenuFromShop;
    public GameObject ButtonShop;
    public GameObject ButtonStart;
    public GameObject telegramButton;
    public GameObject ButtonBuy;
    public GameObject PanelShop;
    public GameObject[] Scrolls;
    public GameObject panelSetting;

    public List<GameObject> LevelstartButtons;

    public GameObject ImageTextFirstGame;
    public GameObject ImageTextFirstGameShop;

    public PlayerDataUIValue PlayerDataUIValue;
    public bool FirstTime;
    public bool FirstTimeShop;

    [Header("Inn App Shop")]
    public GameObject PanelInnShop;
    public GameObject ButtonInnShop;
    [SerializeField] private TextMeshProUGUI moneyValueText;
    [SerializeField] private TextMeshProUGUI hardMoneyValueText;

    public List<ShopCharacter> ShopChars;
    [SerializeField] private GameObject Levels;
    [SerializeField] private GameObject leaderBoard;

    public bool isFirstOpenedShop = false;
    public void Start()
    {
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        PlayerUILevelExp = GameObject.FindGameObjectWithTag("PlayerUILevelPanel");
        FirstTime = Geekplay.Instance.PlayerData.PlayerFirstTimePlay;
        FirstTimeShop = Geekplay.Instance.PlayerData.PlayerFirstTimeNeedShop;

        if ((FirstTime == true) && (FirstTimeShop == false))
        {
            ImageTextFirstGame.SetActive(true);
            Levels.gameObject.SetActive(false);
            leaderBoard.SetActive(false);

            Analytics.instance.SendEvent("Tutor_Start");
        }
        else
        {
            ImageTextFirstGame.gameObject.SetActive(false);
        }

        if ((FirstTime == true) && (FirstTimeShop == true))
        {
            ImageTextFirstGameShop.gameObject.SetActive(true);
            Levels.gameObject.SetActive(false);
            leaderBoard.SetActive(false);

            Analytics.instance.SendEvent("Tutor_4");
        }
        else
        {
            ImageTextFirstGameShop.gameObject.SetActive(false);
        }

        ButtonMenuFromShop.SetActive(false);
        PanelShop.SetActive(false);
        ButtonBuy.SetActive(false);
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }

        PlayerDataUIValue.TextValueMoney = moneyValueText;
        PlayerDataUIValue.TextValueHardMoney = hardMoneyValueText;
    }

    public void StartShopping()
    {
        if (isFirstOpenedShop && Geekplay.Instance.PlayerData.GameCounter == 1)
        {
            Analytics.instance.SendEvent("Tutor_end");
            isFirstOpenedShop = false;
        }


        if ((FirstTime == true) && (FirstTimeShop == true))
        {
            if(PanelShop.gameObject.active == false)
            {
                if (ImageTextFirstGameShop.gameObject.active == true)
                {
                    ImageTextFirstGameShop.gameObject.SetActive(false);
                }

                Geekplay.Instance.PlayerData.PlayerFirstTimePlay = false;
                Geekplay.Instance.PlayerData.PlayerFirstTimeNeedShop = false;
                FirstTime = Geekplay.Instance.PlayerData.PlayerFirstTimePlay;
                FirstTimeShop = Geekplay.Instance.PlayerData.PlayerFirstTimeNeedShop;

                var cam = CmVcam.GetComponent<CinemachineVirtualCamera>();
                cam.Follow = CameraTargetTimeShop.transform;
                cam.LookAt = CameraTargetTimeShop.transform;
                ButtonStart.SetActive(false);
                PlayerUILevelExp.SetActive(false);
                ButtonMenuFromShop.SetActive(true);
                PanelShop.SetActive(true);
                PanelInnShop.SetActive(false);
                leaderBoard.SetActive(false);
                Levels.gameObject.SetActive(false);
                telegramButton.SetActive(false);

                Scrolls[0].SetActive(true);
                isFirstOpenedShop = true;
                foreach (var item in LevelstartButtons)
                {
                    item.SetActive(false);
                }
            }
            else
            {
                ExitToMainMenu();
            }
        }
        else if ((FirstTime == true) && (FirstTimeShop == false))
        {
            return;
        }
        else
        {
            if (PanelShop.gameObject.active == false)
            {
                var cam = CmVcam.GetComponent<CinemachineVirtualCamera>();
                cam.Follow = CameraTargetTimeShop.transform;
                cam.LookAt = CameraTargetTimeShop.transform;
                ButtonStart.SetActive(false);
                ButtonMenuFromShop.SetActive(true);
                PlayerUILevelExp.SetActive(false);
                PanelShop.SetActive(true);
                PanelInnShop.SetActive(false);
                leaderBoard.SetActive(false);
                Levels.SetActive(false);
                Scrolls[0].SetActive(true);
                telegramButton.SetActive(false);

                foreach (var item in LevelstartButtons)
                {
                    item.SetActive(false);
                }
            }
            else
            {
                ExitToMainMenu();
            }
        }
    }

    public void ExitToMainMenu()
    {
        if (isFirstOpenedShop)
        {
            Analytics.instance.SendEvent("Tutor_end");
            isFirstOpenedShop = false;
        }

        var cam = CmVcam.GetComponent<CinemachineVirtualCamera>();
        cam.Follow = CameraTargetStart.transform;
        cam.LookAt = CameraTargetStart.transform;
        ButtonStart.SetActive(true);
        PlayerUILevelExp.SetActive(true);
        ButtonBuy.SetActive(false);
        ButtonMenuFromShop.SetActive(false);
        Levels.gameObject.SetActive(true);
        telegramButton.SetActive(true);
        if (PanelShop.gameObject.active == true) 
        {
            PanelShop.SetActive(false);

            if (Geekplay.Instance.PlayerData.PlayerFirstTimePlay == false)
            {
                Geekplay.Instance.ShowInterstitialAd();
            }
        }
        PanelInnShop.SetActive(false);
        panelSetting.SetActive(false);
        leaderBoard.SetActive(true);

        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        foreach (var item in LevelstartButtons)
        {
            item.SetActive(true);
        }
    }

    public void OpenTelegram()
    {
        Application.OpenURL("https://t.me/+uQFcFVwGmwM3ZDNi");
    }
    public void GoToInnShop()
    {

        if(FirstTime == false)
        {
            if(PanelInnShop.gameObject.active == false)
            {
                ButtonStart.SetActive(false);
                PlayerUILevelExp.SetActive(false);
                PanelShop.SetActive(false);
                PanelInnShop.SetActive(true); 
                ButtonMenuFromShop.SetActive(true);
                leaderBoard.SetActive(false);
                Levels.SetActive(false); 
                telegramButton.SetActive(false);

                foreach (var item in LevelstartButtons)
                {
                    item.SetActive(false);
                }
            }
            else
            {
                ExitToMainMenu();
            }
            
        }
    }

    public void ShopBody()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[0].SetActive(true);
        ButtonBuy.SetActive(false);
    }

    public void ShopBodyParts()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[1].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopEyes()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[2].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopGloves()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[3].SetActive(true);
        ButtonBuy.SetActive(false);
    }

    public void ShopHeadparts()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[4].SetActive(true);
        ButtonBuy.SetActive(false);
    }

    public void ShopMounth()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[5].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopNoise()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[6].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopEars()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[7].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopHair()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[8].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopHat()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[9].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopHorn()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[10].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopTails()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[11].SetActive(true);
        ButtonBuy.SetActive(false);
    }

    public void GoToSetting()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        if (FirstTime == false)
        {
            if (panelSetting.gameObject.active == false)
            {
                ButtonStart.SetActive(false);
                PlayerUILevelExp.SetActive(false);
                ButtonMenuFromShop.SetActive(true);
                PanelShop.SetActive(false);
                PanelInnShop.SetActive(false);
                panelSetting.SetActive(true);
            }
            else
            {
                ExitToMainMenu();
            }
        }
    }
}
