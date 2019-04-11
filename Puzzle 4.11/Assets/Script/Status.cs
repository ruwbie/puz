﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Status : MonoBehaviour
{
    public bool target_;
    public bool homing_;

    private Transform lockon_;

    private Rigidbody2D rigidbody_;

    private float collision_time_ = 0;

    public float speed_;
    

    // Start is called before the first frame update
    void Start()
    {
        lockon_ = null;
        rigidbody_ = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (homing_)
        {
            HomingtoTarget();
        }
    }

    private void OnMouseDown()
    {
        SetTargetT();
    }


    private void OnCollisionStay2D(Collision2D collision)   //★
    {
        if(collision.gameObject.GetComponent<Status>() == null)
        {
            return;
        }
        if(collision.gameObject.GetComponent<Status>().target_)
        {
            this.collision_time_++;
            if(this.collision_time_ > 17)
            {
                SetHomingT();
                lockon_ = collision.gameObject.transform;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        this.collision_time_ = 0;
    }

    private void HomingtoTarget()   //★
    {
        if (this.lockon_ == null)
        {
            SetHomingF();
            GravityOn();
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

    public void GravityZero()
    {
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public void GravityOn()
    {
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = -1;
    }
}
