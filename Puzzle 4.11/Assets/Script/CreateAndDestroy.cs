using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAndDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject smaller_clone_ = null;
    //private float random_value_x_ = 0;
    //private float random_value_y_ = 0;
    private Vector3 random_position_;

    private float offset_ = 0.1f;

    private void OnMouseUp()
    {

        Destroy(this.gameObject);
        if(smaller_clone_ != null)
        {
            for(int i = 0; i <3; ++i)
            {
                //random_value_x_ = Random.Range(-1, 2);
                //random_value_y_ = Random.Range(-1, 2);
                //if(i == 0)
                //{
                //    random_position_ = new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, 0);
                //}
                //else if(i == 1)
                //{
                //    random_position_ = new Vector3(this.transform.position.x - 0.1f, this.transform.position.y - 0.1f, 0);
                //}
                //else
                //{
                //    random_position_ = new Vector3(this.transform.position.x + 0.1f, this.transform.position.y - 0.1f, 0);
                //}
                SetPosition(i);
                
                Instantiate(smaller_clone_, random_position_, Quaternion.identity);
            }
        }
    }

    private void SetPosition(int i)
    {
        int tempint = 1;
        if(i % 2 !=0)
        {
            tempint *= -1;
        }
        random_position_ = new Vector3(this.transform.position.x - offset_ + (offset_*i), 
            this.transform.position.y - (offset_*tempint), 
            0);
    }
}
