using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    int[] rotations = { 270, 180, 90, 0 };
    GameObject[] cars;

    void Start()
    {
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new UnityEngine.Vector3(0, rotations[rand], 0);
        cars = GameObject.FindGameObjectsWithTag("Car");
    }

    private void OnMouseDown()
    {
        int a = 0;
        for(int i = 0; i<cars.Length; i++)
        {
            if (cars[i].GetComponent<Rigidbody>().velocity == UnityEngine.Vector3.zero)
            {
                a++;
            }
        }
        if(a == cars.Length && GameObject.Find("GameManager").GetComponent<ButtonManager>().carNumber!=0)
        {
            transform.Rotate(new UnityEngine.Vector3(0, 90, 0));

        }


    }
}
