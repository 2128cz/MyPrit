using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Library.Macro
{
	public static class MacroObject
	{
		#region 对象操作

		/// <summary>
		/// 无论如何都要获取一个组件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T GetComponentAnyway<T>(this GameObject obj)
		where T : Component
		{
			var component = obj.GetComponent<T>();
			if(component is null)
				component = obj.AddComponent<T>();
			return component;
		}

		/// <summary>
		/// 无论如何都要获取一个对象
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static T GetObjectAnyway<T>(this T obj)
		where T : new()
		{
			if(obj is null)
				obj = new T();
			return obj;
		}

		#endregion

	}
}
