using Library.Macro;
using Library.Type;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Library.Grometry
{
	/// <summary>
	/// 自定几何组件
	/// </summary>
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	public class PolygComponent : WeaklyMonoBase
	{
		#region 字段

		/// <summary>
		/// 模型录入组件
		/// </summary>
		protected MeshFilter meshFilter;

		/// <summary>
		/// 模型渲染组件
		/// </summary>

		protected MeshRenderer meshRenderer;

		#endregion

		#region 生命周期

		protected void Awake()
		{
			InitializationComponentQuote();
		}

		#endregion

		#region 方法

		/// <summary>
		/// 初始化组件引用
		/// </summary>
		private void InitializationComponentQuote()
		{
			meshFilter = gameObject.GetComponentAnyway<MeshFilter>();
			meshRenderer = gameObject.GetComponentAnyway<MeshRenderer>();
		}


		#endregion
	}
}
