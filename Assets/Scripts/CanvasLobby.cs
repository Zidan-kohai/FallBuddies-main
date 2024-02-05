using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasLobby : MonoBehaviour
{
    public RectTransform ButtonPr;
    public RectTransform ButtonNe;
    public RectTransform ButtonRa;
    public RectTransform ButtonStart;
    public RectTransform ButtonMenu;

    public GameObject MainCanvas;

    public TMP_Text PlaceText;

    private void OnEnable()
    {
        MainCanvas = FindObjectOfType<Geekplay>().gameObject;
        SceneManager.sceneLoaded += OnSceneLoaded;
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
