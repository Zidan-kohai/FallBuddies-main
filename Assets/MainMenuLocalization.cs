using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuLocalization : MonoBehaviour
{
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

    void Start()
    {
        if (Geekplay.Instance.language == "ru")
        {
            buyText.text = "Купить";
            startGameText.text = "Случайная игра";
            tailText.text = "Хвост";
            hairText.text = "Прическа";
            hornText.text = "Рога";
            hatText.text = "Шляпа";
            earsText.text = "Уши";
            noseText.text = "Нос";
            mouthText.text = "Рот";
            headpartsText.text = "Части головы";
            glovesText.text = "Перчатки";
            eyesText.text = "Глаза";
            bodypartsText.text = "Части тела";
            bodyandskinText.text = "Тело";
            backToMenuText.text = "Вернуться в меню";

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

        }
        else if (Geekplay.Instance.language == "en")
        {
            buyText.text = "Buy";
            startGameText.text = "Random Game";
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
            backToMenuText.text = "Back to Menu";


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

            for (int i = 0; i < buyedText.Count; i++)
            {
                buyedText[i].text = "Buyed";
            }
        }
    }
}
