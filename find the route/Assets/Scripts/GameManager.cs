using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject puzzleHolder;
    public GameObject[] puzzlePieces;
    public int correctPos = 0;
    int totalPieces;


    void Start()
    {
        totalPieces = puzzleHolder.transform.childCount;
        puzzlePieces = new GameObject[totalPieces];

        for (int i = 0; i < totalPieces; i++)
        {
            puzzlePieces[i] = puzzleHolder.transform.GetChild(i).gameObject;
        }
    }

    public void Move(bool place)
    {
        if (place)
        {
            correctPos++;
        }
        else
        {
            correctPos--;
        }

        Debug.Log(correctPos);

        if (correctPos == totalPieces)
        {
            Debug.Log("win");
        }
    }


}
