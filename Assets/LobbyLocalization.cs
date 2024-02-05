using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LobbyLocalization : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI mainMenuText;
	[SerializeField] private TextMeshProUGUI tutorText;
	[SerializeField] private TextMeshProUGUI startGameText;

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
        	mainMenuText.text = "Главное Меню";
        	tutorText.text = "Ты получил награду! Давай потратим ее на скины!";
        	startGameText.text = "Старт игры";
        }
        else
        {
			mainMenuText.text = "Main Menu";
        	tutorText.text = "They gave you a reward for passing the game. Let`s try to speng it!";
        	startGameText.text = "Start Game";
        }
    }
}
