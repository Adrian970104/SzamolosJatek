using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class SelectionTbController : MonoBehaviour
{
    public TextMeshProUGUI selectedValue;
    public TextMeshProUGUI selectedOperation;

    public void SetValue(int value)
    {
        selectedValue.text = "Legnagyobb szám: " + value.ToString();
    }

    public void SetOperation(Operation operation)
    {
        selectedOperation.text = operation switch
        {
            Operation.Plus => "Művelet: +",
            Operation.Minus => "Művelet: -",
            Operation.Mult => "Művelet: *",
            Operation.Div => "Művelet: /",
            _ => selectedOperation.text
        };
    }

    public bool IsSomethingMissing()
    {
        return selectedValue.text.Equals("Legnagyobb szám:") || selectedOperation.text.Equals("Művelet:");
    }
}
