using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public Transform player;
    public List<Corner> corners;
    public List<Enemy> enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public Corner Nearest(Vector3 enemyPoint){
        List<Corner> potentials = new List<Corner>();
        foreach(Corner that in corners){
            if(that.Check(player, enemyPoint)){
                potentials.Add(that);
            }
        }
        float minDist=10000;
        if(potentials.Count<1) {
            Corner One = null;
            
            foreach(Corner that in corners){
            float ThatDist =Vector3.Distance(that.transform.position,enemyPoint);
            if(ThatDist<minDist){
                minDist=ThatDist;
                One=that;
            }
        }
        return One;
        }
        Corner closeOne = potentials[0];
        
        foreach(Corner that in potentials){
            float ThatDist =Vector3.Distance(that.transform.position,enemyPoint);
            if(ThatDist<minDist){
                minDist=ThatDist;
                closeOne=that;
            }
        }
        return closeOne;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
