using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float spd = 10;
    [SerializeField] float hspd = 5;
    
    public Rigidbody rb;
    public int gamestate=1;
    public int countdown=180;
    public int maxSpeed =5;
    public int jumpheight=5;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity=new Vector3(0,0,10);
    }

    // Update is called once per frame
    void Update()
    {
        if(gamestate==1&&rb.position.y<-1)
        {gamestate=0;countdown=180;}

        float x = Input.GetAxis("Horizontal");
        //transform.Translate(x * hspd * Time.deltaTime, 0, spd * Time.deltaTime); // Move horizontally
        if(gamestate==1)
        rb.AddForce(0,0,hspd);
        if((rb.velocity.x>=maxSpeed&&x<0)||(rb.velocity.x<=-maxSpeed&&x>0)||(rb.velocity.x<maxSpeed&&rb.velocity.x>-maxSpeed))
        {rb.velocity=new Vector3(x*spd+rb.velocity.x, rb.velocity.y,rb.velocity.z) ;}
        
        
        if(gamestate==0&&countdown<0)//if game is over and timer is finished restart
        {SceneManager.LoadScene(0);}
        countdown--;
        
            if(Input.GetKeyDown("r"))//restarts tge level
            {
                SceneManager.LoadScene(0);
            }
        
            if(Input.GetKeyDown(KeyCode.Space))//controlls jumping
            {
                rb.velocity=new Vector3(rb.velocity.x,jumpheight,rb.velocity.z);
            }
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Block")
        {gamestate=0;countdown=180;}

    }
}
