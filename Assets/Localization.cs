using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Localization : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI showSummaryText;
    [SerializeField] private TextMeshProUGUI mainMenuText;
    [SerializeField] private TextMeshProUGUI showRewardText;
    [SerializeField] private TextMeshProUGUI levelUpText;

    public void LocalizationFunc()
    {
    	if (Geekplay.Instance.language == "ru")
    	{
			showSummaryText.text = "Награды";
			mainMenuText.text = "Главное меню";
			showRewardText.text = "Награды";
		    levelUpText.text = "Новый уровень!";
        }
    	else if (Geekplay.Instance.language == "en")
    	{
			showSummaryText.text = "Show Summary";
		    mainMenuText.text = "Main Menu";
		    showRewardText.text = "Rewards";
		    levelUpText.text = "Level Up!";
        } 
    }
}
