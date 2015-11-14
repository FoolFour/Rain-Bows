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
    private Vector3 previousPosition;

    protected override void HitAwake()
    {
        previousPosition = gameObject.transform.position;
    }

    public override void HitCheck()
    {
        isHit = Physics.Linecast(previousPosition, transform.position, out hitInfo,layer);
    }

    void LateUpdate()
    {
        previousPosition = gameObject.transform.position;
    }
}