using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float spd;
    [SerializeField] float hspd;
    
    public Rigidbody rb;
    public int gamestate = 1;
    public int maxSpeed = 5;
    public int jumpheight = 5;
    private bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity=new Vector3(0,0,10);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        //transform.Translate(x * hspd * Time.deltaTime, 0, spd * Time.deltaTime); // Move horizontally
        // if(gamestate == 1)
        // {
        //     rb.AddForce(0, 0, hspd);
        // }

        if((rb.velocity.x >= maxSpeed && x<0) || (rb.velocity.x <= -maxSpeed && x>0) || (rb.velocity.x < maxSpeed && rb.velocity.x > -maxSpeed))
        {
            rb.velocity=new Vector3(x*spd+rb.velocity.x, rb.velocity.y, rb.velocity.z) ;
        }
        
        // if(gamestate==0&&countdown<0)//if game is over and timer is finished restart
        // {SceneManager.LoadScene(0);}
        // countdown--;
        
        if(Input.GetKeyDown("r"))//restarts the level
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
            return;
        }
        
        // if(transform.position.y == 1.5)
        // {
        //     canJump = true;
        // }

        if(Input.GetKeyDown(KeyCode.Space))//controls jumping
        {
            if(canJump)
            {
               rb.velocity = new Vector3(rb.velocity.x,jumpheight,rb.velocity.z);
               canJump = false;
            }
        }

        if((rb.velocity.z > 2) || (rb.velocity.z < 15))//The ball collides with obstacles and keeps moving
        {
            rb.AddForce(0,0,hspd);
        }
        
        if(rb.velocity.z >= 15)// Too fast
        {
            rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, 15);
        }

        if((rb.velocity.z <= 2) || (transform.position.y <= -5))//Game Lose
        {
            GameObject canvas = GameObject.Find("Canvas");
            canvas.transform.Find("PanelLose").gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        // if(transform.position.y <= -10)
        // {
        //     GameObject canvas = GameObject.Find("Canvas");
        //     canvas.transform.Find("PanelLose").gameObject.SetActive(true);
        //     Time.timeScale = 0;
        // }


        Debug.Log(rb.velocity.z);
        
    }

    void OnCollisionEnter()
    {
        canJump = true;
    }

    void OnCollisionExit()
    {
        canJump = false;
    }
}
