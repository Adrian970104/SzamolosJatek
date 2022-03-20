using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class InGameScButtonController : MonoBehaviour
{
    public GameManager gameManager;
    public SelectionTbController stbc;
    public SelectionTbController selectionTbController;
    
    public void OnClick100()
    {
        gameManager.selectedMaxValue = 100;
        stbc.SetValue(100);
    }

    public void OnClick1000()
    {
        gameManager.selectedMaxValue = 1000;
        stbc.SetValue(1000);
    }

    public void OnClick10000()
    {
        gameManager.selectedMaxValue = 10000;
        stbc.SetValue(10000);
    }

    public void OnClickPlus()
    {
        gameManager.selectedOperation = Operation.Plus;
        stbc.SetOperation(Operation.Plus);
    }
    
    public void OnClickMinus()
    {
        gameManager.selectedOperation = Operation.Minus;
        stbc.SetOperation(Operation.Minus);
    }
    
    public void OnClickDiv()
    {
        gameManager.selectedOperation = Operation.Div;
        stbc.SetOperation(Operation.Div);
    }
    
    public void OnClickMult()
    {
        gameManager.selectedOperation = Operation.Mult;
        stbc.SetOperation(Operation.Mult);
    }

    public void OnClickStart()
    {
        if (selectionTbController.IsSomethingMissing())
        {
            return;
        }
        gameManager.GenerateExercise();
        gameManager.ActivateGamePanel();
    }

    public void OnClickAnswer()
    {
        if (gameManager.ReadAnswer() is null)
        {
            return;
        }
        gameManager.CheckAnswer();
        gameManager.GenerateExercise();
    }

    public void OnClickFinish()
    {
        gameManager.ActivateSummaryPanel();
    }

    public void OnClickRestart()
    {
        gameManager.ActivateSelectionPanel();
    }
    
    public void OnClickExit()
    {
        Application.Quit();
    }
}
