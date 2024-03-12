using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
using System;

public class PlayerUIControl : MonoBehaviour
{
    public Transform panel;
    public Transform MainImagesMover;

    public Image[] imagesList;
    public Image[] imagesList1;

    public Image imageCenterInPanel;
    public Image imageCenterImageInPanel;

    public float border_X;
    public float border_X1;
    public float _cycleLength = 0.1f;
    public float speedMove = 100f;
    public float waitTimer = 2f;

    public bool isActivacted;
    public bool isPressed = false;
    public bool isStop = false;
    public bool isCanPress;

    public PlayerData playerData;
    public PlayerDataUIValue PlayerDataUIValue;

    public GameObject ImageTextFirstGame;
    public bool FirstTime;
    public bool FirstTimeNeedShop;

    [Header("Manual level loading")]
    [SerializeField] private bool isNeedTheLevelLoad;
    [SerializeField] private string TheLevelLoad;

    [SerializeField] private Button newGameButton;
    [SerializeField] private Button mainMenuButton;

    [SerializeField] private Button doubleAward;

    [SerializeField] private Button firstLevelStart;
    [SerializeField] private Button secondLevelStart;
    [SerializeField] private Button thirdLevelStart;
    [SerializeField] private Button fourLevelStart;


    private static int LastLevelIndex;
    public void Start()
    {
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        //FirstTime = Geekplay.Instance.PlayerData.PlayerFirstTimePlay;
        //FirstTimeNeedShop = Geekplay.Instance.PlayerData.PlayerFirstTimeNeedShop;

        //if (FirstTime == true)
        //{
        //    ImageTextFirstGame.gameObject.SetActive(true);
        //}
        //else
        //{
            ImageTextFirstGame.gameObject.SetActive(false);
            if (newGameButton != null && mainMenuButton != null &&
                firstLevelStart != null && secondLevelStart != null 
                && thirdLevelStart != null && fourLevelStart != null)
            {
                mainMenuButton.gameObject.SetActive(false);
                newGameButton.gameObject.SetActive(false);
                firstLevelStart.gameObject.SetActive(false);
                secondLevelStart.gameObject.SetActive(false);
                thirdLevelStart.gameObject.SetActive(false);
                fourLevelStart.gameObject.SetActive(false);



                //Image mainMenuButtonImage = mainMenuButton.GetComponent<Image>();
                //Image newGameButtonImage = newGameButton.GetComponent<Image>();  
                //Image firstLevelStartImage = firstLevelStart.GetComponent<Image>();  
                //Image secondLevelStartImage = secondLevelStart.GetComponent<Image>();  
                //Image thirdLevelStartImage = thirdLevelStart.GetComponent<Image>();  
                //Image fourLevelStartImage = fourLevelStart.GetComponent<Image>();  

                //DOTween.Sequence().SetDelay(03f).OnComplete(() =>
                //{
                //    mainMenuButtonImage.DOFade(0, 0f).OnComplete(() =>
                //    {
                //        mainMenuButtonImage.DOFade(1, 1f);
                //    });

                //    newGameButtonImage.DOFade(0, 0f).OnComplete(() =>
                //    {
                //        newGameButtonImage.DOFade(1, 1f);
                //    });
                //    firstLevelStartImage.DOFade(0, 0f).OnComplete(() =>
                //    {
                //        firstLevelStartImage.DOFade(1, 1f);
                //    });
                //    secondLevelStartImage.DOFade(0, 0f).OnComplete(() =>
                //    {
                //        secondLevelStartImage.DOFade(1, 1f);
                //    });
                //    thirdLevelStartImage.DOFade(0, 0f).OnComplete(() =>
                //    {
                //        thirdLevelStartImage.DOFade(1, 1f);
                //    });
                //    fourLevelStartImage.DOFade(0, 0f).OnComplete(() =>
                //    {
                //        fourLevelStartImage.DOFade(1, 1f);
                //    });

                //    newGameButton.gameObject.SetActive(true);
                //    mainMenuButton.gameObject.SetActive(true);
                //    firstLevelStart.gameObject.SetActive(true);
                //    secondLevelStart.gameObject.SetActive(true);
                //    thirdLevelStart.gameObject.SetActive(true);
                //    fourLevelStart.gameObject.SetActive(true);
                //});

                PlayerDataUIValue.AwardingEnd += OnAwardingEnd;
            }



        //}


        if (doubleAward != null)
        {
            doubleAward.gameObject.SetActive(false);
            //Image doubleAwardButtonImage = doubleAward.GetComponent<Image>();
            //DOTween.Sequence().SetDelay(6f).OnComplete(() =>
            //{
            //    doubleAwardButtonImage.DOFade(0, 0f).OnComplete(() =>
            //    {
            //        doubleAwardButtonImage.DOFade(1, 1f);
            //    });
            //    doubleAward.gameObject.SetActive(true);
            //});

            doubleAward.onClick.AddListener(OnDoubleAwardClick);
        }

        isPressed = false;
        isStop = false;
    }

