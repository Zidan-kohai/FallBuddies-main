using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTranslator : MonoBehaviour
{
	[SerializeField] private string r;
	[SerializeField] private string e;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
        	GetComponent<TextMeshProUGUI>().text = r;
        }
        else
        {
        	GetComponent<TextMeshProUGUI>().text = e;
        }
    }
}
