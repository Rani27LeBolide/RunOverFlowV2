using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SoloPlayerControllercanyon : MonoBehaviour
{
    public float speed;
    public float turnspeed;
    public float speedback;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private int count;
    public float TimeRespawn;
    public Vector3 initposition;
    float inertie = 0;
    float timelastinputright = 0;
    float timelastinputleft = 0;

    bool CheckPoint1;
    bool CheckPoint2;
    bool CheckPoint3;
    bool CheckPoint4;
    bool CheckPoint5;
    bool CheckPoint6;
    bool CheckPoint7;

    bool CheckPointarrivée;
    int counttours = 0;
    float jumpcooldown = 0;
    string lastkey = "";
    float todecrement = 0.5F;
    int jumphigh = 0;
    private AudioSource source;
    public AudioClip BonusSound;
    public Sprite Bonus1;
    public Sprite BonusNone;
    public AudioClip PickUpSound;
    int Timetoleftbonus = 0;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;


    }

    void FixedUpdate()
    {

        
            decrement();
            transform.Translate(Vector3.forward * Time.deltaTime * inertie);
            transform.Translate(Vector3.up * Time.deltaTime * jumphigh);
            if (Input.GetKey(KeyCode.Space))
            {
                if (jumpcooldown <= 0)
                {
                    jumpcooldown = 60;
                    jumphigh = 20;
                }

            }
            if (Timetoleftbonus > 0)
            {
                inertie = speed * 1.3F;
                if (Input.GetKey(KeyCode.Q))
                {
                    transform.Rotate(Vector3.up * Time.deltaTime * -(turnspeed + (inertie)));
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    transform.Rotate(Vector3.up * Time.deltaTime * (turnspeed + (inertie)));
                }
            }
            else
            {
                /*if (inertie > speed) {
                    todecrement = 10;
                }*/
                if (Input.GetKey(KeyCode.Q) & !(Input.GetKey(KeyCode.S)))
                {
                    if (timelastinputright > 0)
                    {
                        todecrement = 0.5F;
                        if (inertie < speed)
                        {
                            inertie += timelastinputright / 25;
                            if (lastkey == "q")
                            {
                                timelastinputright = 0;
                            }
                        }
                    }
                    else
                    {

                        transform.Rotate(Vector3.up * Time.deltaTime * -(turnspeed - (inertie * 2.5F)));
                        if (inertie < speed / 2)
                        {
                            todecrement = 0.1F;
                        }
                    }
                    timelastinputleft = 60;
                    lastkey = "q";
                }
                else if (Input.GetKey(KeyCode.S) & !(Input.GetKey(KeyCode.Q)))
                {
                    if (timelastinputleft > 0)
                    {
                        todecrement = 0.5F;
                        if (inertie < speed)
                        {
                            inertie += timelastinputleft / 25;
                            if (lastkey == "s")
                            {
                                timelastinputleft = 0;
                            }
                        }
                    }
                    else
                    {

                        transform.Rotate(Vector3.up * Time.deltaTime * (turnspeed - (inertie * 2.5F)));
                        if (inertie < speed / 2)
                        {
                            todecrement = 0.1F;
                        }
                    }
                    timelastinputright = 60;
                    lastkey = "s";
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(-Vector3.forward * Time.deltaTime * speedback);
                }
            }
        

    }

    void decrement()
    {
        if (inertie > 0)
        {
            inertie = inertie - todecrement;
        }
        if (timelastinputleft > 0)
        {
            timelastinputleft--;
        }
        if (timelastinputright > 0)
        {
            timelastinputright--;
        }
        if (jumpcooldown > 0)
        {
            jumpcooldown--;
        }
        if (jumphigh > 0)
        {
            jumphigh--;
        }
        if (Timetoleftbonus > 0)
        {
            Timetoleftbonus--;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            source.PlayOneShot(PickUpSound);
            count = count + 1;
        }
        if (other.gameObject.CompareTag("Bonus"))
        {
            other.gameObject.SetActive(false);
            source.PlayOneShot(BonusSound);
            Timetoleftbonus = 250;

        }
        if (other.gameObject.CompareTag("CheckPoint"))                      //CHECKPOINT ET GESTION TOURS DE PISTE
        {
            if ((other.name == "CP1") & !(CheckPoint1))
            {
                CheckPoint1 = true;
                Debug.Log("CP1 OK");
            }
            else if ((other.name == "CP1") & (CheckPoint1))
            {
                CheckPoint1 = false;
            }
            if ((other.name == "CP2") & (CheckPoint1) & !(CheckPoint2))
            {
                CheckPoint2 = true;
                Debug.Log("CP2 OK");
            }
            else if ((other.name == "CP2") & (CheckPoint2))
            {
                CheckPoint2 = false;
            }
            if ((other.name == "CP3") & (CheckPoint2) & !(CheckPoint3))
            {
                CheckPoint3 = true;
                Debug.Log("CP3 OK");
            }
            else if ((other.name == "CP3") & (CheckPoint3))
            {
                CheckPoint3 = false;
            }
            if ((other.name == "CP4") & (CheckPoint3) & !(CheckPoint4))
            {
                CheckPoint4 = true;
                Debug.Log("CP4 OK");
            }
            else if ((other.name == "CP4") & CheckPoint4)
            {
                CheckPoint4 = false;
            }

            if ((other.name == "CP5") & (CheckPoint4) & !(CheckPoint5))
            {
                CheckPoint5 = true;
                Debug.Log("CP5 OK");
            }
            else if ((other.name == "CP5") & CheckPoint5)
            {
                CheckPoint5 = false;
            }

            if ((other.name == "CP6") & (CheckPoint5) & !(CheckPoint6))
            {
                CheckPoint6 = true;
                Debug.Log("CP6 OK");
            }
            else if ((other.name == "CP6") & CheckPoint6)
            {
                CheckPoint6 = false;
            }

            if ((other.name == "CP7") & (CheckPoint6) & !(CheckPoint7))
            {
                CheckPoint7 = true;
                Debug.Log("CP7 OK");
            }
            else if ((other.name == "CP7") & CheckPoint7)
            {
                CheckPoint7 = false;
            }


            if ((other.name == "CPARRIVE") & (CheckPoint7))
            {
                CheckPoint1 = false;
                CheckPoint2 = false;
                CheckPoint3 = false;
                CheckPoint4 = false;
                CheckPoint5 = false;
                CheckPoint6 = false;
                CheckPoint7 = false;
                CheckPointarrivée = false;
                counttours++;
                Debug.Log(counttours);
            }
        }
        
        
            // Création d'une scéne pour gagnant du nombre n de tours
        

    }
    void TimeToSetReActive(GameObject objet){  // Fonction qui va faire respawn au bout de n seconde l'objet

    }

}
