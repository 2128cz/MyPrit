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
		#region �㷨

		/// <summary>
		/// ��������ֵ�Ƿ��ڷ�Χ��[min, max]
		/// </summary>
		/// <param name="value"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsInRange(this int value, int min, int max)
			=> value >= min && value <= max;

		/// <summary>
		/// ��������ֵ�Ƿ���������Χ��[min, max)
		/// </summary>
		/// <param name="value"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsInIndexRange(this int value, int min, int max)
		=> value >= min && value < max;


		/// <summary>
		/// ���η�
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Quad(this int value)
		{
			return value * value;
		}
		/// <summary>
		/// ���η�
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Cubic(this int value)
		{
			return value * value * value;
		}
		/// <summary>
		/// �Ĵη�
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Quart(this int value)
		{
			return value * value * value * value;
		}
		/// <summary>
		/// ��η�
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Quint(this int value)
		{
			return value * value * value * value * value;
		}


		/// <summary>
		/// ���η�
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Quad(this float value)
		{
			return value * value;
		}
		/// <summary>
		/// ���η�
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Cubic(this float value)
		{
			return value * value * value;
		}
		/// <summary>
		/// �Ĵη�
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Quart(this float value)
		{
			return value * value * value * value;
		}
		/// <summary>
		/// ��η�
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Quint(this float value)
		{
			return value * value * value * value * value;
		}

		#endregion

		#region �¼�

		/// <summary>
		/// ���صص���һ���¼��ַ���
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
		/// ���صص���һ���¼��ַ���
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

		#region ����

		/// <summary>
		/// ��ȡ����������亯��ʽ���
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
		/// �˶���ĸ����ǵڶ�����
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
		/// �˶����ǵڶ��ߵĸ�����
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
		/// �˶�����ڶ������ֵ���
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
