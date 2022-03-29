using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner: MonoBehaviour
{
    public GameObject prefab;
    public Transform player;
    public manager manager1;
    public int x=8;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }


    public IEnumerator Spawn()
    {
        while(x>0)
        {
            x--;
            GameObject Clone = Instantiate(prefab);
            Clone.transform.position = transform.position;
            Enemy enem = Clone.GetComponent<Enemy>();
            enem.player = player;
            enem.manager1 = manager1;
            manager1.enemies.Add(enem);
            yield return new WaitForSeconds(1);
        }

    }


   
}
