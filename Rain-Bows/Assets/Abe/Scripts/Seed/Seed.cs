// ----- ----- ----- ----- -----
//
// Seed
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

[AddComponentMenu("MyScript/Seed")]
public class Seed : MonoBehaviour
{
    [SerializeField]
    private GameObject SeedGrowObject;

    public void OnGrow()
    {
        SeedGrowObject.GetComponent<ISeed>().OnGrow();
    }
}