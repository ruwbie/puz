using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Status : MonoBehaviour
{
    public bool target_ = false;
    public bool homing_ = false;

    public Transform lockon_;

    private Rigidbody2D rigidbody_;

    private float collision_time_ = 0;

    public float speed_;

    private float gravity_scale_;





    // Start is called before the first frame update
    void Start()
    {
        lockon_ = null;
        rigidbody_ = GetComponent<Rigidbody2D>();
        gravity_scale_ = this.gameObject.GetComponent<Rigidbody2D>().gravityScale;
    }


    private void FixedUpdate()
    {
        if (homing_)
        {
            this.gameObject.GetComponent<BeansAnimationController>().SetTappedOn();
            HomingtoTarget();
        }
        if(this.target_ || this.homing_)
        {
            this.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 255);
        }
    }

    private void OnMouseDown()
    {
        if (GameManager.is_game_over_)
        {
            return;
        }
        SetTargetT();
        GravityZero();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Status>() == null || this.enabled == false)   //エラーチェック
        {
            return;
        }
        
        if (collision.gameObject.GetComponent<Status>().target_)
        {
            GravityZero();
        }

    }


    //private void OnCollisionStay2D(Collision2D collision)   //★
    //{
    //    if (collision.gameObject.GetComponent<Status>() == null || this.enabled == false)   //エラーチェック
    //    {
    //        return;
    //    }

    //    if (collision.gameObject.CompareTag(this.gameObject.tag))   //色のタグが一致するか
    //    {
    //        if (collision.gameObject.GetComponent<Status>().target_)    //ぶつかって来たGameObjectがTargetに設定されているか
    //        {
    //            //ここから下の処理を考えなおす…

    //            this.collision_time_++;
    //            if (this.collision_time_ > this.gameObject.GetComponent<Rigidbody2D>().mass * 7)       //magicNum
    //            {
    //                SetHomingT();
    //                lockon_ = collision.gameObject.transform;
    //            }
    //        }

    //    }

    //}

    private void OnCollisionExit2D(Collision2D collision)
    {
        this.collision_time_ = 0;
        GravityOn();
    }

    private void HomingtoTarget()   //★
    {
        if (this.lockon_ == null)
        {
            SetHomingF();

            return;
        }
        GravityZero();
        transform.position = Vector2.MoveTowards(transform.position, lockon_.position, speed_ * Time.deltaTime);
    }

    public void SetTargetT()
    {
        this.target_ = true;
    }

    public void SetHomingT()
    {
        this.homing_ = true;
    }

    public void SetHomingF()
    {
        this.homing_ = false;
    }

    //public bool GetHoming()
    //{
    //    return this.homing_;
    //}

    //public bool GetTarget()
    //{
    //    return this.target_;
    //}

    public void GravityZero()
    {
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public void GravityOn()
    {
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity_scale_;
    }
}
