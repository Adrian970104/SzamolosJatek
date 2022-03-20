using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static int Minvalue = 0;
    public int selectedMaxValue;
    public Operation selectedOperation;
    
    public GameObject selectionPanel;
    public GameObject gamePanel;
    public GameObject summaryPanel;
    public ExAnsController exAnsController;
    public SummaryPanelController summaryPanelController;

    public int num1;
    public int num2;
    public int? actualAnswer;
    public int rightAnswer;

    public int answCount = 0;
    public int rightAnswCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        ActivateSelectionPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!gamePanel.activeSelf)
            {
                return;
            }
            if (ReadAnswer() is null)
            {
                return;
            }
            CheckAnswer();
            GenerateExercise();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ActivateSummaryPanel();
        }
    }
    
    public void ActivateSelectionPanel()
    {
        gamePanel.SetActive(false);
        summaryPanel.SetActive(false);
        selectionPanel.SetActive(true);
        ResetAnswerCount();
    }

    public void ActivateGamePanel()
    {
        selectionPanel.SetActive(false);
        summaryPanel.SetActive(false);
        gamePanel.SetActive(true);
        exAnsController.ClearAnswer();
    }
    
    public void ActivateSummaryPanel()
    {
        summaryPanelController.RefresPanel(answCount, rightAnswCount);
        
        selectionPanel.SetActive(false);
        gamePanel.SetActive(false);
        summaryPanel.SetActive(true);
    }

    public void ResetAnswerCount()
    {
        answCount = 0;
        rightAnswCount = 0;
    }

    private List<int> GetDivisors (int num)
    {
        var dividers = new List<int>();
        dividers.Add(1);
        var upperRange = Math.Floor(Math.Sqrt(num));
        for (var i = 2; i <= upperRange; i++)
        {
            if (num % i == 0)
            {
                dividers.Add(i);
                dividers.Add(num/i);
            }
        }
        return dividers;
    }

    public void GenerateExercise()
    {
        if(selectedMaxValue == 0)
            return;
        
        switch (selectedOperation)
        {
            case Operation.Plus:
                rightAnswer = Random.Range(Minvalue, selectedMaxValue);
                num1 = Random.Range(Minvalue, rightAnswer);
                num2 = rightAnswer - num1;
                break;
            case Operation.Minus:
                rightAnswer = Random.Range(Minvalue, selectedMaxValue);
                num1 = Random.Range(rightAnswer, selectedMaxValue);
                num2 = num1 - rightAnswer;
                break;
            case Operation.Mult:
                var randRange = (int)Math.Floor(Math.Sqrt(selectedMaxValue));
                num1 = Random.Range(Minvalue, randRange);
                num2 = Random.Range(Minvalue, randRange);
                rightAnswer = num1 * num2;
                break;
            case Operation.Div:
                var divMin = Minvalue > 0 ? Minvalue : 1;
                num1 = Random.Range(divMin, selectedMaxValue);
                var divisors = GetDivisors(num1);
                num2 = divisors[Random.Range(0, divisors.Count - 1)];
                rightAnswer = num1 / num2;
                break;
            default:
                Debug.Log("Cannot find operation to generate exercise");
                break;
        }
        exAnsController.RefreshExercise(num1, num2, selectedOperation);
    }

    public int? ReadAnswer()
    {
        actualAnswer = exAnsController.GETAnswer();
        exAnsController.ClearAnswer();

        return actualAnswer;
    }

    public void CheckAnswer()
    {
        var isRight = actualAnswer == rightAnswer;
        answCount++;
        if (isRight)
        {
            rightAnswCount++;
        }
        Debug.Log($"Answer is: {isRight}");
    }
    
}
