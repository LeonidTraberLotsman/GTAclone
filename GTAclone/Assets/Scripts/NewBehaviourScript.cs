using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Vector3 point1 = new Vector3(0, 1, 2);
    Vector3 point2 = new Vector3(3, 4, 15);
    public Vector3[] points;



    // Start is called before the first frame update             ab
    void Start()
    {
        StartCoroutine(Patrol());



       
        //CTRL +S Сохранить
       


    }
    public IEnumerator Patrol()
    {
        yield return null;
        while (true)
        {
            for (int i = 0; i < points.Length; i++)
            {

                yield return Move(transform.position, points[i]);
            }

            for (int i = points.Length - 1; i > -1; i--)
            {
                yield return Move(transform.position, points[i]);
            }
        }
       
    }
    public IEnumerator Move(Vector3 A,Vector3 B)
    { 
        yield return null;
        transform.position = A;
        Vector3 Delta = B - A;
        Vector3 V = Delta / 180;
        for (int i = 0; i < 180; i++)
        {
            yield return null;
            transform.position = A + V * i;
        }
    }














    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = transform.position + new Vector3(0, 0.01f, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = transform.position - new Vector3(0, 0.01f, 0);
        }

    }
}
