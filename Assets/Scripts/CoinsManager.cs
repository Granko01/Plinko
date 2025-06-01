using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    [Header("Int's")]
    public int Coins;
    public int Score;
    public int X2;
    public int Timer;
    public int Shield;
    public int Fire;
    public int Magnet;
    public int Freeze;

    [Header("String")]
    public Text[] CoinsText;
    public Text[] ScoreText;
    public Text[] X2Text;
    public Text[] TimerText;
    public Text[] ShieldText;
    public Text[] FireText;
    public Text[] MagnetText;
    public Text[] FreezeText;

    private const string CoinsKey = "Coinsk";
    private const string ScoreKey = "Scorek";
    private const string X2Key = "X2k";
    private const string TimerKey = "Timerk";
    private const string ShieldKey = "Shieldk";
    private const string FireKey = "Firek";
    private const string MagnetKey = "Magnetk";
    private const string FreezeKey = "Freezek";

    private void Start()
    {
        LoadBalance();
        UpdateAllTextsMethod();
    }

    public void LoadBalance()
    {
        Coins = PlayerPrefs.GetInt(CoinsKey, Coins);
        Score = PlayerPrefs.GetInt(ScoreKey, Score);
        X2 = PlayerPrefs.GetInt(X2Key, X2);
        Timer = PlayerPrefs.GetInt(TimerKey, Timer);
        Shield = PlayerPrefs.GetInt(ShieldKey, Shield);
        Fire = PlayerPrefs.GetInt(FireKey, Fire);
        Magnet = PlayerPrefs.GetInt(MagnetKey, Magnet);
        Freeze = PlayerPrefs.GetInt(FreezeKey, Freeze);
    }
    private void UpdateAllTextsMethod()
    {
        UpdateAllTexts(CoinsText, Coins);
        UpdateAllTexts(ScoreText, Score);
        UpdateAllTexts(X2Text, X2);
        UpdateAllTexts(TimerText, Timer);
        UpdateAllTexts(ShieldText, Shield);
        UpdateAllTexts(FireText, Fire);
        UpdateAllTexts(MagnetText, Magnet);
        UpdateAllTexts(FreezeText, Freeze);
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt(CoinsKey, Coins);
        PlayerPrefs.Save();
    }
    public void SaveScore()
    {
        PlayerPrefs.SetInt(ScoreKey, Score);
        PlayerPrefs.Save();
    }

    public void SaveX2()
    {
        PlayerPrefs.SetInt(X2Key, X2);
        PlayerPrefs.Save();
    }

    public void SaveTimer()
    {
        PlayerPrefs.SetInt(TimerKey, Timer);
        PlayerPrefs.Save();
    }

    public void SaveShield()
    {
        PlayerPrefs.SetInt(ShieldKey, Shield);
        PlayerPrefs.Save();
    }

    public void SaveFire()
    {
        PlayerPrefs.SetInt(FireKey, Fire);
        PlayerPrefs.Save();
    }

    public void SaveMagnet()
    {
        PlayerPrefs.SetInt(MagnetKey, Magnet);
        PlayerPrefs.Save();
    }

    public void SaveFreeze()
    {
        PlayerPrefs.SetInt(FreezeKey, Freeze);
        PlayerPrefs.Save();
    }

    public void BuyPowers(string tag)
    {
        if (tag == "BuyX2" && Coins >= 1000)
        {
            Coins -= 1000;
            SaveCoins();
            UpdateAllTexts(CoinsText, Coins);
            X2++;
            SaveX2();
            UpdateAllTexts(X2Text, X2);
        }
        else if (tag == "Timer" && Coins >= 1000)
        {
            Coins -= 1000;
            SaveCoins();
            UpdateAllTexts(CoinsText, Coins);
            Timer++;
            SaveTimer();
            UpdateAllTexts(TimerText, Timer);
        }
        else if (tag == "Shield" && Coins >= 1000)
        {
            Coins -= 1000;
            SaveCoins();
            UpdateAllTexts(CoinsText, Coins);
            Shield++;
            SaveShield();
            UpdateAllTexts(ShieldText, Shield);
        }
        else if (tag == "Fire" && Coins >= 1000)
        {
            Coins -= 1000;
            SaveCoins();
            UpdateAllTexts(CoinsText, Coins);
            Fire++;
            SaveFire();
            UpdateAllTexts(FireText, Fire);
        }
        else if (tag == "Magnet" && Coins >= 1000)
        {
            Coins -= 1000;
            SaveCoins();
            UpdateAllTexts(CoinsText, Coins);
            Magnet++;
            SaveMagnet();
            UpdateAllTexts(MagnetText, Magnet);
        }
        else if (tag == "Freeze" && Coins >= 1000)
        {
            Coins -= 1000;
            SaveCoins();
            UpdateAllTexts(CoinsText, Coins);
            Freeze++;
            SaveFreeze();
            UpdateAllTexts(FreezeText, Freeze);
        }

    }

    public void SaveCoinsFromScore()
    {
        if (Score > 0)
        {
            Coins++;
            Score--;
            UpdateAllTexts(CoinsText, Coins);
            UpdateAllTexts(ScoreText, Score);
        }
    }
   public void UpdateAllTexts(Text[] texts, int value)
    {
        foreach (Text t in texts)
        {
            t.text = value.ToString();
        }
    }
}
