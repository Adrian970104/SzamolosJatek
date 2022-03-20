using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class ExAnsController : MonoBehaviour
{
    public TextMeshProUGUI exerciseText;
    //public TextMeshProUGUI answer;
    public TMP_InputField answer;

    private static char OperationChar(Operation operation)
    {
        var ret = operation switch
        {
            Operation.Plus => '+',
            Operation.Minus => '-',
            Operation.Mult => '*',
            Operation.Div => '/',
            _ => '?'
        };
        return ret;
    }

    public void RefreshExercise(int num1, int num2, Operation operation)
    {
        exerciseText.text = num1.ToString() + " " + OperationChar(operation) + " " + num2.ToString();
    }

    public void ClearAnswer()
    {
        answer.text = "";
        answer.ActivateInputField();
    }

    public int? GETAnswer()
    {
        if (int.TryParse(answer.text, out var num))
        {
            return num;
        }
        else
        {
            return null;
        }
    }
}
