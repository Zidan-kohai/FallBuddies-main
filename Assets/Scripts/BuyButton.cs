using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyButton : MonoBehaviour
{
    public GameObject CheckChar;
    public GameObject CanvasMain;
    public GameObject ThisCharacter;
    public CheckCharactersScript CCharScript;
    public Geekplay CMainInit;
    public bool isBodies;
    public bool isBodyparts;
    public bool isEyes;
    public bool isGloves;
    public bool isHeadparts;
    public bool isMounth;
    public bool isNoise;
    public bool isCombs;
    public bool isEars;
    public bool isEyesFromHead;
    public bool isHair;
    public bool isHat;
    public bool isHorn;
    public bool isTails;

    public int idBuy;
    public int idCost;
    public int idCostHard;
    public bool idIsHardMoney;
    public bool idIsAD;
    public bool isBought;
    public TMP_Text textBuy;

    public AudioSource audioSource;

    public void Start()
    {
        CCharScript = CheckChar.GetComponent<CheckCharactersScript>();
        CMainInit = CanvasMain.GetComponent<Geekplay>();


        Geekplay.Instance.SubscribeOnReward("ShopBody", AdBuyBodies);
        Geekplay.Instance.SubscribeOnReward("ShopBodyparts", AdBuyBodyparts);
        Geekplay.Instance.SubscribeOnReward("ShopEars", AdBuyEars);
        Geekplay.Instance.SubscribeOnReward("ShopEyes", AdBuyEyes);
        Geekplay.Instance.SubscribeOnReward("ShopEyesFromHead", AdBuyEyesFromHead);
        Geekplay.Instance.SubscribeOnReward("ShopGloves", AdBuyGloves);
        Geekplay.Instance.SubscribeOnReward("ShopHair", AdBuyHair);
        Geekplay.Instance.SubscribeOnReward("ShopHat", AdBuyHat);
        Geekplay.Instance.SubscribeOnReward("ShopHeadparts", AdBuyHeadparts);
        Geekplay.Instance.SubscribeOnReward("ShopHorn", AdBuyHorn);
        Geekplay.Instance.SubscribeOnReward("ShopMouth", AdBuyMounth);
        Geekplay.Instance.SubscribeOnReward("ShopNoise", AdBuyNoise);
        Geekplay.Instance.SubscribeOnReward("ShopAd", AdBuyTail);

    }

    public void StartBuy()
    {
        if(isBought == false)
        {
            if (isBodies)
            {
                if (CMainInit.PlayerData.Bodies[idBuy] == 0)
                {
                    if (idIsAD)
                    {
                        Geekplay.Instance.ShowRewardedAd("ShopBody");
                    }
                    else if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                    {
                        audioSource.clip.name = "Buy";
                        audioSource.Play();
                        CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                        CMainInit.PlayerData.Bodies[idBuy] = 1;
                        this.gameObject.SetActive(false);
                        Debug.Log("Geekplay.Instance.Save()");
                        Geekplay.Instance.Save();
                    }
                    else if(idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                    {
                        audioSource.clip.name = "Buy";
                        audioSource.Play();
                        CMainInit.PlayerData.PlayerMoney -= idCost;
                        CMainInit.PlayerData.Bodies[idBuy] = 1;
                        this.gameObject.SetActive(false);
                        Debug.Log("Geekplay.Instance.Save()");
                        Geekplay.Instance.Save();
                    }
                }
                else
                {

                }


                for (int i = 0; i < CMainInit.PlayerData.CharacterBodies.Length; i++)
                {
                    CMainInit.PlayerData.CharacterBodies[i] = 0;
                }

                CMainInit.PlayerData.CharacterBodies[idBuy] = 1;
            }
            else if (isBodyparts)
            {
                if (CMainInit.PlayerData.Bodyparts[idBuy] == 0)
                {
                    if (idIsAD)
                    {
                        Geekplay.Instance.ShowRewardedAd("ShopBodyparts");
                    }
                    else if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                    {
                        CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                        CMainInit.PlayerData.Bodyparts[idBuy] = 1;
                        this.gameObject.SetActive(false);
                        Debug.Log("Geekplay.Instance.Save()");
                        Geekplay.Instance.Save();
                    }
                    else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                    {
                        CMainInit.PlayerData.PlayerMoney -= idCost;
                        CMainInit.PlayerData.Bodyparts[idBuy] = 1;
                        this.gameObject.SetActive(false);
                        Debug.Log("Geekplay.Instance.Save()");
                        Geekplay.Instance.Save();
                    }
                }
                else
                {
                    
                    
                }

                for (int i = 0; i < CMainInit.PlayerData.CharacterBodyparts.Length; i++)
                {
                    CMainInit.PlayerData.CharacterBodyparts[i] = 0;
                }

                CMainInit.PlayerData.CharacterBodyparts[idBuy] = 1;
            }
            else if (isEyes)
            {
                if (CMainInit.PlayerData.Eyes[idBuy] == 0)
                {
                    if (idIsAD)
                    {
                        Geekplay.Instance.ShowRewardedAd("ShopEyes");
                    }
                    else if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                    {
                        CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                        CMainInit.PlayerData.Eyes[idBuy] = 1;
                        this.gameObject.SetActive(false);
                        Debug.Log("Geekplay.Instance.Save()");
                        Geekplay.Instance.Save();
                    }
                    else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                    {
                        CMainInit.PlayerData.PlayerMoney -= idCost;
                        CMainInit.PlayerData.Eyes[idBuy] = 1;
                        this.gameObject.SetActive(false);
                        Debug.Log("Geekplay.Instance.Save()");
                        Geekplay.Instance.Save();
                    }
                }
                else
                {
                     
                }
                for (int i = 0; i < CMainInit.PlayerData.CharacterEyes.Length; i++)
                {
                    CMainInit.PlayerData.CharacterEyes[i] = 0;
                }

                CMainInit.PlayerData.CharacterEyes[idBuy] = 1;
            }
            else if (isGloves)
            {
                if (CMainInit.PlayerData.Gloves[idBuy] == 0)
                {
                    if (idIsAD)
                    {
                        Geekplay.Instance.ShowRewardedAd("ShopGloves");
                    }
                    else if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                    {
                        CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                        CMainInit.PlayerData.Gloves[idBuy] = 1;
                        this.gameObject.SetActive(false);
                        Debug.Log("Geekplay.Instance.Save()");
                        Geekplay.Instance.Save();
                    }
                    
                    else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                    {
                        CMainInit.PlayerData.PlayerMoney -= idCost;
                        CMainInit.PlayerData.Gloves[idBuy] = 1;
                        this.gameObject.SetActive(false);
                        Debug.Log("Geekplay.Instance.Save()");
                        Geekplay.Instance.Save();
                    }
                    
                }
                else
                {

                }

                for (int i = 0; i < CMainInit.PlayerData.CharacterGloves.Length; i++)
                {
                    CMainInit.PlayerData.CharacterGloves[i] = 0;
                }

                CMainInit.PlayerData.CharacterGloves[idBuy] = 1;
            }
            else if (isHeadparts)
            {
                if (idIsAD)
                {
                    Geekplay.Instance.ShowRewardedAd("ShopHeadparts");
                }
                else if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Headparts[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Headparts[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }

                for (int i = 0; i < CMainInit.PlayerData.CharacterHeadparts.Length; i++)
                {
                    CMainInit.PlayerData.CharacterHeadparts[i] = 0;
                }

                CMainInit.PlayerData.CharacterHeadparts[idBuy] = 1;
            }
            else if (isMounth)
            {
                if (idIsAD)
                {
                    Geekplay.Instance.ShowRewardedAd("ShopMouth");
                }
                else if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Mounth[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Mounth[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }

                for (int i = 0; i < CMainInit.PlayerData.CharacterMounth.Length; i++)
                {
                    CMainInit.PlayerData.CharacterMounth[i] = 0;
                }

                CMainInit.PlayerData.CharacterMounth[idBuy] = 1;
            }
            else if (isNoise)
            {
                if (idIsAD)
                {
                    Geekplay.Instance.ShowRewardedAd("ShopNoise");
                }
                else if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Noise[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Noise[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }

                for (int i = 0; i < CMainInit.PlayerData.CharacterNoise.Length; i++)
                {
                    CMainInit.PlayerData.CharacterNoise[i] = 0;
                }

                CMainInit.PlayerData.CharacterNoise[idBuy] = 1;
            }
            else if (isCombs)
            {
                if (idIsAD)
                {
                    Geekplay.Instance.ShowRewardedAd("ShopCombs");
                }
                else if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Combs[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Combs[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }

                for (int i = 0; i < CMainInit.PlayerData.CharacterCombs.Length; i++)
                {
                    CMainInit.PlayerData.CharacterCombs[i] = 0;
                }

                CMainInit.PlayerData.CharacterCombs[idBuy] = 1;
            }
            else if (isEars)
            {
                if (idIsAD)
                {
                    Geekplay.Instance.ShowRewardedAd("ShopEars");
                }
                else if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Ears[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Ears[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }

                for (int i = 0; i < CMainInit.PlayerData.CharacterEars.Length; i++)
                {
                    CMainInit.PlayerData.CharacterEars[i] = 0;
                }

                CMainInit.PlayerData.CharacterEars[idBuy] = 1;
            }
            else if (isEyesFromHead)
            {
                if (idIsAD)
                {
                    Geekplay.Instance.ShowRewardedAd("ShopEyesFromHead");
                }
                else if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.EyesFromHead[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.EyesFromHead[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }

                for (int i = 0; i < CMainInit.PlayerData.CharacterEyesFromHead.Length; i++)
                {
                    CMainInit.PlayerData.CharacterEyesFromHead[i] = 0;
                }

                CMainInit.PlayerData.CharacterEyesFromHead[idBuy] = 1;
            }
            else if (isHair)
            {
                if (idIsAD)
                {
                    Geekplay.Instance.ShowRewardedAd("ShopHair");
                }
                else if(idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Hair[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Hair[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                } 


                for (int i = 0; i < CMainInit.PlayerData.CharacterHair.Length; i++)
                {
                    CMainInit.PlayerData.CharacterHair[i] = 0;
                }

                CMainInit.PlayerData.CharacterHair[idBuy] = 1;

            }
            else if (isHat)
            {
                if (idIsAD)
                {
                    Geekplay.Instance.ShowRewardedAd("ShopHat");
                }
                else if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Hat[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Hat[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }

                for (int i = 0; i < CMainInit.PlayerData.CharacterHat.Length; i++)
                {
                    CMainInit.PlayerData.CharacterHat[i] = 0;
                }

                CMainInit.PlayerData.CharacterHat[idBuy] = 1;
            }
            else if (isHorn)
            {
                if (idIsAD)
                {
                    Geekplay.Instance.ShowRewardedAd("ShopHorn");
                }
                else if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Horn[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Horn[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }

                for (int i = 0; i < CMainInit.PlayerData.CharacterHorn.Length; i++)
                {
                    CMainInit.PlayerData.CharacterHorn[i] = 0;
                }

                CMainInit.PlayerData.CharacterHorn[idBuy] = 1;
            }
            else if (isTails)
            {
                if (idIsAD)
                {
                    Geekplay.Instance.ShowRewardedAd("ShopTail");
                }
                else if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Tails[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Tails[idBuy] = 1;
                    this.gameObject.SetActive(false);
                    Debug.Log("Geekplay.Instance.Save()");
                    Geekplay.Instance.Save();
                }

                for (int i = 0; i < CMainInit.PlayerData.CharacterTails.Length; i++)
                {
                    CMainInit.PlayerData.CharacterTails[i] = 0;
                }

                CMainInit.PlayerData.CharacterTails[idBuy] = 1;
            }
            else
            {
                
            }
        }
        else
        {
            if (isBodies)
            {
                if (CMainInit.PlayerData.Bodies[idBuy] > 0)
                {
                     
                    if (CMainInit.PlayerData.CharacterBodies[idBuy] == 0)
                    {
                        for(int  i = 0; i < CMainInit.PlayerData.CharacterBodies.Length; i++)
                        {
                            CMainInit.PlayerData.CharacterBodies[i] = 0;
                        }
                        CMainInit.PlayerData.CharacterBodies[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterBodies[idBuy] = 0;
                    }
                }
                else
                {
                     
                }
            }
            else if (isBodyparts)
            {
                if (CMainInit.PlayerData.Bodyparts[idBuy] > 0)
                {
                     
                    if(CMainInit.PlayerData.CharacterBodyparts[idBuy] == 0)
                    {
                        for (int i = 0; i < CMainInit.PlayerData.CharacterBodyparts.Length; i++)
                        {
                            CMainInit.PlayerData.CharacterBodyparts[i] = 0;
                        }

                        CMainInit.PlayerData.CharacterBodyparts[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterBodyparts[idBuy] = 0;
                    }
                }
                else
                {
                     
                }
            }
            else if (isEyes)
            {
                if (CMainInit.PlayerData.Eyes[idBuy] > 0)
                {
                     
                    if (CMainInit.PlayerData.CharacterEyes[idBuy] == 0)
                    {
                        for (int i = 0; i < CMainInit.PlayerData.CharacterEyes.Length; i++)
                        {
                            CMainInit.PlayerData.CharacterEyes[i] = 0;
                        }

                        CMainInit.PlayerData.CharacterEyes[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterEyes[idBuy] = 0;
                    }
                }
                else
                {
                     
                }
            }
            else if (isGloves)
            {
                if (CMainInit.PlayerData.Gloves[idBuy] > 0)
                {
                     
                    if (CMainInit.PlayerData.CharacterGloves[idBuy] == 0)
                    {
                        for (int i = 0; i < CMainInit.PlayerData.CharacterGloves.Length; i++)
                        {
                            CMainInit.PlayerData.CharacterGloves[i] = 0;
                        }

                        CMainInit.PlayerData.CharacterGloves[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterGloves[idBuy] = 0;
                    }
                }
                else
                {
                     
                }
            }
            else if (isHeadparts)
            {
                if (CMainInit.PlayerData.Headparts[idBuy] > 0)
                {
                     
                    if (CMainInit.PlayerData.CharacterHeadparts[idBuy] == 0)
                    {
                        for (int i = 0; i < CMainInit.PlayerData.CharacterHeadparts.Length; i++)
                        {
                            CMainInit.PlayerData.CharacterHeadparts[i] = 0;
                        }

                        CMainInit.PlayerData.CharacterHeadparts[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterHeadparts[idBuy] = 0;
                    }
                }
                else
                {
                     
                }
            }
            else if (isMounth)
            {
                if (CMainInit.PlayerData.Mounth[idBuy] > 0)
                {
                     
                    if (CMainInit.PlayerData.CharacterMounth[idBuy] == 0)
                    {

                        for (int i = 0; i < CMainInit.PlayerData.CharacterMounth.Length; i++)
                        {
                            CMainInit.PlayerData.CharacterMounth[i] = 0;
                        }

                        CMainInit.PlayerData.CharacterMounth[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterMounth[idBuy] = 0;
                    }
                }
                else
                {
                     
                }
            }
            else if (isNoise)
            {
                if (CMainInit.PlayerData.Noise[idBuy] > 0)
                {
                     
                    if (CMainInit.PlayerData.CharacterNoise[idBuy] == 0)
                    {
                        for (int i = 0; i < CMainInit.PlayerData.CharacterNoise.Length; i++)
                        {
                            CMainInit.PlayerData.CharacterNoise[i] = 0;
                        }

                        CMainInit.PlayerData.CharacterNoise[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterNoise[idBuy] = 0;
                    }
                }
                else
                {
                     
                }
            }
            else if (isCombs)
            {
                if (CMainInit.PlayerData.Combs[idBuy] > 0)
                {
                     
                    if (CMainInit.PlayerData.CharacterCombs[idBuy] == 0)
                    {
                        for (int i = 0; i < CMainInit.PlayerData.CharacterCombs.Length; i++)
                        {
                            CMainInit.PlayerData.CharacterCombs[i] = 0;
                        }

                        CMainInit.PlayerData.CharacterCombs[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterCombs[idBuy] = 0;
                    }
                }
                else
                {
                     
                }
            }
            else if (isEars)
            {
                if (CMainInit.PlayerData.Ears[idBuy] > 0)
                {
                     
                    if (CMainInit.PlayerData.CharacterEars[idBuy] == 0)
                    {
                        for (int i = 0; i < CMainInit.PlayerData.CharacterEars.Length; i++)
                        {
                            CMainInit.PlayerData.CharacterEars[i] = 0;
                        }

                        CMainInit.PlayerData.CharacterEars[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterEars[idBuy] = 0;
                    }
                }
                else
                {
                     
                }
            }
            else if (isEyesFromHead)
            {
                if (CMainInit.PlayerData.EyesFromHead[idBuy] > 0)
                {
                     
                    if (CMainInit.PlayerData.CharacterEyesFromHead[idBuy] == 0)
                    {
                        for (int i = 0; i < CMainInit.PlayerData.CharacterEyesFromHead.Length; i++)
                        {
                            CMainInit.PlayerData.CharacterEyesFromHead[i] = 0;
                        }

                        CMainInit.PlayerData.CharacterEyesFromHead[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterEyesFromHead[idBuy] = 0;
                    }
                }
                else
                {
                     
                }
            }
            else if (isHair)
            {
                if (CMainInit.PlayerData.Hair[idBuy] > 0)
                {
                     
                    if (CMainInit.PlayerData.CharacterHair[idBuy] == 0)
                    {

                        for (int i = 0; i < CMainInit.PlayerData.CharacterHair.Length; i++)
                        {
                            CMainInit.PlayerData.CharacterHair[i] = 0;
                        }

                        CMainInit.PlayerData.CharacterHair[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterHair[idBuy] = 0;
                    }
                }
                else
                {
                     
                }
            }
            else if (isHat)
            {
                if (CMainInit.PlayerData.Hat[idBuy] > 0)
                {
                     
                    if (CMainInit.PlayerData.CharacterHat[idBuy] == 0)
                    {
                        for (int i = 0; i < CMainInit.PlayerData.CharacterHat.Length; i++)
                        {
                            CMainInit.PlayerData.CharacterHat[i] = 0;
                        }

                        CMainInit.PlayerData.CharacterHat[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterHat[idBuy] = 0;
                    }
                }
                else
                {
                     
                }
            }
            else if (isHorn)
            {
                if (CMainInit.PlayerData.Horn[idBuy] > 0)
                {
                     
                    if (CMainInit.PlayerData.CharacterHorn[idBuy] == 0)
                    {
                        for (int i = 0; i < CMainInit.PlayerData.CharacterHorn.Length; i++)
                        {
                            CMainInit.PlayerData.CharacterHorn[i] = 0;
                        }

                        CMainInit.PlayerData.CharacterHorn[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterHorn[idBuy] = 0;
                    }
                }
                else
                {
                     
                }
            }
            else if (isTails)
            {
                if (CMainInit.PlayerData.Tails[idBuy] > 0)
                {
                     
                    if (CMainInit.PlayerData.CharacterTails[idBuy] == 0)
                    {
                        for (int i = 0; i < CMainInit.PlayerData.CharacterTails.Length; i++)
                        {
                            CMainInit.PlayerData.CharacterTails[i] = 0;
                        }

                        CMainInit.PlayerData.CharacterTails[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterTails[idBuy] = 0;
                    }
                }
                else
                {
                     
                }
            }
        }
        
        /*else if (is)
        {
            if (CMainInit.PlayerData.[idBuy] == 0)
            {
                CMainInit.PlayerData.[idBuy] = 1;
            }
        }*/

    }

    public void OnEnable()
    {
        CanvasMain = FindObjectOfType<Geekplay>().gameObject;
        CMainInit = CanvasMain.GetComponent<Geekplay>();
    }

    public void OnDisable()
    {
        
    }
    private void Update()
    {
        if(isBought == false)
        {
            if (Geekplay.Instance.language == "en")
            {
                textBuy.text = "Buy";
            }
            else if (Geekplay.Instance.language == "ru")
            {
                textBuy.text = "Купить";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                textBuy.text = "Satin almak";
            }

            if (idIsAD == true)
            {
                if(Geekplay.Instance.language == "en")
                {
                    textBuy.text = "Get";
                }
                else if (Geekplay.Instance.language == "ru")
                {
                    textBuy.text = "Получить";
                }
                else if(Geekplay.Instance.language == "tr")
                {
                    textBuy.text = "Elde etmek";
                }
            }
        }
        else
        {
            if (Geekplay.Instance.language == "en")
            {
                textBuy.text = "Equip";
            }
            else if(Geekplay.Instance.language == "ru")
            {
                textBuy.text = "Надеть";
            }
            else if(Geekplay.Instance.language == "tr")
            {
                textBuy.text = "Donatmak";
            }
        }
    }

    public void AdBuyBodies()
    {
        CMainInit.PlayerData.Bodies[idBuy] = 1;
        audioSource.clip.name = "Buy";
        audioSource.Play();
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }
    public void AdBuyBodyparts()
    {
        CMainInit.PlayerData.Bodyparts[idBuy] = 1;
        audioSource.clip.name = "Buy";
        audioSource.Play();
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }
    public void AdBuyEyes()
    {
        CMainInit.PlayerData.Eyes[idBuy] = 1;
        audioSource.clip.name = "Buy";
        audioSource.Play();
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }
    public void AdBuyGloves()
    {
        CMainInit.PlayerData.Gloves[idBuy] = 1;
        audioSource.clip.name = "Buy";
        audioSource.Play();
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }
    public void AdBuyHeadparts()
    {
        CMainInit.PlayerData.Headparts[idBuy] = 1;
        audioSource.clip.name = "Buy";
        audioSource.Play();
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }
    public void AdBuyMounth()
    {
        CMainInit.PlayerData.Mounth[idBuy] = 1;
        audioSource.clip.name = "Buy";
        audioSource.Play();
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }
    public void AdBuyNoise()
    {
        CMainInit.PlayerData.Noise[idBuy] = 1;
        audioSource.clip.name = "Buy";
        audioSource.Play();
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }
    public void AdBuyCombs()
    {
        CMainInit.PlayerData.Combs[idBuy] = 1;
        audioSource.clip.name = "Buy";
        audioSource.Play();
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }
    public void AdBuyEars()
    {
        CMainInit.PlayerData.Ears[idBuy] = 1;
        audioSource.clip.name = "Buy";
        audioSource.Play();
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }
    public void AdBuyEyesFromHead()
    {
        CMainInit.PlayerData.EyesFromHead[idBuy] = 1;
        audioSource.clip.name = "Buy";
        audioSource.Play();
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }
    public void AdBuyHair()
    {
        CMainInit.PlayerData.Hair[idBuy] = 1;
        audioSource.clip.name = "Buy";
        audioSource.Play();
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }
    public void AdBuyHat()
    {
        CMainInit.PlayerData.Hat[idBuy] = 1;
        audioSource.clip.name = "Buy";
        audioSource.Play();
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }
    public void AdBuyHorn()
    {
        CMainInit.PlayerData.Horn[idBuy] = 1;
        audioSource.clip.name = "Buy";
        audioSource.Play();
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }
    public void AdBuyTail()
    {
        CMainInit.PlayerData.Tails[idBuy] = 1;
        audioSource.clip.name = "Buy";
        audioSource.Play();
        Debug.Log("Geekplay.Instance.Save()");
        Geekplay.Instance.Save();
    }
}