using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

using System.Runtime.CompilerServices;

using UnityEngine;

using Xorti = Library.Macro.MacroMath;

namespace Library.Macro
{
    public static class ExtendType
    {
		#region 算法

		/// <summary>
		/// 检查给定的值是否在范围内[min, max]
		/// </summary>
		/// <param name="value"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsInRange(this int value, int min, int max)
			=> value >= min && value <= max;

		/// <summary>
		/// 检查给定的值是否在索引范围内[min, max)
		/// </summary>
		/// <param name="value"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsInIndexRange(this int value, int min, int max)
		=> value >= min && value < max;


		/// <summary>
		/// 二次方
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Quad(this int value)
		{
			return value * value;
		}
		/// <summary>
		/// 三次方
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Cubic(this int value)
		{
			return value * value * value;
		}
		/// <summary>
		/// 四次方
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Quart(this int value)
		{
			return value * value * value * value;
		}
		/// <summary>
		/// 五次方
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Quint(this int value)
		{
			return value * value * value * value * value;
		}


		/// <summary>
		/// 二次方
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Quad(this float value)
		{
			return value * value;
		}
		/// <summary>
		/// 三次方
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Cubic(this float value)
		{
			return value * value * value;
		}
		/// <summary>
		/// 四次方
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Quart(this float value)
		{
			return value * value * value * value;
		}
		/// <summary>
		/// 五次方
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Quint(this float value)
		{
			return value * value * value * value * value;
		}

		#endregion

		#region 事件

		/// <summary>
		/// 保守地调用一个事件分发器
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool InvokeConservative(this Action invokedEvent, int sign, ref int register)
		{
			if(Xorti.GetByteState(register, sign))
				return false;
			Xorti.SetByteState(ref register, sign, true);
			invokedEvent?.Invoke();
			Xorti.SetByteState(ref register, sign, false);
			return true;
		}

		/// <summary>
		/// 保守地调用一个事件分发器
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool InvokeConservative<PARAM>(this Action<PARAM> invokedEvent, PARAM input, int sign, ref int register)
		{
			if(Xorti.GetByteState(register, sign))
				return false;
			Xorti.SetByteState(ref register, sign, true);
			invokedEvent?.Invoke(input);
			Xorti.SetByteState(ref register, sign, false);
			return true;
		}

		#endregion

		#region 对象

		/// <summary>
		/// 获取组件，并适配函数式编程
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="target"></param>
		/// <param name="component"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool GetComponent<T>(this GameObject target, out T component)
		{
			component = target.GetComponent<T>();
			return component is not null;
		}

		/// <summary>
		/// 此对象的父类是第二者吗
		/// </summary>
		/// <param name="target"></param>
		/// <param name="other"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ParentIs(this GameObject target, GameObject other)
		{
			return target.transform.parent == other.transform;
		}

		/// <summary>
		/// 此对象是第二者的父类吗
		/// </summary>
		/// <param name="target"></param>
		/// <param name="other"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsParent(this GameObject target, GameObject other)
		{
			return target.transform == other.transform.parent;
		}

		/// <summary>
		/// 此对象与第二者是兄弟吗
		/// </summary>
		/// <param name="target"></param>
		/// <param name="other"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsBrother(this GameObject target, GameObject other)
		{
			return target.transform.parent == other.transform.parent;
		}

		#endregion

		#region bound

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsInUnit(this Vector3 vec, float align = 1)
		{
			float negat = 1 - align;
			return
			vec.x <= align &&
			vec.y <= align &&
			vec.z <= align &&
			vec.x >= negat &&
			vec.y >= negat &&
			vec.z >= negat;
		}

		#endregion

		#region string

		private static string ListToString<T>(this List<List<T>> context)
		{
			string result = "";
			Func<List<T>, string> ListFormat = (List<T> list) =>
			{
				string result = "";
				for (int i = 0; i < list.Count; i++, result += ",")
					result += $"{i}: {list[i]}";
				return result;
			};
			for(int i = 0; i < context.Count; i++)
				result += $"List{i}: {{{ListFormat(context[i])}}}\r\n";
			return result;
		}

		#endregion
	}
}
