using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    int[] rotations = { 270, 180, 90, 0 };
    public bool isCorrect = false;
    public int[] correctRot;
    public int posRot;
    GameManager gameManager;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        posRot = correctRot.Length;
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, rotations[rand], 0);

        if (posRot > 1)
        {
            if (transform.eulerAngles.y == correctRot[0] || transform.eulerAngles.y == correctRot[1])
            {
                isCorrect = true;
            }
        }
        else
        {
            if(transform.eulerAngles.y == correctRot[0])
            {
                isCorrect = true;
            }
        }
        if (isCorrect)
        {
            gameManager.Move(isCorrect);
        }
        


    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 90, 0));
        int k = 0;

        if (posRot > 1)
        {
            if (transform.eulerAngles.y == correctRot[0] || transform.eulerAngles.y == correctRot[1])
            {
                k = 1;
                isCorrect = true;
            }
            else if(isCorrect)
            {
                k = 1;
                isCorrect = false;

            }
        }
        else
        {
            if (transform.eulerAngles.y == correctRot[0])
            {
                k = 1;
                isCorrect = true;
            }
            else if(isCorrect)
            {
                k = 1;
                isCorrect = false;
            }
        }

        if (k == 1)
        {
            gameManager.Move(isCorrect);
        }  
        

  
    }
}
