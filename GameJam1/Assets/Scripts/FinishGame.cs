using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        canvas.transform.Find("PanelWin").gameObject.SetActive(false);
        canvas.transform.Find("PanelLose").gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Sphere")
        {
            GameObject canvas = GameObject.Find("Canvas");
            canvas.transform.Find("PanelWin").gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
