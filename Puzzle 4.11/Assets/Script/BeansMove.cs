using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeansMove : MonoBehaviour
{
    private Vector3 mouse_position_;

    private float delta_x_, delta_y_;

    private float offset_ = 0;

    [SerializeField]
    private Rigidbody2D rigidbody2d_;
   


    //Update is called once per frame
    void Update()//Touch の処理が入っている。
    {
        if (Input.touchCount > 0)
        {
            transform.Translate(Input.GetTouch(0).deltaPosition * Time.deltaTime);
        }
        

        pushObjectBackInFrustum(this.transform);
    }

    private void OnMouseDown()
    {
        delta_x_ = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - this.transform.position.x;
        delta_y_ = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - this.transform.position.y;
    }

    private void OnMouseDrag()
    {
        mouse_position_ = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector2(mouse_position_.x - delta_x_, mouse_position_.y - delta_y_);
        this.gameObject.GetComponent<Status>().GravityZero();
    }

    private void OnMouseUp()
    {
        this.gameObject.GetComponent<Status>().GravityOn();
        
    }

    void pushObjectBackInFrustum(Transform transform)
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0.0f + offset_) { pos.x = 0.0f + offset_; }
        if (pos.x > 1.0f - offset_) { pos.x = 1.0f - offset_; }
        if (pos.y < 0.0f + offset_) { pos.y = 0.0f + offset_; }
        if (pos.y > 1.0f - offset_) { pos.y = 1.0f - offset_; }

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
