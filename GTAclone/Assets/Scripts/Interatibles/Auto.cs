using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto : Interactable
{
    public Transform seat;
    public Transform ExitPoint;
    public Transform Driver;
    public GameObject CamPivot;
    public bool IsDriven=false;
    // Start is called before the first frame update
    void Start()
    {
        
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
           
        }
    }
}
