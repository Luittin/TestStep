using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    UIMenu uiMenu = UIMenu.MainMenu;

    [Range(0.0f, 2.0f), SerializeField]
    float stepAlfa = 1.5f;

    [SerializeField]
    List<GameObject> listMenu = null;

    public void ExitInMainMenu(Action menu)
    {
        listMenu[uiMenu.GetHashCode()].GetComponent<AlfaEffect>().StartAffect(stepAlfa * -1.0f,menu);
    }

    public void SetGameMenu()
    {
        listMenu[uiMenu.GetHashCode()].SetActive(false);
        uiMenu = UIMenu.GameMenu;
        listMenu[1].SetActive(true);
        listMenu[uiMenu.GetHashCode()].GetComponent<AlfaEffect>().StartAffect(stepAlfa);
    }

    public void SetEndGameMenu()
    {
        listMenu[uiMenu.GetHashCode()].SetActive(false);
        uiMenu = UIMenu.EndGameMenu;
        listMenu[2].SetActive(true);
        listMenu[uiMenu.GetHashCode()].GetComponent<AlfaEffect>().StartAffect(stepAlfa);
    }

    public void SetMainMenu()
    {
        listMenu[uiMenu.GetHashCode()].SetActive(false);
        uiMenu = UIMenu.MainMenu;
        listMenu[0].SetActive(true);
        listMenu[uiMenu.GetHashCode()].GetComponent<AlfaEffect>().StartAffect(stepAlfa);
    }
}

enum UIMenu
{
    MainMenu = 0,
    GameMenu = 1,
    EndGameMenu = 2
}