    private void OnAwardingEnd(bool isFistAwarding)
    {
        if (doubleAward == null || mainMenuButton == null || newGameButton == null || firstLevelStart == null || secondLevelStart == null || thirdLevelStart == null || fourLevelStart == null) return;

        if (isFistAwarding)
        {
            Image doubleAwardButtonImage = doubleAward.GetComponent<Image>();
            DOTween.Sequence().SetDelay(0.2f).OnComplete(() =>
            {
                doubleAwardButtonImage.color = new Color(1, 1, 1, 0);
                doubleAwardButtonImage.DOFade(1, 1f);
                doubleAward.gameObject.SetActive(true);
            });

            Image mainMenuButtonImage = mainMenuButton.GetComponent<Image>();
            //Image newGameButtonImage = newGameButton.GetComponent<Image>();
            //Image firstLevelStartImage = firstLevelStart.GetComponent<Image>();
            //Image secondLevelStartImage = secondLevelStart.GetComponent<Image>();
            //Image thirdLevelStartImage = thirdLevelStart.GetComponent<Image>();
            //Image fourLevelStartImage = fourLevelStart.GetComponent<Image>();

            DOTween.Sequence().SetDelay(2f).OnComplete(() =>
            {
                mainMenuButtonImage.color = new Color(1, 1, 1, 0);
                mainMenuButtonImage.DOFade(1, 1f);

                //newGameButtonImage.color = new Color(1, 1, 1, 0);
                //newGameButtonImage.DOFade(1, 1f);

                //firstLevelStartImage.color = new Color(1, 1, 1, 0);
                //firstLevelStartImage.DOFade(1, 1f);

                //secondLevelStartImage.color = new Color(1, 1, 1, 0);
                //secondLevelStartImage.DOFade(1, 1f);

                //thirdLevelStartImage.color = new Color(1, 1, 1, 0);
                //thirdLevelStartImage.DOFade(1, 1f);

                //fourLevelStartImage.color = new Color(1, 1, 1, 0);
                //fourLevelStartImage.DOFade(1, 1f);

                mainMenuButton.gameObject.SetActive(true);
                //newGameButton.gameObject.SetActive(true);
                //firstLevelStart.gameObject.SetActive(true);
                //secondLevelStart.gameObject.SetActive(true);
                //thirdLevelStart.gameObject.SetActive(true);
                //fourLevelStart.gameObject.SetActive(true);
            });
        }
        else
        {
            mainMenuButton.gameObject.SetActive(true);
        }


        

    }

    private void OnDoubleAwardClick()
    {
        Debug.Log("DoubleAward");
        DOTween.KillAll();
        Geekplay.Instance.ShowRewardedAd("DoubleAward");
        doubleAward.gameObject.SetActive(false);

        mainMenuButton.gameObject.SetActive(false);
        newGameButton.gameObject.SetActive(false);
        firstLevelStart.gameObject.SetActive(false);
        secondLevelStart.gameObject.SetActive(false);
        thirdLevelStart.gameObject.SetActive(false);
        fourLevelStart.gameObject.SetActive(false);

        
    }

    public void StartGameImage()
    {
        //FirstTime = Geekplay.Instance.PlayerData.PlayerFirstTimePlay;
        //FirstTimeNeedShop = Geekplay.Instance.PlayerData.PlayerFirstTimeNeedShop;

        //if ((FirstTime == true) && (FirstTimeNeedShop == true))
        //{
        //    Geekplay.Instance.PlayerData.GameCounter++;
        //    Analytics.instance.SendEvent("Tutor_1");
        //    return;

        //}
        //else
        //{
            isPressed = true;

            panel.gameObject.SetActive(true);

            isActivacted = false;

            Geekplay.Instance.PlayerData.GameCounter++;
            Analytics.instance.SendEvent($"Game_{Geekplay.Instance.PlayerData.GameCounter}_Start");
            Analytics.instance.SendEvent("Random_Game");

            StartCoroutine(ImageMoveStart(MainImagesMover));
            StartCoroutine(ChangeImageLevel());
            StartCoroutine(WaitAwakeGame());
        //}
    }

