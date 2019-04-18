using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager 
{
    public static bool is_game_over_;

    //test
    public static float alive_points_;
    public static float MAX_alive_points_ = 10.0f;

    public static bool plus_time_flag_ = false;

    public static void SetMaxAlivePointPlus()
    {
        MAX_alive_points_+= 0.1f;
    }

    
}
