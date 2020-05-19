using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveOrLoad
{
    public static void Save(GameStats gameStats)
    {
        string stats = gameStats.GetCoins() + "|" + gameStats.GetBestResult();
        PlayerPrefs.SetString("Save",stats);
    }

    public static void Load(GameStats gameStats)
    {
        if(PlayerPrefs.HasKey("Save"))
        {
            string[] data = PlayerPrefs.GetString("Save").Split('|');
            gameStats.SetBestResult(int.Parse(data[1]));
            gameStats.ChangeCoins(int.Parse(data[0]));
        }
    }
}
