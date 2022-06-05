using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogicChina : MonoBehaviour
{
  
    public bool xTurn;
    public Text Chinawins;
    public Text Israelwins;

    [SerializeField] private int[] gameBoard = new int[9];
    public GameObject[] xArr;
    public GameObject[] oArr;
    bool gameEnded;
    public int Score7;
    public int Score8;
    public Text ChinaScoreText;
    public Text IsraelScoreText;
    public Text Tie;
    public int Turncount = 0;
    public GameObject[] RowLines;
    public GameObject[] StraightLines;
    public int Straight;
    public int SlantLines;
    public GameObject[] Diagonal;





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
                    IIsraelAddScore();
                    gameBoard[index] = 0;


                }
                else
                {
                    //xwins
                    Chinawins.text = "CHINA WON!";
                    AddChinaScore();
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
                Chinawins.text = "";
            }

            
    }
    void AddChinaScore()
    {
        Score7++;
        ChinaScoreText.text = Score7.ToString();
    }
    void IIsraelAddScore()
    {
        Score8++;
        IsraelScoreText.text = Score8.ToString();
    }
}
