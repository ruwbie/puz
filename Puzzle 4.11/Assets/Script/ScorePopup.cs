using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePopup : MonoBehaviour
{
    public static ScorePopup Create(Vector3 position, int scoreAmount)
    {
        Transform score_popup_transform = Instantiate(GameAssets.Instance.score_popup, position, Quaternion.identity);

        ScorePopup score_popup = score_popup_transform.GetComponent<ScorePopup>();
        score_popup.Setup(scoreAmount);

        return score_popup;
    }
    private TextMeshPro textmesh_;


    private void Awake()
    {
        textmesh_ = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int scoreAmount)
    {
        textmesh_.SetText(scoreAmount.ToString());
    }
}
