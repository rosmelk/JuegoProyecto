using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador : MonoBehaviour
{
    public float f_vel;

    private Vector2 v_dir;
    // Start is called before the first frame update
    void Start()
    {
        v_dir = new Vector2(0, -1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(v_dir * Time.deltaTime * f_vel);
        if(transform.position.y < Zorro2Player.v_inf_izq.y + 1 && v_dir.y < 0){
            v_dir.y = -v_dir.y;
        }
        if(transform.position.y > Zorro2Player.v_sup_der.y - 1 && v_dir.y > 0){
            v_dir.y = -v_dir.y;
        }
    }
}
