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

    private float this_mass_;

    private void Start()
    {
        this_mass_ = this.gameObject.GetComponent<Rigidbody2D>().mass;
        GameManager.ume_points_ += 1 * this_mass_;
    }

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
                    
                    ScorePopup.Create(score_popup_transform, this.transform.position, 100);
                    if(Score.score_int_ >= 9999900)
                    {
                        return;
                    }
                    Score.score_int_ += 100;
                    
                    
                }
                GameManager.ume_points_ -= 1 * this_mass_;
                Destroy(this.gameObject);

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
