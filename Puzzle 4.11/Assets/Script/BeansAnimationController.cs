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

    }

    private void RandomTrigger()
    {
        float randomX = Random.Range(0,2);
        if(randomX == 1)
        {
            beans_animator_.SetTrigger("Idle_trigger");
        }
    }

    private void OnMouseDrag()
    {
        beans_animator_.SetBool("Is_tapped", true);
    }

    //private void OnMouseUp()
    //{
    //    beans_animator_.SetBool("Is_tapped", false);
    //}

}
