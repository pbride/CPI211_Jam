using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset = new Vector3(0 , 0 ,-20);
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position=target.position+offset;
    }
}
