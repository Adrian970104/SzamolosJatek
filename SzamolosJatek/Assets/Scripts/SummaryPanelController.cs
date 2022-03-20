using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class SummaryPanelController:MonoBehaviour
{
    public TextMeshProUGUI summaryText;
    public void RefresPanel(int answNum, int rightAnswNum)
    {
        
        float rate = answNum == 0 ? 0 : ((float)rightAnswNum / answNum) * 100;
        summaryText.text = @$"Összes válasz: {answNum}{Environment.NewLine} Helyes válaszok száma: {rightAnswNum}{Environment.NewLine} Helyes válaszok aránya: {rate}%";
    }
}