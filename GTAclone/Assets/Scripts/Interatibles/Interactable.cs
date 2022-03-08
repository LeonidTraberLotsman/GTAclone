using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float IntDistance;
    public string naming="smt";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public virtual void Interact(PlayerMove playerMove){
        Debug.Log("interacted");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
