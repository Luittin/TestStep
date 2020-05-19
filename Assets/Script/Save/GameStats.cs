using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    int coins;

    int BestResult;

    public void ChangeCoins(int cange)
    {
        coins += cange;
    }

    public int GetCoins()
    {
        return coins;
    }

    public int SetBestResult(int result)
    {
        if (BestResult < result) BestResult = result;
        return BestResult;
    }

    public int GetBestResult()
    {
        return BestResult;
    }
}
