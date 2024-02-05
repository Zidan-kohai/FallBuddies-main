using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundOverLocalization : MonoBehaviour
{
    [SerializeField] private Sprite rusSprite;
    [SerializeField] private Sprite enSprite;

    void Start()
    {
    	if (Geekplay.Instance.language == "ru")
       		GetComponent<Image>().sprite = rusSprite;
       	else
       		GetComponent<Image>().sprite = enSprite;
    }
}
