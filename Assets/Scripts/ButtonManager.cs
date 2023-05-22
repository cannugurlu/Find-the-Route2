using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    GameObject car;
    Vector3 carPos;
    Quaternion carRot;
    GameObject car2;
    Vector3 carPos2;
    Quaternion carRot2;
    GameObject bul;
    Vector3 bulPos;
    Quaternion bulRot;
    GameObject stone;
    Vector3 stonePos;
    Quaternion stoneRot;
    public int carNumber;
    public Text leveltext;
    

    int carNum;

    private void Awake()
    {
        car = GameObject.Find("car");
        if (car)
        {
            carPos = car.transform.position;
            carRot = car.transform.rotation;
        }
        car2 = GameObject.Find("car2");
        if ( car2)
        {
            carPos2 = car2.transform.position;
            carRot2 = car2.transform.rotation;
        }
        bul = GameObject.Find("buldozer");
        if (bul)
        {
            bulPos = bul.transform.position;
            bulRot = bul.transform.rotation;
            stone = GameObject.FindGameObjectWithTag("stone");
            stonePos = stone.transform.position;
            stoneRot = stone.transform.rotation;

        }
        leveltext.text = "Level " + SceneManager.GetActiveScene().buildIndex.ToString();
        
    }

    public void Restart()
    {
        if (car && !car.GetComponent<moveController2>().win)
        {
            car.transform.position = carPos;
            car.transform.rotation = carRot;
            car.GetComponent<moveController2>().isTrigger = false;
            car.GetComponent<moveController2>().isMove = false;
            car.GetComponent<moveController2>().isClickable = true;
        }
        if (car2 && !car2.GetComponent<moveController2>().win)
        {
            car2.transform.position = carPos2;
            car2.transform.rotation = carRot2;
            car2.GetComponent<moveController2>().isTrigger = false;
            car2.GetComponent<moveController2>().isMove = false;
            car2.GetComponent<moveController2>().isClickable = true;
        }
        if(bul && !bul.GetComponent<Buldozer>().win)
        {
            bul.transform.position = bulPos;
            bul.transform.rotation = bulRot;
            bul.GetComponent<Buldozer>().isTrigger = false;
            bul.GetComponent<Buldozer>().isMove = false;
            bul.GetComponent<Buldozer>().isClickable = true;
            if(stone.transform.parent!= null)
            {
                stone.transform.parent = null;
                stone.transform.position = stonePos;
                stone.transform.rotation = stoneRot;
                stone.GetComponent<Collider>().enabled = true;
            }

        }
        GameObject.Find("brokenroad").GetComponent<BrokenRoad>().broken = false;

    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }


}
