using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto : Interactable
{
    public float speed;
    public Transform seat;
    public Transform ExitPoint;
    public Transform Driver;
    public GameObject CamPivot;
    public Transform forw;
    public bool IsDriven=false;
    float RotAngle=0;
    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body =GetComponent<Rigidbody>();
    }
    public override void Interact(PlayerMove playerMove){
        if(!IsDriven){
            Debug.Log("We entered the car");
            playerMove.playerBodyMove.SetFreedom(false);
            Driver =playerMove.playerBodyMove.transform;
            Driver.position=seat.position;
            Driver.parent=transform;
            Driver.gameObject.GetComponent<CapsuleCollider>().enabled=false;
            IsDriven=true;
            CamPivot.SetActive(true);
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        if(IsDriven){
             //Ruling car
            if(Input.GetKeyDown(KeyCode.E)){
                Driver.gameObject.GetComponent<CapsuleCollider>().enabled=true;
                IsDriven=false;
                Driver.position=ExitPoint.position;
                Driver.GetComponent<PlayerBodyMove>().SetFreedom(true);
                Driver=null;
                CamPivot.SetActive(false);
            }
            if(Input.GetKey(KeyCode.W)){
                body.AddForce(forw.forward*speed);
            }
            if(Input.GetKey(KeyCode.S)){
                body.AddForce(-forw.forward*speed);
            }
            if(Input.GetKey(KeyCode.D)){
                RotAngle=RotAngle+0.5f;    
            }
            if(Input.GetKey(KeyCode.A)){
                RotAngle=RotAngle-0.5f;    
            }
            RotAngle=Mathf.Clamp(RotAngle, -30f, 30f);
            forw.localRotation = Quaternion.Euler(0, RotAngle, 0);
           
        }
    }
}
