using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardInGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leadersText;

    [SerializeField] private TextMeshProUGUI leadersText1Bottom;

    [SerializeField] private TextMeshProUGUI LeaderBoardHeader;

    private float timeFlag = 0;
    void Start()
    {
        Geekplay.Instance.leaderboardInGame = this;
        int time = Convert.ToInt32(Geekplay.Instance.remainingTimeUntilUpdateLeaderboard);

        if (Geekplay.Instance.language == "en")
        {
            LeaderBoardHeader.text = "Leaders \"Fall Buddies\"";
            leadersText1Bottom.text = $"Table will be updated in: {time}";
        }
        else if (Geekplay.Instance.language == "ru")
        {

            LeaderBoardHeader.text = "лидеры \"Fall Buddies\""; 
            leadersText1Bottom.text = $"Таблица обновится через: {time}";
        }
        else if (Geekplay.Instance.language == "tr")
        {
            LeaderBoardHeader.text = "liderler \"Fall Buddies\"";
            leadersText1Bottom.text = $"Su yolla guncellendi: {time}";
        }

        if (Geekplay.Instance.remainingTimeUntilUpdateLeaderboard <= 0)
            UpdateLeaderBoard();

        else if (Geekplay.Instance.lastLeaderText != string.Empty)
        {
            leadersText.text = Geekplay.Instance.lastLeaderText;
        }
    }


    private void Update()
    {
        if (Geekplay.Instance.remainingTimeUntilUpdateLeaderboard <= 0)
        {
            UpdateLeaderBoard();
        }
        timeFlag += Time.deltaTime;

        if (timeFlag < 1f) return;

        timeFlag = 0;
        int time = Convert.ToInt32(Geekplay.Instance.remainingTimeUntilUpdateLeaderboard);


        if (Geekplay.Instance.language == "en")
        {
            leadersText1Bottom.text = $"Table will be updated in: {time}";
        }
        else if (Geekplay.Instance.language == "ru")
        {
            leadersText1Bottom.text = $"Таблица обновится через: {time}";
        }
        else if (Geekplay.Instance.language == "tr")
        {
            leadersText1Bottom.text = $"Su yolla guncellendi: {time}";
        }

    }
    public void SetText()
    {
        leadersText.text = "";
        Geekplay.Instance.lastLeaderText = "";
        for (int i = 0; i < Geekplay.Instance.l.Length; i++)
        {
            if (Geekplay.Instance.l[i] != null && Geekplay.Instance.lN[i] != null)
            {
                if (Geekplay.Instance.l[i].Contains("カ"))
                {
                    Debug.Log("JAPAN");
                    continue;
                }
                string s = $"{i + 1}. {Geekplay.Instance.lN[i]} : {Geekplay.Instance.l[i]}\n";
                if (s == $"{i + 1}.  : \n")
                {
                    s = $"{i + 1}.\n";
                }
                Geekplay.Instance.lastLeaderText += $"{i + 1}. {Geekplay.Instance.lN[i]} : {Geekplay.Instance.l[i]}\n";
                leadersText.text = Geekplay.Instance.lastLeaderText;
                //$"{i + 1}. {Geekplay.Instance.lN[i]} : {Geekplay.Instance.l[i]}\n"
            }
        }
    }

    public void UpdateLeaderBoard()
    {
        Geekplay.Instance.remainingTimeUntilUpdateLeaderboard = Geekplay.Instance.timeToUpdateLeaderboard;

        Geekplay.Instance.leaderNumber = 0;
        Geekplay.Instance.leaderNumberN = 0;
        Utils.GetLeaderboard("score", 0);
        Utils.GetLeaderboard("name", 0);
    }
}
