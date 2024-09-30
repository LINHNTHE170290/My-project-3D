using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//1. Hien thi thoi giano nguoi choi hoan thanh tro choi
//2. Hien thi thong bao khi nguoi choi hoan thanh tro choi
public class GameoverUIManager : MonoBehaviour
{
    //public Text timeText;
    public GameObject gameoverPanel;

    // Method to set the time text
    // Method to set the time text
    //public void SetTimeText(string text)
    //{
    //if (timeText != null)
    //{
    //timeText.text = text; 
    //}
    //}

    public void ShowGameoverPanel(bool isShow)
    {
        if (gameoverPanel != null)
        {
            gameoverPanel.SetActive(isShow); // Set the active state of the gameoverPanel
        }
    }
}
