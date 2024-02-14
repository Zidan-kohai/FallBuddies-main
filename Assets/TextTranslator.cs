using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTranslator : MonoBehaviour
{
	[SerializeField] private string r;
	[SerializeField] private string e;
	[SerializeField] private string t;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
        	GetComponent<TextMeshProUGUI>().text = r;
        }
        else if(Geekplay.Instance.language == "en") 
        {
        	GetComponent<TextMeshProUGUI>().text = e;
        }
        else if(Geekplay.Instance.language == "tr")
        {
            GetComponent<TextMeshProUGUI>().text = t;
        }
    }
}
