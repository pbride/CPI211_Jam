using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float spd = 10;
    [SerializeField] float hspd = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Translate(x * hspd * Time.deltaTime, 0, spd * Time.deltaTime); // Move horizontally
        if(Time.timeScale == 0)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0); // Get back to the first scene
                Time.timeScale = 1;
                return;
            }
        }
    }
}
