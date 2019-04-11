using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets game_assets_;

    public static GameAssets Instance
    {
        get
        {
            if (game_assets_ == null)
            {
                game_assets_ = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            }
            return game_assets_;
        }
    }

    public Transform score_popup;
}
