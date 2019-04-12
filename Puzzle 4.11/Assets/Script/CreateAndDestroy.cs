using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAndDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject smaller_clone_ = null;
    private Vector3 random_position_;

    private float offset_ = 0.1f;

    public Transform score_popup_transform;

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {

            if (this.gameObject.GetComponent<Status>().GetHoming() || this.gameObject.GetComponent<Status>().GetTarget())
            {
                if (smaller_clone_ != null)
                {
                    for (int i = 0; i < 3; ++i)
                    {

                        SetPosition(i);

                        Instantiate(smaller_clone_, random_position_, Quaternion.identity);

                    }
                }
                else
                {
                    //Instantiate(score_popup_, this.transform.position, Quaternion.identity);
                    ScorePopup.Create(score_popup_transform, this.transform.position, 100);
                }

                Destroy(this.gameObject);

            }
        }
    }

    //private void OnMouseUp()
    //{
    //    if(smaller_clone_ != null)
    //    {
    //        for(int i = 0; i <3; ++i)
    //        {
               
    //            SetPosition(i);
                
    //            Instantiate(smaller_clone_, random_position_, Quaternion.identity);
               
    //        }
    //    }
    //    else
    //    {
    //        //Instantiate(score_popup_, this.transform.position, Quaternion.identity);
    //        ScorePopup.Create(score_popup_transform ,this.transform.position, 100);
    //    }

    //}

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
