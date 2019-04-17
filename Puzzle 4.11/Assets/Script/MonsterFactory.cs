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
        Rand4();
        if(GameManager.ume_points_ < 15.0f)
        {
            Instantiate(mosters_[rand_num_],this.transform);
        }
    }

    private void Rand4()
    {
        rand_num_ = Random.Range(0, 3);
        
    }
}
