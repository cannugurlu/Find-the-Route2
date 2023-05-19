using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveController2 : MonoBehaviour
{
    public float velocity=100.0f;
    [SerializeField] float yolYRot, carYRot;
    bool isTrigger=false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        carYRot = transform.rotation.eulerAngles.y;
        print(isTrigger);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "yol")
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = velocity * transform.forward * Time.deltaTime;
            isTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
            this.gameObject.GetComponent<Rigidbody>().velocity = 0.0f * transform.forward * Time.deltaTime;
            isTrigger = false;
            Invoke("triggerController", 0.0005f);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "turn")
        {
                Destroy(other.gameObject);
                yolYRot = other.transform.rotation.eulerAngles.y;

                if ((yolYRot + carYRot) % 180 == 0)
                {
                print("saða dönülecek");
                gameObject.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90.0f, transform.rotation.eulerAngles.z);
                }
                else
                {
                print("sola dönülecek");
                gameObject.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 90.0f, transform.rotation.eulerAngles.z);

            }
        }
        if (other.gameObject.tag == "yol")
        {
            isTrigger = true;
        }
    }

    void triggerController()
    {
        if (!isTrigger)
        {
            print("kaybettin");
            Time.timeScale = 0.0f;
        }
    }
}
