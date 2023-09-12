using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public CamShake cameraShake;
    public UiManager UIManagerUI;
    public Sound SesScript;

    public GameObject[] FractureItems;
    public Transform VectorForward;
    public Transform VectorBack;

    public GameObject cam;
    public Rigidbody rb;
    private Touch touch;

    [Range(20, 40)]
    public int SpeedModifier;
    public int ForwardSpeed;

    public bool SpeedBollForward = false;
    public bool FirstTouchControl = false;

    private int SoundLimitCount;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        if (Veriables.FirstTouch == 1 && SpeedBollForward == false)
        {
            transform.position += new Vector3(0,0, ForwardSpeed * Time.deltaTime);
           // cam.transform.position += new Vector3(0, 0, ForwardSpeed * Time.deltaTime);
            VectorForward.transform.position += new Vector3(0, 0, ForwardSpeed * Time.deltaTime);
            VectorBack.transform.position += new Vector3(0, 0, ForwardSpeed * Time.deltaTime);
        }


        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) //Canvas elemanlari haric sadece bos ekrana basinca oyun baslayacak.
                {
                    if (FirstTouchControl == false)
                    {
                        Veriables.FirstTouch = 1;
                        UIManagerUI.FirstTouchDissaper();
                        FirstTouchControl = true;
                    }
                    
                }
            }

            else if (touch.phase == TouchPhase.Moved)
            {
               

                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) //Canvas elemanlari haric sadece bos ekrana basinca oyun baslayacak.
                {
                    rb.velocity = new Vector3(touch.deltaPosition.x * SpeedModifier * Time.deltaTime,
                                         transform.position.y,
                                         touch.deltaPosition.y * SpeedModifier * Time.deltaTime);

                    if (FirstTouchControl == false)
                    {
                        Veriables.FirstTouch = 1;
                        UIManagerUI.FirstTouchDissaper();
                        FirstTouchControl = true;
                    }

                }



            }
            else if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }
            //Transform
            //Velocity
            //AddForce
        }
    }

    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Obstacles")) 
        {
            cameraShake.CamShakeCall();
            UIManagerUI.StartCoroutine("WhiteEfect");
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            SesScript.BlowSound();


            if (PlayerPrefs.GetInt("Vibration") == 1 )  
            {
                Vibration.Vibrate(50);
            }
            else if (PlayerPrefs.GetInt("Vibration") == 2)
            {
                Debug.Log("No Vibration");
            }


            foreach (GameObject item in FractureItems)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
            StartCoroutine(TimeScaleControl());
        }

        if (hit.gameObject.CompareTag("Untagged"))
        {
            SoundLimitCount++;
        }
        if (hit.gameObject.CompareTag("Untagged") && SoundLimitCount % 5 == 0)
        {
            SesScript.ObjectHitSound();

        }
    }

    public IEnumerator TimeScaleControl()
    {
        SpeedBollForward = true;
        yield return new WaitForSeconds(0.4f);
        Time.timeScale = 0.4f;
        yield return new WaitForSeconds(0.6f);
        UIManagerUI.RestartButtonActive();
        rb.velocity = Vector3.zero;

    }

}
