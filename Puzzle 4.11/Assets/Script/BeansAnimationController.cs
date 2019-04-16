using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeansAnimationController : MonoBehaviour
{

    public Animator beans_animator_;


    private void Start()
    {
        InvokeRepeating("RandomTrigger", 1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        #region touch
        //=====================================================TOUCH===============================================
        //if (Input.touchCount > 0)
        //{
        //    beans_animator_.SetBool("Is_tapped", true);
        //}
        //else
        //{
        //    beans_animator_.SetBool("Is_tapped", false);
        //}

        //=====================================================TOUCH===============================================
        #endregion

        if(BlockInput.is_game_over_)
        {
            this.enabled = false;
        }
    }

    private void RandomTrigger()
    {
        float randomX = Random.Range(0, 2);
        if (randomX == 1)
        {
            beans_animator_.SetTrigger("Idle_trigger");
        }
    }

    private void OnMouseDrag()
    {
        if(this.gameObject.GetComponent<Status>().GetHoming() || this.gameObject.GetComponent<Status>().GetTarget())
        {
            SetTappedOn();
        }
       
    }

    //private void OnMouseUp()
    //{
    //    beans_animator_.SetBool("Is_tapped", false);
    //}

    public void SetTappedOn()
    {
        beans_animator_.SetBool("Is_tapped", true);
    }

}
