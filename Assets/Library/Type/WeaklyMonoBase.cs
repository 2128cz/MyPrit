#define _HISTORY_

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

namespace Library.Type
{
    /// <summary>
    /// 弱类型脚本
    /// </summary>
    public class WeaklyMonoBase : MonoBehaviour
    {
        #region 字段

        private WeaklyObjectBase weaklyBase = null;

#if _HISTORY_

		/// <summary>
		/// 历史坐标
		/// </summary>
		private Vector3 history_Position;

        /// <summary>
        /// 历史旋转
        /// </summary>
        private Quaternion history_Rotation;

        /// <summary>
        /// 历史缩放
        /// </summary>
        private Vector3 history_Scale;

		//private 

#endif

#if UNITY_EDITOR

		private static PlayModeStateChange playModeState;

		[Obsolete("仅编辑器模式下可用")]
		public static PlayModeStateChange PlayModeState => playModeState;
		public static bool IsNotExitingPlayMode
		{
			[Obsolete("仅编辑器模式下可用")]
			get;
			private set;
		}

#endif

		#endregion

		#region 属性

#if _HISTORY_

		/// <summary>
		/// 获取历史坐标
		/// </summary>
		public Vector3 HistoryPosition => history_Position;

		/// <summary>
		/// 获取历史旋转
		/// </summary>
		public Quaternion HistoryRotation => history_Rotation;

		/// <summary>
		/// 获取历史缩放
		/// </summary>
		public Vector3 HistoryScale => history_Scale;

#endif

		#endregion

		#region 生命周期

#if UNITY_EDITOR

		[InitializeOnLoadMethod]
		static void OnLoad()
		{
			EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
		}

#endif

		#endregion

		#region 事件

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