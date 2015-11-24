// ----- ----- ----- ----- -----
//
// MouseLineCast
//
// 作成日：
// 作成者：
//
// <概要>
//
//
// ----- ----- ----- ----- -----

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[AddComponentMenu("Mouse/MouseLineCast")]
public class MouseLineCast : MouseHitCheck
{
    private Vector2 previousPosition;

    protected override void HitAwake()
    {
        previousPosition = ChangePosition(Input.mousePosition);
    }

    public override void HitCheck()
    {
        Vector2 mousePosition = ChangePosition(Input.mousePosition);
        hitInfo = Physics2D.Linecast(previousPosition, mousePosition, layer);
    }

    void LateUpdate()
    {
        previousPosition = ChangePosition(Input.mousePosition);
    }

    Vector2 ChangePosition(Vector2 position)
    {
        return Camera.main.ScreenToWorldPoint(position);
    }
}