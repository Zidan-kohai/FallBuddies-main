using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using JetBrains.Annotations;

public class CanvasLobby : MonoBehaviour
{
    public RectTransform ButtonPr;
    public RectTransform ButtonNe;
    public RectTransform ButtonRa;
    public RectTransform ButtonStart;
    public RectTransform ButtonMenu;

    public GameObject MainCanvas;

    public TMP_Text PlaceText;

    [Header("In App Shop")]
    [SerializeField] private List<GameObject> panelsToDisableWhenInAppTurnOn;
    [SerializeField] private GameObject inAppShop;

    public TMP_Text TextValueMoney;
    public TMP_Text TextValueHardMoney;

    public PlayerDataUIValue playerDataUIValue;

    private void OnEnable()
    {
        MainCanvas = FindObjectOfType<Geekplay>().gameObject;
        SceneManager.sceneLoaded += OnSceneLoaded;

        playerDataUIValue = FindObjectOfType<PlayerDataUIValue>();

        playerDataUIValue.TextValueMoney = TextValueMoney;
        playerDataUIValue.TextValueHardMoney = TextValueHardMoney;
    }

    public void ShowOrDisableInAppShop()
    {
        Debug.Log("asdsadasd");
        if (inAppShop.activeSelf)
        {
            foreach (var item in panelsToDisableWhenInAppTurnOn)
            {
                item.SetActive(true);
            }

            inAppShop.SetActive(false);
        }
        else
        {
            inAppShop.SetActive(true);

            foreach (var item in panelsToDisableWhenInAppTurnOn)
            {
                item.SetActive(false);
            }
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var InvokerMethod = MainCanvas.gameObject.GetComponent<PlayerDataUIValue>();
        InvokerMethod.isLevelUp = false;
        if (Geekplay.Instance.language == "en")
            PlaceText.text = "Place: " + InvokerMethod.PlaceInLevel;
        else
            PlaceText.text = "Место: " + InvokerMethod.PlaceInLevel;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
