using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LobbyLocalization : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI mainMenuText;
	[SerializeField] private TextMeshProUGUI tutorText;
	[SerializeField] private TextMeshProUGUI startGameText;
    [SerializeField] private TextMeshProUGUI doubleAwardButtonText;


    [Header("InApp")]
    [SerializeField] private TextMeshProUGUI rare1;
    [SerializeField] private TextMeshProUGUI rare2;
    [SerializeField] private TextMeshProUGUI rare3;

    [SerializeField] private TextMeshProUGUI unusual1;
    [SerializeField] private TextMeshProUGUI unusual2;
    [SerializeField] private TextMeshProUGUI unusual3;
    [SerializeField] private TextMeshProUGUI unusual4;
    [SerializeField] private TextMeshProUGUI unusual5;
    [SerializeField] private TextMeshProUGUI unusual6;
    [SerializeField] private TextMeshProUGUI money1;
    [SerializeField] private List<TextMeshProUGUI> buyedText;

    [SerializeField] private List<TextMeshProUGUI> YanText;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
        	mainMenuText.text = "Главное Меню";
        	tutorText.text = "Ты получил награду! Давай потратим ее на скины!";
        	startGameText.text = "Старт игры";
            doubleAwardButtonText.text = "Удвоить награду";

            rare1.text = "редкое";
            rare2.text = "редкое";
            rare3.text = "редкое";

            unusual1.text = "Необычное";
            unusual2.text = "Необычное";
            unusual3.text = "Необычное";
            unusual4.text = "Необычное";
            unusual5.text = "Эпичный";
            unusual6.text = "Легендарный";
            money1.text = "Вау!";

            for (int i = 0; i < buyedText.Count; i++)
            {
                buyedText[i].text = "куплено";
            }

            for (int i = 0; i < YanText.Count; i++)
            {
                YanText[i].text = "Ян";
            }
        }
        else
        {
			mainMenuText.text = "Main Menu";
        	tutorText.text = "They gave you a reward for passing the game. Let`s try to speng it!";
        	startGameText.text = "Start Game";
            doubleAwardButtonText.text = "Double award";

            rare1.text = "rare";
            rare2.text = "rare";
            rare3.text = "rare";

            unusual1.text = "Unusual";
            unusual2.text = "Unusual";
            unusual3.text = "Unusual";
            unusual4.text = "Unusual";
            unusual5.text = "Epic";
            unusual6.text = "Legendary";
            money1.text = "WOW!";

            for (int i = 0; i < YanText.Count; i++)
            {
                YanText[i].text = "Yan";
            }
        }
    }
}
