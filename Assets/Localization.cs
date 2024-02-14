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

    private void Start()
    {
        LocalizationFunc();
    }

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
        else if (Geekplay.Instance.language == "tr")
        {
            showSummaryText.text = "Ozeti Goster";
            mainMenuText.text = "Ana Menu";
            showRewardText.text = "Oduller";
            levelUpText.text = "Seviye Yukselt!";
        }
    }
}
