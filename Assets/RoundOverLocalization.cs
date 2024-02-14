using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundOverLocalization : MonoBehaviour
{
    [SerializeField] private Sprite rusSprite;
    [SerializeField] private Sprite enSprite;
    [SerializeField] private Sprite trSprite;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            GetComponent<Image>().sprite = rusSprite;
        }
        else if (Geekplay.Instance.language == "en")
        {
            GetComponent<Image>().sprite = enSprite;
        }
        else if (Geekplay.Instance.language == "tr")
        {
            GetComponent<Image>().sprite = trSprite;
        }
    }
}
