using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Localization : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI showSummaryText;
    [SerializeField] private TextMeshProUGUI mainMenuText;
    [SerializeField] private TextMeshProUGUI buyText;
    [SerializeField] private TextMeshProUGUI startGameText;
    [SerializeField] private TextMeshProUGUI backToMenuText;
    [SerializeField] private TextMeshProUGUI tailText;
    [SerializeField] private TextMeshProUGUI hairText;
    [SerializeField] private TextMeshProUGUI hornText;
    [SerializeField] private TextMeshProUGUI hatText;
    [SerializeField] private TextMeshProUGUI earsText;
    [SerializeField] private TextMeshProUGUI noseText;
    [SerializeField] private TextMeshProUGUI mouthText;
    [SerializeField] private TextMeshProUGUI headpartsText;
    [SerializeField] private TextMeshProUGUI glovesText;
    [SerializeField] private TextMeshProUGUI eyesText;
    [SerializeField] private TextMeshProUGUI bodypartsText;
    [SerializeField] private TextMeshProUGUI bodyandskinText;
    [SerializeField] private TextMeshProUGUI showRewardText;
    [SerializeField] private TextMeshProUGUI levelUpText;

    public void LocalizationFunc()
    {
    	if (Geekplay.Instance.language == "ru")
    	{
			showSummaryText.text = "Награды";
			mainMenuText.text = "Главное меню";
			buyText.text = "Купить";
			startGameText.text = "Начать игру";
			backToMenuText.text = "Вернуться в меню";
			tailText.text = "Хвост";
			hairText.text = "Прическа";
			hornText.text = "Рупор";
			hatText.text = "Шляпа";
			earsText.text = "Уши";
			noseText.text = "Нос";
			mouthText.text = "Рот";
			headpartsText.text = "Части головы";
			glovesText.text = "Перчатки";
			eyesText.text = "Глаза";
			bodypartsText.text = "Части тела";
			bodyandskinText.text = "Тело";
			showRewardText.text = "Награды";
		    levelUpText.text = "Новый уровень!";
    	}
    	else if (Geekplay.Instance.language == "en")
    	{
			showSummaryText.text = "Show Summary";
		    mainMenuText.text = "Main Menu";
		    buyText.text = "Buy";
		    startGameText.text = "Start Game";
		    backToMenuText.text = "Back to Menu";
		    tailText.text = "Tail";
		    hairText.text = "Hair";
		    hornText.text = "Horn";
		    hatText.text = "Hat";
		    earsText.text = "Ears";
		    noseText.text = "Nose";
		    mouthText.text = "Mouth";
		    headpartsText.text = "Headparts";
		    glovesText.text = "Gloves";
		    eyesText.text = "Eyes";
		    bodypartsText.text = "Bodyparts";
		    bodyandskinText.text = "Bodies";
		    showRewardText.text = "Rewards";
		    levelUpText.text = "Level Up!";
    	} 
    }
}
