// ----- ----- ----- ----- -----
//
// ISeed
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

[AddComponentMenu("MyScript/ISeed")]
public abstract class ISeed : MonoBehaviour
{
    //成長
    public abstract void OnGrow();
}
