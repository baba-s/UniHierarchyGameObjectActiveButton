using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
	/// <summary>
	/// Hierarchy にゲームオブジェクトのアクティブを変更できるボタンを追加するエディタ拡張
	/// </summary>
	internal static class HierarchyGameObjectActiveButton
	{
		//================================================================================
		// 定数
		//================================================================================
		private const int WIDTH = 16;

		//================================================================================
		// 関数(static)
		//================================================================================
		/// <summary>
		/// コンストラクタ
		/// </summary>
		[InitializeOnLoadMethod]
		private static void Example()
		{
			EditorApplication.hierarchyWindowItemOnGUI += OnGUI;
		}

		/// <summary>
		/// GUI を描画する時に呼び出されます
		/// </summary>
		private static void OnGUI( int instanceID, Rect selectionRect )
		{
			var settings = HierarchyGameObjectActiveButtonSettings.Instance;

			if ( settings == null || !settings.IsEnable ) return;

			var gameObject = EditorUtility.InstanceIDToObject( instanceID ) as GameObject;

			if ( gameObject == null ) return;

			var position = selectionRect;

			position.x     = position.xMax - WIDTH;
			position.width = WIDTH;

			var newActive = GUI.Toggle( position, gameObject.activeSelf, string.Empty );

			if ( newActive == gameObject.activeSelf ) return;

			Undo.RecordObject( gameObject, "Inspector" );
			gameObject.SetActive( newActive );
		}
	}
}