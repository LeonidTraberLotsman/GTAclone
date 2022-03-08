using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Transform PlayerBody;
    public PlayerBodyMove playerBodyMove;
    float MouseSensivity = 10;
    float xRotation = 0;
    public AudioSource source;
    public AudioClip[] sounds;
    public int Ammo;
    public Text AmmoCount;
    public Text InterText;
    public bool freedom=true;

    // gg
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
        AmmoCount.text=Ammo.ToString();

    }
    
    // chto zdes proishodit
    void Update()
    {
        if(freedom){
        float mouseX = Input.GetAxis("Mouse X")*MouseSensivity; 
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensivity; 

        xRotation = xRotation - mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        PlayerBody.Rotate(Vector3.up * mouseX);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            
            Debug.Log(hit.transform.name);
            InterText.text=" ";
            if(hit.transform.gameObject.GetComponent<Interactable>()){
                Interactable One= hit.transform.gameObject.GetComponent<Interactable>();
                if(Vector3.Distance(hit.point, transform.position)< One.IntDistance){
                    InterText.text="press E to interact with "+One.naming;
                    if(Input.GetKeyDown(KeyCode.E)){
                        One.Interact(this);
                    }
                }
            }



            if ((Input.GetKeyDown(KeyCode.Mouse0))&&(Ammo>0))
            {
                Ammo=Ammo-1;
                AmmoCount.text=Ammo.ToString();
                source.clip=sounds[0];
                source.Play();
                if(hit.transform.gameObject.GetComponent<Enemy>()){
                    source.clip=sounds[1];
                    source.Play();
                    
                    hit.transform.gameObject.GetComponent<Enemy>().damage();
                }
            }
        }
        }

    }
}
