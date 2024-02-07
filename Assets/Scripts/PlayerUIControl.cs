using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

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
    public void Start()
    {
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        FirstTime = Geekplay.Instance.PlayerData.PlayerFirstTimePlay;
        FirstTimeNeedShop = Geekplay.Instance.PlayerData.PlayerFirstTimeNeedShop;

        if (FirstTime == true)
        {
            ImageTextFirstGame.gameObject.SetActive(true);
        }
        else
        {
            ImageTextFirstGame.gameObject.SetActive(false);
            if (newGameButton != null || mainMenuButton != null)
            {
                Image newGameButtonImage = newGameButton.GetComponent<Image>();
                Image mainMenuButtonImage = mainMenuButton.GetComponent<Image>();
                newGameButtonImage.color = new Color(1, 1, 1, 0f);
                mainMenuButtonImage.color = new Color(1, 1, 1, 0f);

                mainMenuButton.interactable = false;
                newGameButton.interactable = false;

                newGameButtonImage.DOFade(1, 7f).OnComplete(() =>
                {
                    newGameButton.interactable = true;
                });

                mainMenuButtonImage.DOFade(1, 7f).OnComplete(() =>
                {
                    mainMenuButton.interactable = true;
                });
            }
        }


        if (doubleAward != null)
        {
            doubleAward.onClick.AddListener(() =>
            {
                Debug.Log("DoubleAward");
                Geekplay.Instance.ShowRewardedAd("DoubleAward");
                doubleAward.gameObject.SetActive(false);
            });
        }

        isPressed = false;
        isStop = false;
    }
    public void StartGameImage()
    {
        FirstTime = Geekplay.Instance.PlayerData.PlayerFirstTimePlay;
        FirstTimeNeedShop = Geekplay.Instance.PlayerData.PlayerFirstTimeNeedShop;

        if ((FirstTime == true) && (FirstTimeNeedShop == true))
        {
            return;
        }
        else
        {
            isPressed = true;

            panel.gameObject.SetActive(true);

            isActivacted = false;

            StartCoroutine(ImageMoveStart(MainImagesMover));
            StartCoroutine(ChangeImageLevel());
            StartCoroutine(WaitAwakeGame());
        }
    }

    public void StartMainMenu()
    {
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

    IEnumerator AwakeGame()
    {
        string Level;
        int ii = Random.Range(0, 150);
        int imageLevel = 0;

        if (ii > 120)
        {
            Level = "Level4";
            imageLevel = 0;
        }
        else if(ii > 90 && ii <= 120)
        {
            Level = "Level4";
            imageLevel = 1;
        }
        else if (ii > 60 && ii <= 90)
        {
            Level = "Level4";
            imageLevel = 2;
        }
        else if (ii > 30 && ii <= 60)
        {
            Level = "Level4";
            imageLevel = 3;
        }
        else
        {
            Level = "Level4";
            imageLevel = 4;
        }

        isStop = true;
        StopCoroutine(ChangeImageLevel());
        isPressed = false;

        StopCoroutine(ImageMove(MainImagesMover));

        DOTween.Kill(MainImagesMover.transform);
        
        if(FirstTime == true)
        {
            Sprite sprite = imagesList1[1].GetComponent<Image>().sprite;
            imageCenterImageInPanel.GetComponent<Image>().sprite = sprite;
        }
        else
        {
            Sprite sprite = imagesList1[imageLevel].GetComponent<Image>().sprite;
            imageCenterImageInPanel.GetComponent<Image>().sprite = sprite;
        }
        yield return new WaitForSeconds(1.5f);

        panel.gameObject.SetActive(false);

        FirstTime = Geekplay.Instance.PlayerData.PlayerFirstTimePlay;

        if (isNeedTheLevelLoad == false)
        {
            if (FirstTime == true)
            {
                SceneManager.LoadScene("Level2");
            }
            else
            {
                SceneManager.LoadScene(Level);
            }
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
            Sprite sprite = imagesList1[Random.Range(0, imagesList1.Length)].GetComponent<Image>().sprite;
            imageCenterImageInPanel.GetComponent<Image>().sprite = sprite;
            yield return new WaitForSeconds(0.3f);
            StartCoroutine(ChangeImageLevel());
        }
        else
        {
            yield break;
        }
    }
}
