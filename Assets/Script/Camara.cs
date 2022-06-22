using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject zorro;
    private Vector3 v_pos;
    // Start is called before the first frame update
    void Start()
    {
        v_pos =  transform.position - zorro.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(zorro.transform.position.x + v_pos.x, 0f, transform.position.z);        
        if(transform.position.x < 0){
            transform.position = new Vector3(0f, 0f, transform.position.z);        
        }
    }
}
