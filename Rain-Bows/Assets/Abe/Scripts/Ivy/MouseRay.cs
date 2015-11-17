// ----- ----- ----- ----- -----
//
// MouseRay
//
// 作成日：
// 作成者：
//
// <概要>
//
//
// ----- ----- ----- ----- -----

using UnityEngine;

[AddComponentMenu("Mouse/MouseRay")]
public class MouseRay : MouseHitCheck
{
    //任意のタイミングでヒットされたかどうかを見る為 publicに
    public override void HitCheck()
    {
        //
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        isHit = Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layer);
    }
}