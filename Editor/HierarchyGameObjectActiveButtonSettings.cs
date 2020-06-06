using System;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
	/// <summary>
	/// 設定を管理するクラス
	/// </summary>
	[Serializable]
	internal sealed class HierarchyGameObjectActiveButtonSettings
	{
		//================================================================================
		// 定数
		//================================================================================
		private const string KEY = "UniHierarchyGameObjectActiveButton";

		//================================================================================
		// 変数(SerializeField)
		//================================================================================
		[SerializeField] private bool m_isEnable = false;

		//================================================================================
		// 変数(static)
		//================================================================================
		private static HierarchyGameObjectActiveButtonSettings m_instance;

		//================================================================================
		// プロパティ
		//================================================================================
		public bool IsEnable
		{
			get => m_isEnable;
			set => m_isEnable = value;
		}

		//================================================================================
		// プロパティ(static)
		//================================================================================
		public static HierarchyGameObjectActiveButtonSettings Instance
		{
			get
			{
				if ( m_instance == null )
				{
					var json = EditorPrefs.GetString( KEY );

					m_instance = JsonUtility.FromJson<HierarchyGameObjectActiveButtonSettings>( json ) ??
					             new HierarchyGameObjectActiveButtonSettings();
				}

				return m_instance;
			}
		}

		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// EditorPrefs に保存します
		/// </summary>
		public void SaveToEditorPrefs()
		{
			var json = JsonUtility.ToJson( this );

			EditorPrefs.SetString( KEY, json );
		}
	}
}