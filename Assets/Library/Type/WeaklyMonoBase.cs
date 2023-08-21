#define _HISTORY_

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

namespace Library.Type
{
    /// <summary>
    /// �����ͽű�
    /// </summary>
    public class WeaklyMonoBase : MonoBehaviour
    {
        #region �ֶ�

        private WeaklyObjectBase weaklyBase = null;

#if _HISTORY_

		/// <summary>
		/// ��ʷ����
		/// </summary>
		private Vector3 history_Position;

        /// <summary>
        /// ��ʷ��ת
        /// </summary>
        private Quaternion history_Rotation;

        /// <summary>
        /// ��ʷ����
        /// </summary>
        private Vector3 history_Scale;

		//private 

#endif

#if UNITY_EDITOR

		private static PlayModeStateChange playModeState;

		[Obsolete("���༭��ģʽ�¿���")]
		public static PlayModeStateChange PlayModeState => playModeState;
		public static bool IsNotExitingPlayMode
		{
			[Obsolete("���༭��ģʽ�¿���")]
			get;
			private set;
		}

#endif

		#endregion

		#region ����

#if _HISTORY_

		/// <summary>
		/// ��ȡ��ʷ����
		/// </summary>
		public Vector3 HistoryPosition => history_Position;

		/// <summary>
		/// ��ȡ��ʷ��ת
		/// </summary>
		public Quaternion HistoryRotation => history_Rotation;

		/// <summary>
		/// ��ȡ��ʷ����
		/// </summary>
		public Vector3 HistoryScale => history_Scale;

#endif

		#endregion

		#region ��������

#if UNITY_EDITOR

		[InitializeOnLoadMethod]
		static void OnLoad()
		{
			EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
		}

#endif

		#endregion

		#region �¼�

#if UNITY_EDITOR
		static void OnPlayModeStateChanged(PlayModeStateChange state)
		{
			IsNotExitingPlayMode = state != PlayModeStateChange.ExitingPlayMode;
			playModeState = state;
			Debug.Log($">>>>>>> {Enum.GetName(typeof(PlayModeStateChange), state)} <<<<<<<");
		}
#endif
		#endregion

	}
}