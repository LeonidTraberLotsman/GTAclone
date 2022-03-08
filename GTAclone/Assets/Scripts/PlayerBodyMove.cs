using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBodyMove : MonoBehaviour
{
    public float speed=1;
    public Text GameOverText;
    public Text HPindicator;
    public GameObject Aim;  
    public GameObject RestartButton;  
    public float HP=100;
   
    
    Rigidbody body;
    public bool Alive = true;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
public void GetDamage(float damage){
    HP=HP-damage;
    if(HP<0){
        Die();
    }
    HPindicator.text=HP.ToString();

}
public void Die()
{
    Alive=false;
    GameOverText.gameObject.SetActive(true);
    Aim.SetActive(false);    
    RestartButton.SetActive(true);    
}
    // Update is called once per frame
    void Update()
    {
        if(Alive)
        {
        if (Input.GetKey(KeyCode.W))
        {
            
            //source.Play();
            body.AddForce(transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            body.AddForce(-transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(transform.right * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(-transform.right * speed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(transform.up * speed*75);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            body.AddForce(transform.forward * speed);
        }
        }
    }
}
