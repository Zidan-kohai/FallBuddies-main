using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RandomNameAndCountry.Scripts
{
    public class RandomNameAndCountryPicker : MonoBehaviour
    {
        public static RandomNameAndCountryPicker Instance;
        [SerializeField] private List<Sprite> countries;
        private static List<string> m_EnNamesList;
        private static List<string> m_RuNamesList;
        private static List<string> m_TrNamesList;
        private TextAsset enNames;
        private TextAsset ruNames;
        private TextAsset trNames;

        private void Awake()
        {
            Instance = this;
            enNames = Resources.Load("TextFiles/EnNames") as TextAsset;
            ruNames = Resources.Load("TextFiles/RuNames") as TextAsset;
            trNames = Resources.Load("TextFiles/TrNames") as TextAsset;

            ReadTextFile();
            GetRandomPlayerInfo();
        }

        private void ReadTextFile()
        {
            m_EnNamesList = enNames.text.Split('\n').ToList();
            m_RuNamesList = ruNames.text.Split('\n').ToList();
            m_TrNamesList = trNames.text.Split('\n').ToList();
        }

        public RandomPlayerInfo GetRandomPlayerInfo()
        {
            var countrySprite = countries[Random.Range(0, countries.Count)];
            var rawCountryName = countrySprite.name;
            var countryName = Regex.Replace(rawCountryName, "[^a-zA-Z]", "");
            countryName = ToUpperFirstLetter(countryName);
            var randomPlayerInfo = new RandomPlayerInfo();

            if (Geekplay.Instance.language == "en")
            {
                randomPlayerInfo.playerName = m_EnNamesList[UnityEngine.Random.Range(0, m_EnNamesList.Count)];
            }
            else if(Geekplay.Instance.language == "ru")
            {
                randomPlayerInfo.playerName = m_RuNamesList[UnityEngine.Random.Range(0, m_RuNamesList.Count)];
            }
            else if (Geekplay.Instance.language == "tr")
            {
                randomPlayerInfo.playerName = m_TrNamesList[UnityEngine.Random.Range(0, m_TrNamesList.Count)];
            }

            randomPlayerInfo.countrySprite = countrySprite;
            randomPlayerInfo.countryName = countryName;
            Debug.Log(countryName);
            return randomPlayerInfo;
        }
        
        private string ToUpperFirstLetter(string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            // convert to char array of the string
            char[] letters = source.ToCharArray();
            // upper case the first char
            letters[0] = char.ToUpper(letters[0]);
            // return the array made of the new char array
            return new string(letters);
        }
    }

    public class RandomPlayerInfo
    {
        public string playerName;
        public string countryName;
        public Sprite countrySprite;

        public RandomPlayerInfo()
        {
            
        }
    }
}
