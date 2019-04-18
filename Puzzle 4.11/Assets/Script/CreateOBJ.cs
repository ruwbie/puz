using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOBJ : MonoBehaviour
{
    public GameObject plus_time_;



    // Update is called once per frame
    void Update()
    {
        if(GameManager.plus_time_flag_)
        {
            Instantiate(plus_time_,this.transform);
        }
    }
}
