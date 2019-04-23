using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingHandler : MonoBehaviour
{
    public bool touched = false;

    

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Status>() == null || this.enabled == false)   //エラーチェック
        {
            return;
        }

        if (collision.gameObject.CompareTag(this.gameObject.tag))   //色のタグが一致するか
        {
            if (collision.gameObject.GetComponent<Status>().target_)    //ぶつかって来たGameObjectがTargetに設定されているか
            {
                //ここから下の処理を考えなおす…
                this.gameObject.GetComponentInParent<Status>().SetHomingT();
                this.gameObject.GetComponentInParent<Status>().lockon_ = collision.gameObject.transform;
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touched = false;
    }
}
