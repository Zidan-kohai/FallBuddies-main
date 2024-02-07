using DG.Tweening;
using JetBrains.Annotations;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDataUIValue : MonoBehaviour
{
    public TMP_Text TextValueLevel;
    public TMP_Text TextValueExp;
    public TMP_Text TextValueMoney;
    public TMP_Text TextValueHardMoney;
    public TMP_Text TextExpPanelReward;
    public TMP_Text TextMoneyPanelReward;
    public TMP_Text TextLevelUp;
    public TMP_Text TextReward;

    public Slider Slider;

    public RectTransform PanelMain;
    public RectTransform PanelShowReward;
    public RectTransform PanelShowSummary;
    public RectTransform PanelLevelUp;
    public RectTransform PanelLevelUpBackground;
    public RectTransform ButtonStart;
    public RectTransform ButtonMainMenu;

    public RectTransform[] RewardsPanelInPanelShowReward;
    public Image[] RewardsImageInPanelShowReward;
    public Sprite[] RewardsSprite;

    public bool isLevelUp = false;
    public bool isCanPressButton;

    private int j = 0;
    private int l = 0;

    public int SliderMaxValue = 100;
    public int PlaceInLevel = 999;

    [SerializeField] private int MoneyReward = 0;
    [SerializeField] private int HardMoneyReward = 0;
    [SerializeField] private int ExpReward = 0;


    public int speedUIreward;

    private void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            TextLevelUp.text = "Новый уровень!";
            TextReward.text = "твоя награда";
        }
        else
        {
            TextLevelUp.text = "Level up!";
            TextReward.text = "Your Reward";
        }


        Geekplay.Instance.SubscribeOnReward("DoubleAward", OnDoubleAwardClick);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            speedUIreward = 1;

            Cursor.lockState = CursorLockMode.None;

            PanelMain.gameObject.SetActive(true);
            PanelShowReward.gameObject.SetActive(true);
            PanelShowSummary.gameObject.SetActive(true);
            ButtonStart.gameObject.SetActive(false);
            ButtonMainMenu.gameObject.SetActive(false);

            if (isLevelUp == true)
            {
                if (PanelLevelUp.gameObject.activeSelf == true)
                {
                    if (Input.GetKeyUp("escape"))
                    {
                        PanelLevelUp.gameObject.SetActive(false);
                        PanelLevelUpBackground.gameObject.SetActive(false);
                    }
                }
                else if (PanelLevelUp.gameObject.activeSelf == false)
                {
                    if (Input.GetKeyUp("escape"))
                    {
                        PanelLevelUp.gameObject.SetActive(true);
                        PanelLevelUpBackground.gameObject.SetActive(true);
                    }
                }
            }
            else if (isLevelUp == false)
            {
                if (PanelLevelUp.gameObject.activeSelf == true)
                {
                    if (Input.GetKeyUp("escape"))
                    {
                        PanelLevelUp.gameObject.SetActive(false);
                        PanelLevelUpBackground.gameObject.SetActive(false);
                    }
                }
            }

        }

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            speedUIreward = 0;

            Cursor.lockState = CursorLockMode.None;
            PanelMain.gameObject.SetActive(true);
            PanelShowReward.gameObject.SetActive(false);
            PanelShowSummary.gameObject.SetActive(false);
            ButtonStart.gameObject.SetActive(false);
            ButtonMainMenu.gameObject.SetActive(false);

            TextValueLevel.text = "" + Geekplay.Instance.PlayerData.PlayerLevel;
            TextValueExp.text = "" + Geekplay.Instance.PlayerData.PlayerExperience + "/ 100";
            TextValueMoney.text = "" + Geekplay.Instance.PlayerData.PlayerMoney;
            TextValueHardMoney.text = "" + Geekplay.Instance.PlayerData.PlayerHardMoney;

            Slider.maxValue = SliderMaxValue;
        Slider.value = Geekplay.Instance.PlayerData.PlayerExperience;
        }

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            speedUIreward = 0;
            //Cursor.lockState = CursorLockMode.Locked;
            PanelMain.gameObject.SetActive(false);
            PanelShowReward.gameObject.SetActive(false);
            PanelShowSummary.gameObject.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            speedUIreward = 0;
            //Cursor.lockState = CursorLockMode.Locked;
            PanelMain.gameObject.SetActive(false);
            PanelShowReward.gameObject.SetActive(false);
            PanelShowSummary.gameObject.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            speedUIreward = 0;
            //Cursor.lockState = CursorLockMode.Locked;
            PanelMain.gameObject.SetActive(false);
            PanelShowReward.gameObject.SetActive(false);
            PanelShowSummary.gameObject.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "Level4")
        {
            speedUIreward = 0;
            //Cursor.lockState = CursorLockMode.Locked;
            PanelMain.gameObject.SetActive(false);
            PanelShowReward.gameObject.SetActive(false);
            PanelShowSummary.gameObject.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "Level5")
        {
            speedUIreward = 0;
            //Cursor.lockState = CursorLockMode.Locked;
            PanelMain.gameObject.SetActive(false);
            PanelShowReward.gameObject.SetActive(false);
            PanelShowSummary.gameObject.SetActive(false);
        }
    }

    private void OnDoubleAwardClick()
    {
        StartCoroutine(DoubleAward());
    }
    IEnumerator ResultCount()
    {
        yield return null;
    }

    public IEnumerator InvokeStartThisObject()
    {
        PanelMain.gameObject.SetActive(true);

        TextExpPanelReward.text = "0";
        TextMoneyPanelReward.text = "0";

        for (int i = 0; i < RewardsPanelInPanelShowReward.Length - 3; i++)
        {
            Color ColorImage = RewardsImageInPanelShowReward[i].color;
            ColorImage.a = 0f;
            RewardsImageInPanelShowReward[i].color = ColorImage;
            RewardsImageInPanelShowReward[i+3].color = ColorImage;
            RewardsPanelInPanelShowReward[i].DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.01f * speedUIreward);
            RewardsPanelInPanelShowReward[i+3].DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.01f * speedUIreward);
        }

        TextLevelUp.color = new Color(1f, 1f, 1f, 0f);

        TextValueLevel.text = "" + Geekplay.Instance.PlayerData.PlayerLevel;
        TextValueExp.text = "" + Geekplay.Instance.PlayerData.PlayerExperience + "/ 100";
        TextValueMoney.text = "" + Geekplay.Instance.PlayerData.PlayerMoney;
        TextValueHardMoney.text = "" + Geekplay.Instance.PlayerData.PlayerHardMoney;

        Slider.maxValue = SliderMaxValue;
        Slider.value = Geekplay.Instance.PlayerData.PlayerExperience;

        yield return StartCoroutine(GetReward());
    }

    IEnumerator GetReward()
    {
        Geekplay.Instance.PlayerData.GameFinished++;
        if(Geekplay.Instance.PlayerData.GameFinished >= 2)
            Geekplay.Instance.RateGameFunc();

        if (PlaceInLevel > 5 && PlaceInLevel < 11)
        {
            MoneyReward = 10;
            HardMoneyReward = 1;
            ExpReward = 5;
        }
        else if (PlaceInLevel == 5)
        {
            MoneyReward = 25;
            HardMoneyReward = 2;
            ExpReward = 10;
        }
        else if (PlaceInLevel == 4)
        {
            MoneyReward = 50;
            HardMoneyReward = 5;
            ExpReward = 20;
        }
        else if (PlaceInLevel == 3)
        {
            MoneyReward = 100;
            HardMoneyReward = 10;
            ExpReward = 30;
        }
        else if (PlaceInLevel == 2)
        {
            MoneyReward = 150;
            HardMoneyReward = 15;
            ExpReward = 40;
        }
        else if (PlaceInLevel == 1)
        {
            MoneyReward = 200;
            HardMoneyReward = 20;
            ExpReward = 50;
        }
        else
        {
            MoneyReward = 0;
            HardMoneyReward = 0;
            ExpReward = 0;
        }
        //TextExpPanelReward.text = "0";
        //TextMoneyPanelReward.text = "0";


        j = 0;
        l = 0;

        for (int i = 0; i < RewardsPanelInPanelShowReward.Length - 3; i++)
        {
            RewardsImageInPanelShowReward[i].color = Color.white; //Random.ColorHSV();
            RewardsImageInPanelShowReward[i+3].color = Color.white; //Random.ColorHSV();
            RewardsImageInPanelShowReward[i + 3].sprite = RewardsSprite[UnityEngine.Random.Range(0, RewardsSprite.Length)];
            RewardsPanelInPanelShowReward[i].DOScale(new Vector3(0.7f, 0.7f, 0.7f), 1.5f * speedUIreward);
            RewardsPanelInPanelShowReward[i + 3].DOScale(new Vector3(0.52f, 0.5f, 0.5f), 1.5f * speedUIreward);

            for (int k = 0; k < 10; k++)
            {
                Color ColorImage = RewardsImageInPanelShowReward[i].color;
                Color ColorImage1 = RewardsImageInPanelShowReward[i+3].color;
                ColorImage.a = k * 0.1f;
                ColorImage1.a = k * 0.1f;
                RewardsImageInPanelShowReward[i].color = ColorImage;
                RewardsImageInPanelShowReward[i+3].color = ColorImage1;
                yield return new WaitForSeconds(0.05f * speedUIreward);
            }
            //yield return new WaitForSeconds(1.0f);
        }
        
        for (int i = 0; i < 10; i++)
        {
            j += UnityEngine.Random.Range(0, ExpReward / 100);
            l += UnityEngine.Random.Range(0, MoneyReward / 100);
            TextExpPanelReward.text = ""+j;
            TextMoneyPanelReward.text = ""+l;
            yield return new WaitForSeconds(0.10f * speedUIreward);
        }
        for (int i = 0; i < 10; i++)
        {
            j += UnityEngine.Random.Range(ExpReward / 100, ExpReward / 10);
            l += UnityEngine.Random.Range(MoneyReward / 100, MoneyReward / 10);
            TextExpPanelReward.text = "" + j;
            TextMoneyPanelReward.text = "" + l;
            yield return new WaitForSeconds(0.10f * speedUIreward);
        }

        TextExpPanelReward.text = "" + ExpReward;
        TextMoneyPanelReward.text = "" + MoneyReward;

        Geekplay.Instance.PlayerData.PlayerMoney += MoneyReward;
        Geekplay.Instance.PlayerData.PlayerHardMoney += HardMoneyReward;
        TextValueHardMoney.text = "" + Geekplay.Instance.PlayerData.PlayerHardMoney;
        TextValueMoney.text = "" + Geekplay.Instance.PlayerData.PlayerMoney;

        for (int i = 0; i < ExpReward; i++)
        {
            Slider.value = Geekplay.Instance.PlayerData.PlayerExperience;
            Slider.value++;
            TextValueExp.text = "" + Slider.value + "/ 100";
            yield return new WaitForSeconds(0.02f * speedUIreward);

            if (Slider.value == Slider.maxValue)
            {
                //if(Geekplay.Instance.PlayerData.PlayerFirstTimePlay == false)
                //{
                //    Geekplay.Instance.ShowInterstitialAd(); 
                //}

                Slider.value = 0;
                TextValueExp.text = "" + Slider.value + "/ 100";
                Color tluColor = TextLevelUp.color;
                for(int k = 0; k < 10; k++)
                {
                    tluColor.a = 0.1f * k;
                    TextLevelUp.color = tluColor;
                    yield return new WaitForSeconds(0.05f * speedUIreward);
                }
                Geekplay.Instance.PlayerData.PlayerLevel++;
                TextValueLevel.text = "" + Geekplay.Instance.PlayerData.PlayerLevel;
                PanelLevelUp.gameObject.SetActive(true);
                PanelLevelUpBackground.gameObject.SetActive(true);
                isLevelUp = true;
                PanelLevelUp.DOScale(new Vector3(1f, 1f, 1f), 0.5f * speedUIreward);
                Geekplay.Instance.PlayerData.PlayerMoney += 500;
                TextValueMoney.text = "" + Geekplay.Instance.PlayerData.PlayerMoney;
                yield return new WaitForSeconds(1.5f * speedUIreward);
                PanelLevelUp.DOScale(new Vector3(0f, 0f, 0f), 0.5f * speedUIreward);
                TextLevelUp.color = new Color(1f, 1f, 1f, 0f);
                yield return new WaitForSeconds(1f * speedUIreward);
                isLevelUp = false;
                PanelLevelUp.gameObject.SetActive(false);
                PanelLevelUpBackground.gameObject.SetActive(false); 
            }

            Geekplay.Instance.PlayerData.PlayerExperience = (int)Slider.value;
        }

        StartCoroutine(ShowADV());

        PlaceInLevel = 999;
        Geekplay.Instance.Save();
        Geekplay.Instance.Leaderboard("Points", Geekplay.Instance.PlayerData.PlayerLevel);
        yield break;
    }

    IEnumerator DoubleAward()
    {
        int doubleMoney = MoneyReward * 2;
        int doubleExp =  ExpReward * 2;
        HardMoneyReward *= 2;

        j = doubleExp;
        l = doubleMoney;

        //for (int i = 0; i < RewardsPanelInPanelShowReward.Length - 3; i++)
        //{
        //    RewardsImageInPanelShowReward[i].color = Color.white; //Random.ColorHSV();
        //    RewardsImageInPanelShowReward[i + 3].color = Color.white; //Random.ColorHSV();
        //    RewardsImageInPanelShowReward[i + 3].sprite = RewardsSprite[UnityEngine.Random.Range(0, RewardsSprite.Length)];
        //    RewardsPanelInPanelShowReward[i].DOScale(new Vector3(0.7f, 0.7f, 0.7f), 1.5f * speedUIreward);
        //    RewardsPanelInPanelShowReward[i + 3].DOScale(new Vector3(0.52f, 0.5f, 0.5f), 1.5f * speedUIreward);

        //    for (int k = 0; k < 10; k++)
        //    {
        //        Color ColorImage = RewardsImageInPanelShowReward[i].color;
        //        Color ColorImage1 = RewardsImageInPanelShowReward[i + 3].color;
        //        ColorImage.a = k * 0.1f;
        //        ColorImage1.a = k * 0.1f;
        //        RewardsImageInPanelShowReward[i].color = ColorImage;
        //        RewardsImageInPanelShowReward[i + 3].color = ColorImage1;
        //        yield return new WaitForSeconds(0.05f * speedUIreward);
        //    }
        //    //yield return new WaitForSeconds(1.0f);
        //}
        //while (currentMoney <= doubleMoney)
        //{
        //    currentMoney++;
        //    TextMoneyPanelReward.text = currentMoney.ToString();
        //    yield return new WaitForSeconds(0.10f * speedUIreward);
        //}

        //while (currentMoney <= doubleExp)
        //{
        //    currentExp++;
        //    TextExpPanelReward.text = currentExp.ToString();
        //    yield return new WaitForSeconds(0.10f * speedUIreward);
        //}

        float currentMoney = Convert.ToInt32(TextMoneyPanelReward.text);
        float currentExp = Convert.ToInt32(TextExpPanelReward.text);

        currentExp = currentExp / 100f;
        currentMoney = currentMoney / 100f;
        for (int i = 0; i < 100; i++)
        {
            TextExpPanelReward.text = (float.Parse(TextExpPanelReward.text) + currentExp).ToString();
            TextMoneyPanelReward.text = (float.Parse(TextMoneyPanelReward.text) + currentMoney).ToString();
            yield return new WaitForSeconds(0.02f * speedUIreward);
        }

        TextExpPanelReward.text = doubleExp.ToString();
        TextMoneyPanelReward.text = doubleMoney.ToString();

        //for (int i = 0; i < 10; i++)
        //{
        //    j += Random.Range(ExpReward, ExpReward + ExpReward / 100);
        //    l += Random.Range(MoneyReward, MoneyReward + MoneyReward / 100);
        //    TextExpPanelReward.text = "" + j;
        //    TextMoneyPanelReward.text = "" + l;
        //    yield return new WaitForSeconds(0.10f * speedUIreward);
        //}
        //for (int i = 0; i < 10; i++)
        //{
        //    j += Random.Range(ExpReward + ExpReward / 100, ExpReward + ExpReward / 10);
        //    l += Random.Range(MoneyReward + MoneyReward / 100, MoneyReward + MoneyReward / 10);
        //    TextExpPanelReward.text = "" + j;
        //    TextMoneyPanelReward.text = "" + l;
        //    yield return new WaitForSeconds(0.10f * speedUIreward);
        //}

        TextExpPanelReward.text = "" + doubleExp;
        TextMoneyPanelReward.text = "" + doubleMoney;

        Geekplay.Instance.PlayerData.PlayerMoney += MoneyReward;
        Geekplay.Instance.PlayerData.PlayerHardMoney += HardMoneyReward;
        TextValueHardMoney.text = "" + Geekplay.Instance.PlayerData.PlayerHardMoney;
        TextValueMoney.text = "" + Geekplay.Instance.PlayerData.PlayerMoney;

        for (int i = 0; i < ExpReward; i++)
        {
            Slider.value = Geekplay.Instance.PlayerData.PlayerExperience;
            Slider.value++;
            TextValueExp.text = "" + Slider.value + "/ 100";
            yield return new WaitForSeconds(0.02f * speedUIreward);

            if (Slider.value == Slider.maxValue)
            {
                Slider.value = 0;
                TextValueExp.text = "" + Slider.value + "/ 100";
                Color tluColor = TextLevelUp.color;
                for (int k = 0; k < 10; k++)
                {
                    tluColor.a = 0.1f * k;
                    TextLevelUp.color = tluColor;
                    yield return new WaitForSeconds(0.05f * speedUIreward);
                }
                Geekplay.Instance.PlayerData.PlayerLevel++;
                TextValueLevel.text = "" + Geekplay.Instance.PlayerData.PlayerLevel;
                PanelLevelUp.gameObject.SetActive(true);
                PanelLevelUpBackground.gameObject.SetActive(true);
                isLevelUp = true;
                PanelLevelUp.DOScale(new Vector3(1f, 1f, 1f), 0.5f * speedUIreward);
                Geekplay.Instance.PlayerData.PlayerMoney += 500;
                TextValueMoney.text = "" + Geekplay.Instance.PlayerData.PlayerMoney;
                yield return new WaitForSeconds(1.5f * speedUIreward);
                PanelLevelUp.DOScale(new Vector3(0f, 0f, 0f), 0.5f * speedUIreward);
                TextLevelUp.color = new Color(1f, 1f, 1f, 0f);
                yield return new WaitForSeconds(1f * speedUIreward);
                isLevelUp = false;
                PanelLevelUp.gameObject.SetActive(false);
                PanelLevelUpBackground.gameObject.SetActive(false);
            }

            Geekplay.Instance.PlayerData.PlayerExperience = (int)Slider.value;
        }

        StartCoroutine(ShowADV());

        PlaceInLevel = 999;
        Geekplay.Instance.Save();
        Geekplay.Instance.Leaderboard("Points", Geekplay.Instance.PlayerData.PlayerLevel);
        yield break;
    }

    IEnumerator ShowADV()
    {
        yield return new WaitForSeconds(0.5f);
        Geekplay.Instance.ShowInterstitialAd();
    }
}
