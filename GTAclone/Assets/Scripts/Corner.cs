using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corner : MonoBehaviour
{
    public GameObject FirePosition;
    public Enemy hidden;


    public bool Check(Transform PlayerPoint, Vector3 EnemyPoint){
        if(hidden!=null) return false;
        RaycastHit hit;
        Vector3 Direction = PlayerPoint.position-transform.position;
        if(Physics.Raycast(transform.position, Direction, out hit, 200)){
            if(hit.transform!=PlayerPoint){
                return true;
            }
        }
        return false;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
