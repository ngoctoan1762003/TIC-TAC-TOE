using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Write : MonoBehaviour
{
    public Text gridText;
    public void WriteText()
    {
        gridText.text = GameManager.instance.human;
        GameManager.instance.UnenableGrid();
        GameManager.instance.LoadBoard();
        if (GameManager.instance.CheckWinner() == 1)
        {
            GameManager.instance.result.text = "CON GÀ";
        }
        else if (GameManager.instance.CheckWinner() == -1)
        {
            GameManager.instance.result.text = "You win";
        }
        else if (GameManager.instance.CheckWinner() == 0)
        {
            GameManager.instance.result.text = "Tie";
            Debug.Log("ok");
        }
        else
        {
            GameManager.instance.AITurn();
        }
    }
}
