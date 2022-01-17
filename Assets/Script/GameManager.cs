using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string human, ai;
    public string[] board = new string[9];

    public int moveIndex;
    public bool isFull=false;
    public bool isEnd = false;
    public GameObject[] grid = new GameObject [9];

    public Text result;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        //DontDestroyOnLoad(gameObject);
    }

    public void LoadBoard()
    {
        for(int i=0; i<9; i++)
        {
            board[i] = grid[i].gameObject.GetComponentInChildren<Text>().text;
        }
    }

    public void EnableGrid()
    {
        for (int i = 0; i < 9; i++)
        {
            if (grid[i].gameObject.GetComponentInChildren<Text>().text == "")
            {
                grid[i].gameObject.GetComponent<Button>().interactable = true;
            }
        }
    }
    public void UnenableGrid()
    {
        for (int i = 0; i < 9; i++)
        {
            grid[i].gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public int CheckWinner()
    {

        //Horizontal
        for(int i=0; i<=6; i += 3)
        {
            if (board[i] != board[i + 1]) continue;
            if (board[i] != board[i + 2]) continue;
            if (board[i] == ai) return 1;
            else if (board[i] == human) return -1;
        }

        //Vertical
        for (int i = 0; i <= 2; i ++)
        {
            if (board[i] != board[i + 3]) continue;
            if (board[i] != board[i + 6]) continue;
            if (board[i] == ai) return 1;
            else if (board[i] == human) return -1;
        }

        //Diagonal
        if (board[0] == board[4] && board[0] == board[8])
        {
            if (board[0] == human) return -1;
            else if (board[0] == ai) return 1;
        }

        if (board[2] == board[4] && board[2] == board[6])
        {
            if (board[2] == human) return -1;
            else if (board[2] == ai) return 1;
        }

        //Check if there is free space, if no then it is Tie
        for (int i = 0; i < 9; i++)
        {
            if (board[i] == "") break;
            if (i == 8) isFull = true;
        }
        if (isFull) return 0;

        else return 4;
    }

    public void humanTurn() {
        EnableGrid();
    }

    /*public void AITurn()
    {
        Debug.Log("ai");
        int i;
        do
        {
            i = Random.Range(0, 8);
            if(grid[i].gameObject.GetComponentInChildren<Text>().text == "")
            {
                grid[i].gameObject.GetComponentInChildren<Text>().text = ai;
                break;
            }
        } while (grid[i].gameObject.GetComponentInChildren<Text>().text != "");
        LoadBoard();

        if (CheckWinner() == -1)
        {
            result.text = "You win";
        }
        else if (CheckWinner() == 1)
        {
            result.text = "Noob";
        }
        else if (CheckWinner() == 0)
        {
            result.text = "Tie";
        }
        else if(CheckWinner() == 4)
        {
            humanTurn();
        }
    }*/

    public void AITurn()
    {
        int bestScore = -1, score;
        for (int i = 0; i < 9; i++)
        {
            if (board[i] == "")
            {
                board[i] = ai;
                score = Minimax(board, false, -1000, 1000);
                board[i] = "";
                if (bestScore < score)
                {
                    bestScore = score;
                    moveIndex = i;
                }
                Debug.Log("ok");
            }
        }
        grid[moveIndex].GetComponentInChildren<Text>().text = ai;
        board[moveIndex] = ai;
        humanTurn();
    }
    
    public int Minimax(string[] b, bool isMaximizing, int alpha, int beta)
    {
        int score;
        if (CheckWinner() != 4) return CheckWinner() * CheckSpaceLeft(b);//AI win return 1, lose return -1, tie return 0, 4 is nothing happen no result, the shorter the loop is, the higher it's score

        //AI turn
        if (isMaximizing == true)
        {
            int bestScore = -1000;
            for(int i=0; i<9; i++)
            {
                if (b[i] == "") b[i] = ai;
                score = Minimax(b, false, -1000, 1000);
                b[i] = "";
                bestScore = Mathf.Max(bestScore, score);
                if (alpha < score) alpha = score;
                if (beta < alpha) break;
            }
            return bestScore;
        }
        //Human turn
        else
        {
            int bestScore = 1000;
            for (int i = 0; i < 9; i++)
            {
                if (b[i] == "") b[i] = human;
                score = Minimax(b, true, -1000, 1000);
                b[i] = "";
                bestScore = Mathf.Min(bestScore, score);
                if (beta > score) beta = score;
                if (alpha > beta) break;
            }
            return beta;
        }

    }

    public int CheckSpaceLeft(string[] b)
    {
        int spaceLeft=0;
        for(int i=0; i<9; i++)
        {
            if (b[i] == "") spaceLeft++;
        }
        return spaceLeft + 1;
    }

    public void Rematch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}