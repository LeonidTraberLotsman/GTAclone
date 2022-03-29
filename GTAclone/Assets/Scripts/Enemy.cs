using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Head;
    public Transform player;
    public manager manager1;
    public Corner corner;
    NavMeshAgent agent;
    float DieDist=0;
    int a=2;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(ReachCover());
        }

    }
    IEnumerator MeleeRage(){
        LeaveCorner();
        if(a>0)
        {
            agent.destination=player.position;
            if(Vector3.Distance(player.position,transform.position)<1)
            {
    
                player.gameObject.GetComponent<PlayerBodyMove>().GetDamage(5f);
            }        
        }
        yield return null;   
    }
    
    public void Die()
    {
        LeaveCorner();
        agent.enabled=false;
        Head.GetComponent<Rigidbody>().isKinematic=false;
        GetComponent<Rigidbody>().isKinematic=false;
        Destroy(this);

    }
    void LeaveCorner(){
        if(corner!=null)corner.hidden=null;
        corner=null;
    }
    IEnumerator ReachCover(){
        LeaveCorner();
        corner = manager1.Nearest(transform.position); 
        corner.hidden=this;
        yield return Reach(corner.transform.position);

    }
    IEnumerator Reach(Vector3 point){

        agent.destination=point;
        while (Vector3.Distance(point,transform.position)>1){
            yield return null;
        }

    }
    public void damage()
    {
        a=a-1;
        if(a<1)
        {
            Die();
        }
        
        


    }
}

