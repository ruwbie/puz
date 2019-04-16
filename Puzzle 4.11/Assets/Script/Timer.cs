﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Transform timer_bar_;
    public Transform text_indicator_;
    public Transform text_left_;
    public Transform text_time_over_;
    public Transform button_retry_;
    [SerializeField] private float current_amount_;
    [SerializeField] private float speed_;

    private void Start()
    {
        
        BlockInput.is_game_over_ = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(current_amount_ > 1)
        {
            current_amount_ -= speed_ * Time.deltaTime;
            text_indicator_.GetComponent<Text>().text = ((int)current_amount_).ToString() + "Sec";
            text_left_.gameObject.SetActive(true);
            text_time_over_.gameObject.SetActive(false);
        }
        else
        {
            text_left_.gameObject.SetActive(false);
            text_time_over_.gameObject.SetActive(true);
            button_retry_.gameObject.SetActive(true);
            text_indicator_.GetComponent<Text>().text = "OVER!";

            BlockInput.is_game_over_ = true;
            
        }
        timer_bar_.GetComponent<Image>().fillAmount = current_amount_ / 60;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
