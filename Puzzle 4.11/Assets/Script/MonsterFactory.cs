using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : MonoBehaviour
{
    public Transform[] mosters_;

    private int rand_num_ = 0;

    // Update is called once per frame
    void Update()
    {
        Rand();
        if(GameManager.remained_counts_ < GameManager.MAX_alive_points_)
        {
            Instantiate(mosters_[rand_num_],this.transform);
        }
    }

    private void Rand()
    {
        rand_num_ = Random.Range(0, mosters_.Length);
        
    }
}