    public void StartMainMenu()
    {
        //if(Geekplay.Instance.PlayerData.PlayerFirstTimePlay)
        //{
         //   Analytics.instance.SendEvent("Tutor_3");
        //}
        SceneManager.LoadScene("Menu");
    }

    void Update()
    {
        if(PlayerDataUIValue == null)
        {
            PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        }
        if(MainImagesMover.localPosition.x >= 2000)
        {
            StopCoroutine(ImageMoveStart(MainImagesMover));
            StopCoroutine(ImageMove(MainImagesMover));
            StartCoroutine(ImageMove(MainImagesMover));
            
        }
        else
        {
            return;
        }
    }

    IEnumerator ImageMoveStart(Transform imageTransform)
    {
        imageTransform.localPosition = new Vector3(0, imageTransform.localPosition.y, imageTransform.localPosition.z);
        imageTransform.transform.DOMoveX(imageTransform.position.x + speedMove, _cycleLength).SetLoops(-1, LoopType.Incremental).SetTarget(imageTransform.transform);
        yield return null;
    }

    IEnumerator ImageMove(Transform imageTransform)
    {
        DOTween.Kill(imageTransform.transform);
        imageTransform.localPosition = new Vector3(0, imageTransform.localPosition.y, imageTransform.localPosition.z);
        imageTransform.transform.DOMoveX(imageTransform.position.x + speedMove, _cycleLength).SetLoops(-1, LoopType.Incremental).SetTarget(imageTransform.transform);
        yield return null;
    }

    public void LoadLevelByIndex(int index)
    {
        if (index == 5) Analytics.instance.SendEvent("Color_TV");
        if (index == 3) Analytics.instance.SendEvent("Race");
        if (index == 4) Analytics.instance.SendEvent("Doors");
        if (index == 2) Analytics.instance.SendEvent("Jumper");
        SceneManager.LoadScene(index);
    }
    IEnumerator AwakeGame()
    {
        string Level;
        int imageLevel = 0;
        int ii = UnityEngine.Random.Range(0, 4);

        while (LastLevelIndex == ii)
        {
            ii = UnityEngine.Random.Range(0, 3);
        }

        if (ii == 0)
        {
            Level = "Level1";
            imageLevel = 0;
            LastLevelIndex = 0;
        }
        else if(ii == 1)
        {
            Level = "Level2";
            imageLevel = 1;
            LastLevelIndex = 1;
        }
        else if (ii == 2)
        {
            Level = "Level3";
            imageLevel = 2;
            LastLevelIndex = 2;
        }
        //else if (ii > 30 && ii <= 60)
        //{
        //    Level = "Level4";
        //    imageLevel = 3;
        //}
        else
        {
            Level = "Level5";
            imageLevel = 3;
            LastLevelIndex = 3;
        }

        isStop = true;
        StopCoroutine(ChangeImageLevel());
        isPressed = false;

        StopCoroutine(ImageMove(MainImagesMover));

        DOTween.Kill(MainImagesMover.transform);
        
        //if(FirstTime == true)
        //{
        //    Sprite sprite = imagesList1[1].GetComponent<Image>().sprite;
        //    imageCenterImageInPanel.GetComponent<Image>().sprite = sprite;
        //}
        //else
        //{
            Sprite sprite = imagesList1[imageLevel].GetComponent<Image>().sprite;
            imageCenterImageInPanel.GetComponent<Image>().sprite = sprite;
        //}
        yield return new WaitForSeconds(1.5f);

        panel.gameObject.SetActive(false);

        //FirstTime = Geekplay.Instance.PlayerData.PlayerFirstTimePlay;

        if (isNeedTheLevelLoad == false)
        {
            //if (FirstTime == true)
            //{
            //    SceneManager.LoadScene("Level2");
            //}
            //else
            //{
                SceneManager.LoadScene(Level);
            //}
        }
        else
        {
            SceneManager.LoadScene(TheLevelLoad);
        }

        yield return null;
    }

    IEnumerator WaitAwakeGame()
    {
        yield return new WaitForSeconds(waitTimer);
        StartCoroutine(AwakeGame());
        yield return null;
    }

    IEnumerator ChangeImageLevel()
    {
        if(isStop == false)
        {
            Sprite sprite = imagesList1[UnityEngine.Random.Range(0, imagesList1.Length)].GetComponent<Image>().sprite;
            imageCenterImageInPanel.GetComponent<Image>().sprite = sprite;
            yield return new WaitForSeconds(0.2f);
            StartCoroutine(ChangeImageLevel());
        }
        else
        {
            yield break;
        }
    }
}
