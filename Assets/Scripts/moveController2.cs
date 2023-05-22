using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UIElements;

public class moveController2 : MonoBehaviour
{
    public float velocity=175.0f;
    [SerializeField] float yolYRot, carYRot;
    public bool isTrigger=false;
    public bool isMove=false;
    public bool isClickable = true;
    private string objName;
    public GameObject winPanel;
    public bool win = false;
    ButtonManager buttonManager;
    public ParticleSystem konfeti;
    // Start is called before the first frame update
    void Start()
    {
        buttonManager = GameObject.FindObjectOfType<ButtonManager>();
        konfeti.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = CastRay();

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("bas") && isClickable)
                {
                    objName = "car";

                    if (this.gameObject.name == objName)
                    {
                        print("heyyo");
                        isMove = true;
                        isClickable = false;
                    }
                }
                else if (hit.collider.CompareTag("bas2") && isClickable)
                {
                    objName = "car2";

                    if (this.gameObject.name == objName)
                    {
                        print("heyyo");
                        isMove = true;
                        isClickable = false;
                    }
                    
                }else if(gameObject.GetComponent<Rigidbody>().velocity != Vector3.zero) // hareket ederken baþka yere týklandýðýnda hareket etmeye devam etmesi için
                {
                    isMove = true;
                }
                else
                {
                    isMove = false;
                }
            }
      
        }
        carYRot = transform.rotation.eulerAngles.y;
        //print(isTrigger);
    }
    
    void OnTriggerStay(Collider other)
    {
        if(this.gameObject.name== objName && isMove)
        {
            if (other.gameObject.tag == "yol")
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = velocity * transform.forward * Time.deltaTime;
                isTrigger = true;
            }

            if (other.gameObject.tag == "start")
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = velocity * transform.forward * Time.deltaTime;
                isTrigger = true;
            }
            if (other.gameObject.tag == "finish")
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = velocity * transform.forward * Time.deltaTime;
                isTrigger = true;
            }
        }
        

    }
    void OnTriggerExit(Collider other)
    {
            this.gameObject.GetComponent<Rigidbody>().velocity = 0.0f * transform.forward * Time.deltaTime;
            isTrigger = false;
            Invoke("triggerController", 0.0005f);
        if (gameObject.name == "car")
        {
            if (other.gameObject.name == "finish")
            {
                buttonManager.carNumber--;
                win = true;
                if (buttonManager.carNumber == 0)
                {
                    konfeti.Play();
                    Invoke("WinPanel", 1.5f);
                }
            }
        }
        if (gameObject.name == "car2")
        {
            if (other.gameObject.name == "finish2")
            {
                buttonManager.carNumber--;
                win = true;
                if (buttonManager.carNumber == 0)
                {
                    konfeti.Play();
                    Invoke("WinPanel", 1.5f);
                }
            }
        }

    }
    
    void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.name == objName)
        {
            if (other.gameObject.tag == "yol")
            {
                isTrigger = true;
            }
        }
        if (other.gameObject.tag == "turn")
        {
                //Destroy(other.gameObject);
                yolYRot = other.transform.rotation.eulerAngles.y;

                if (Mathf.RoundToInt(yolYRot + carYRot) % 180 == 0)
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "stone" || collision.gameObject.tag == "obstacle")
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = 0.0f * transform.forward * Time.deltaTime;
            isTrigger = false;
            Invoke("triggerController", 0.0005f);
        }


    }

    void triggerController()
    {
        if (!isTrigger)
        {
            print("kaybettin");
        }
    }

    void WinPanel()
    {
        winPanel.SetActive(true);

    }


    RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}
