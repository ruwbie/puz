﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeansMove : MonoBehaviour
{
    private Vector3 mouse_position_;

    private float delta_x_, delta_y_;

    private float offset_ = 0;

    [SerializeField]
    private Rigidbody2D rigidbody2d_;

    private int rand_num_ = 0;

    private Vector2 rand_vector_;

    private void Start()
    {
        Rand4();

        StartCoroutine(RandomVector());
    }


    //Update is called once per frame
    void Update()//Touch の処理が入っている。
    {
        rigidbody2d_.AddForce(rand_vector_);
        if (Input.touchCount > 0)
        {
            transform.Translate(Input.GetTouch(0).deltaPosition * Time.deltaTime);
        }
        pushObjectBackInFrustum(this.transform);

        if(this.gameObject.GetComponent<Status>().GetHoming())
        {
            this.rand_vector_ = Vector2.zero;
            StopCoroutine(RandomVector());
        }
        
    }

    private void OnMouseDown()
    {
        if (GameManager.is_game_over_)
        {
            return;
        }

        delta_x_ = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - this.transform.position.x;
        delta_y_ = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - this.transform.position.y;
    }

    private void OnMouseDrag()
    {
        if (GameManager.is_game_over_)
        {
            return;
        }
        mouse_position_ = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector2(mouse_position_.x - delta_x_, mouse_position_.y - delta_y_);
        
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

    private void Rand4()
    {
        rand_num_ = Random.Range(0, 4);
        switch (rand_num_)
        {
            default:
                break;
            case 0:
                rand_vector_ = Vector2.up;
                break;
            case 1:
                rand_vector_ = Vector2.down;
                break;
            case 2:
                rand_vector_ = Vector2.right;
                break;
            case 3:
                rand_vector_ = Vector2.left;
                break;
        }
    }

    private IEnumerator RandomVector()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            Rand4();
        }

    }
}
