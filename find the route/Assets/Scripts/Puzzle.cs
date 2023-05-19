using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    int[] rotations = { 270, 180, 90, 0 };
    bool isCorrect = false;
    public int correctRot;
    public int posRot;
    GameManager gameManager;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new UnityEngine.Vector3(0, rotations[rand], 0);

        if (posRot > 1)
        {
            if (Mathf.RoundToInt(transform.eulerAngles.y) == correctRot || (correctRot - Mathf.RoundToInt(transform.eulerAngles.y) == 180))
            {
                isCorrect = true;
            }

        }
        else
        {
            if (Mathf.RoundToInt(transform.eulerAngles.y) == correctRot)
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
        transform.Rotate(new UnityEngine.Vector3(0, 90, 0));

        transform.eulerAngles = new UnityEngine.Vector3(transform.eulerAngles.x, Mathf.RoundToInt(transform.eulerAngles.y), transform.eulerAngles.z);

        if (posRot > 1)
        {

            if (transform.eulerAngles.y == correctRot || (correctRot - transform.eulerAngles.y == 180))
            {
                isCorrect = true;
                gameManager.Move(isCorrect);
            }

            else if (isCorrect)
            {
                isCorrect = false;
                gameManager.Move(isCorrect);

            }

        }

        else
        {

            if (correctRot == transform.eulerAngles.y)
            {
                isCorrect = true;
                gameManager.Move(isCorrect);
            }


            else if (isCorrect)
            {
                isCorrect = false;
                gameManager.Move(isCorrect);
            }

        }


    }
}
