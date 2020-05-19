using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject tower = null;

    [SerializeField]
    UIController uiController = null;

    [SerializeField]
    TapPlayer startGame = null, restartGame = null,TapToStopBlock = null;

    [SerializeField]
    GameObject plane = null;
    Material planeMaterial = null;

    [SerializeField]
    GameStats gameStats = null;
    int result = 0;

    [SerializeField]
    Text textResult = null,coins = null,bestResult = null;

    GameObject towerInPlay = null;

    // Start is called before the first frame update
    private void Awake()
    {
        SaveOrLoad.Load(gameStats);
        coins.text = gameStats.GetCoins().ToString();
        bestResult.text = "Best Result: " + gameStats.GetBestResult().ToString();
        planeMaterial = plane.GetComponent<MeshRenderer>().material;
    }

    void Start()
    {
        CreateNewTower();
        startGame.action = StartGame;
        restartGame.action = RestartGame;
    }

    public void AddResult()
    {
        result += 1;
        textResult.text = result.ToString();
        if (result % 10 == 0)
        {
            gameStats.ChangeCoins(1);
            coins.text = gameStats.GetCoins().ToString();
        }
    }

    void CreateNewTower()
    {
        textResult.text = "";
        result = 0;
        if (towerInPlay != null)
            Destroy(towerInPlay);
        towerInPlay = Instantiate(tower, Vector3.zero, Quaternion.identity);
        towerInPlay.GetComponent<Tower>().EndGame = EndGame;
        towerInPlay.GetComponent<Tower>().AddResult = AddResult;
        NewColorPlane();
    }

    void NewColorPlane()
    {
        float H = Random.Range(0.0f, 1.0f);
        planeMaterial.SetColor("Color_AADC1B88", Color.HSVToRGB(H, 1.0f, 1.0f));
        H = Random.Range(0.0f, 1.0f);
        planeMaterial.SetColor("Color_1FC3BB7A", Color.HSVToRGB(H, 1.0f, 1.0f));
    }

    public void StartGame()
    {
        Camera.main.GetComponent<MoveCamera>().RestartCamera();
        uiController.ExitInMainMenu(uiController.SetGameMenu);
        Destroy(towerInPlay);
        CreateNewTower();
        towerInPlay.GetComponent<Tower>().CreateNewBlock();
        TapToStopBlock.action = towerInPlay.GetComponent<Tower>().TapStopMoveBlock;        
    }

    public void EndGame()
    {
        bestResult.text = "Best Result: " + gameStats.SetBestResult(result);
        uiController.ExitInMainMenu(uiController.SetEndGameMenu);
    }

    public void RestartGame()
    {
        SaveOrLoad.Save(gameStats);
        uiController.ExitInMainMenu(uiController.SetMainMenu);    
    }
}
