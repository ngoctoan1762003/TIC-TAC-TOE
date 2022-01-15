using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string human, ai;

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
        DontDestroyOnLoad(gameObject);
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

    public bool Compare(GameObject a, GameObject b, GameObject c)
    {
        if (a.gameObject.GetComponentInChildren<Text>().text == b.gameObject.GetComponentInChildren<Text>().text
            && a.gameObject.GetComponentInChildren<Text>().text == c.gameObject.GetComponentInChildren<Text>().text
            && b.gameObject.GetComponentInChildren<Text>().text == c.gameObject.GetComponentInChildren<Text>().text)
            return true;
        else return false;
    }

    public int CheckWinner()
    {

        //Horizontal
        if (Compare(grid[0], grid[1], grid[2]))
        {
            if (grid[0].gameObject.GetComponentInChildren<Text>().text == human) return 1;
            else if (grid[0].gameObject.GetComponentInChildren<Text>().text == ai) return -1;
        }

        if (Compare(grid[3], grid[4], grid[5]))
        {
            if (grid[3].gameObject.GetComponentInChildren<Text>().text == human) return 1;
            else if (grid[3].gameObject.GetComponentInChildren<Text>().text == ai) return -1;
        }

        if (Compare(grid[6], grid[7], grid[8]))
        {
            if (grid[6].gameObject.GetComponentInChildren<Text>().text == human) return 1;
            else if (grid[6].gameObject.GetComponentInChildren<Text>().text == ai) return -1;
        }

        //Vertical
        if (Compare(grid[0], grid[3], grid[6]))
        {
            if (grid[0].gameObject.GetComponentInChildren<Text>().text == human) return 1;
            else if (grid[0].gameObject.GetComponentInChildren<Text>().text == ai) return -1;
        }

        if (Compare(grid[1], grid[4], grid[7]))
        {
            if (grid[1].gameObject.GetComponentInChildren<Text>().text == human) return 1;
            else if (grid[1].gameObject.GetComponentInChildren<Text>().text == ai) return -1;
        }

        if (Compare(grid[2], grid[5], grid[8]))
        {
            if (grid[2].gameObject.GetComponentInChildren<Text>().text == human) return 1;
            else if (grid[2].gameObject.GetComponentInChildren<Text>().text == ai) return -1;
        }

        //Diagonal
        if (Compare(grid[0], grid[4], grid[8]))
        {
            if (grid[0].gameObject.GetComponentInChildren<Text>().text == human) return 1;
            else if (grid[0].gameObject.GetComponentInChildren<Text>().text == ai) return -1;
        }

        if (Compare(grid[2], grid[4], grid[6]))
        {
            if (grid[2].gameObject.GetComponentInChildren<Text>().text == human) return 1;
            else if (grid[2].gameObject.GetComponentInChildren<Text>().text == ai) return -1;
        }

        //Check if there is free space
        for (int i = 0; i < 9; i++)
        {
            if (grid[i].gameObject.GetComponentInChildren<Text>().text == "") break;
            if (i == 8) isFull = true;
        }
        if (isFull) return 0;

        else return 4;
    }

    public void humanTurn() {
        EnableGrid();
    }

    public void AITurn()
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

        if (CheckWinner() == 1)
        {
            result.text = "You win";
        }
        else if (CheckWinner() == -1)
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
    }

    public void Rematch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}