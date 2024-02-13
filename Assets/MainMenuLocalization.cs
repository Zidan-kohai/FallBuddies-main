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
            buyText.text = "������";
            startGameText.text = "��������� ����";
            tailText.text = "�����";
            hairText.text = "��������";
            hornText.text = "����";
            hatText.text = "�����";
            earsText.text = "���";
            noseText.text = "���";
            mouthText.text = "���";
            headpartsText.text = "����� ������";
            glovesText.text = "��������";
            eyesText.text = "�����";
            bodypartsText.text = "����� ����";
            bodyandskinText.text = "����";
            backToMenuText.text = "��������� � ����";

            rare1.text = "������";
            rare2.text = "������";
            rare3.text = "������";

            unusual1.text = "���������";
            unusual2.text = "���������";
            unusual3.text = "���������";
            unusual4.text = "���������";
            unusual5.text = "�������";
            unusual6.text = "�����������";
            money1.text = "���!";

            for (int i = 0; i < buyedText.Count; i++)
            {
                buyedText[i].text = "�������";
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
