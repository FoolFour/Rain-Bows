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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        hitInfo = Physics2D.Raycast(ray.origin, ray.direction, 10, layer);
    }
}