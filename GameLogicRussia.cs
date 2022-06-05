using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogicRussia : MonoBehaviour
{
    public bool xTurn;
    public Text Russiawins;
    public Text Israelwins;

    [SerializeField] private int[] gameBoard = new int[9];
    public GameObject[] xArr;
    public GameObject[] oArr;
    bool gameEnded;
    public int Score3;
    public int Score4;
    public Text RussiaScoreText;
    public Text IIsraelScoreText;
    public Text Tie;
    public int Turncount = 0;
    public GameObject[] RowLines;
    public GameObject[] StraightLines;
    public GameObject[] Diagonal;



    // Update is called once per frame
    public void play(int index)
    {
        if (gameEnded == false)
        {
            if (gameBoard[index] == 0)
            {


                if (xTurn == true)
                {
                    xArr[index].SetActive(true);
                    xTurn = false;
                    gameBoard[index] = 1;
                    Turncount++;

                }
                else
                {
                    oArr[index].SetActive(true);
                    xTurn = true;
                    gameBoard[index] = 2;
                    Turncount++;
                }
            }
        }

        {
            if (CheckForWin())
            {
                if (xTurn)
                {
                    //o wins
                    Israelwins.text = "ISRAEL WON!";
                    IsraelAddScore();
                    gameBoard[index] = 0;
                }
                else
                {
                    //xwins
                    Russiawins.text = "RUSSIA WON!";
                    AddRussiaScore();
                    gameBoard[index] = 0;
                }
                gameEnded = true;

            }


        }
        if (gameEnded == false && Turncount >= 9)
        {


            Tie.text = "   ITS A TIE!";
            gameEnded = true;

        }
    }
    private bool CheckForWin()
    {



        for (int i = 0; i < gameBoard.Length; i++)
        {
            if (gameBoard[i] != 0)
            {

                if (i % 3 == 0)
                {
                    if (gameBoard[i] == gameBoard[i + 1] && gameBoard[i + 1] == gameBoard[i + 2])
                    {
                        int row = i / 3;
                        RowLines[row].SetActive(true);
                        return true;
                    }
                }
                if (i < 3)
                {
                    if (gameBoard[i] == gameBoard[i + 3] && gameBoard[i + 3] == gameBoard[i + 6])
                    {
                        if (i < 3)
                        {
                            StraightLines[i].SetActive(true);
                        }
                        return true;
                    }
                }
            }
        }

        if (gameBoard[0] == gameBoard[4] && gameBoard[4] == gameBoard[8])
        {
            if (gameBoard[0] != 0)
            {
                Diagonal[0].SetActive(true);
                return true;
            }
        }
        if (gameBoard[2] == gameBoard[4] && gameBoard[4] == gameBoard[6])
        {
            if (gameBoard[2] != 0)
            {
                
                    Diagonal[1].SetActive(true);
                    return true;
               
            }
        }
        return false;
    }




    public void RematchButton1()
    {
        for (int i = 0; i < gameBoard.Length; i++)
        {
            gameBoard[i] = 0;
            xArr[i].SetActive(false);
            oArr[i].SetActive(false);
            gameEnded = false;
            xTurn = false;
            Tie.text = "";
            Turncount = 0;
        }
        for (int i = 0; i < 3; i++)
        {
            RowLines[i].SetActive(false);
            StraightLines[i].SetActive(false);
            Diagonal[i].SetActive(false);
        }

        if (xTurn)
            {
                //o wins
                Israelwins.text = "";
            }
            else
            {
                //xwins
                Russiawins.text = "";
            }

            
    }

    void AddRussiaScore()
    {
        Score3++;
        RussiaScoreText.text = Score3.ToString();
    }
    void IsraelAddScore()
    {
        Score4++;
        IIsraelScoreText.text = Score4.ToString();
    }
}
