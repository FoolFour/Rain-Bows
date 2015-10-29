// ----- ----- ----- ----- -----
//
// MouseChase
//
// 作成日：
// 作成者：
//
// <概要>
//
//
// ----- ----- ----- ----- -----

using UnityEngine;

[AddComponentMenu("MyScript/MouseChase")]
public class MouseChase : MonoBehaviour
{
    #region メソッド

    // 更新処理
    void Update()
    {
        SyncMousePosition();
    }

    public void SyncMousePosition()
    {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 10;

		Vector3 position = Camera.main.ScreenToWorldPoint (mousePos);

		transform.position = position;
    }
	#endregion
}