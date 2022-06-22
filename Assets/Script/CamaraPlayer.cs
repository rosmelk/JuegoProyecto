using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform camaraTrans;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = camaraTrans.position.x;
        var y = camaraTrans.position.y;
        transform.position = new Vector3(x, y, transform.position.z);
        
    }
}
