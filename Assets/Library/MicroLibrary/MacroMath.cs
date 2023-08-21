using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;

namespace Library.Macro
{
	/// <summary>
	/// 数学库
	/// </summary>
    public static class MacroMath
    {
		#region 常量

		/// <summary>
		/// 弧度转角度
		/// </summary>
		public const double Rad2Ang = 57.2957795130823d;
		/// <summary>
		/// 角度转弧度
		/// </summary>
		public const double Ang2Rad = .0174532925199433d;
		/// <summary>
		/// 最大可接受的误差
		/// </summary>
		public const float MaxError = .000001f;
		/// <summary>
		/// 根号2的一半，可以用于快速平方根除以二
		/// </summary>
		public const float Sqrt22 = 0.70710678118654752440084436210485f;

		public static readonly  Vector3Int Vector3Int_Negate = new Vector3Int(-1, -1, -1);

		#endregion

		#region 随机

		/// <summary>
		/// 哈希后处理
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong MurmurFinalize(ulong index)
		{
			index ^= index >> 33;
			index *= 0xff51afd7ed558ccd;
			index ^= index >> 33;
			index *= 0xc4ceb9fe1a85ec53;
			index ^= index >> 33;
			return index;
		}

		/// <summary>
		/// 大范围随机
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong RandomNumber(ulong index)
		{
			index *= 1103515245;
			index += 12345;
			index *= 6364136223846793005UL;
			index += 1442695040888963407UL;
			index %= 18446744073709551615UL;
			return index;
		}

		#endregion

		#region 数学

		/// <summary>
		/// pmod
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double PMod(double a, double b)
		{
			double z = a % b;
			double w = (z < 0) ? -1 : 1;
			z = (z < 0) ? -z : z;
			if(w < 0)
				return b - z;
			else
				return z;
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float MinPositive(float a, float b)
			=> Math.Min(Math.Max(0, a), Math.Max(0, b));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int MinPositive(int a, int b)
			=> Math.Min(Math.Max(0, a), Math.Max(0, b));

		#endregion

		#region 字节控制

		/// <summary>
		/// 设置字
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetByteState(ref int target, int site, bool state)
		{
			if(state)
				target |= 1 << site;

			else
				target &= 0xff - (1 << site);
		}

		/// <summary>
		/// 设置字
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetByteState(ref int target, Enum site, bool state)
		{
			SetByteState(ref target, Convert.ToInt32(site), state);
		}

		/// <summary>
		/// 检查字
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool GetByteState(int target, int site)
		{
			return (target >> site & 0x01) > 0;
		}

		/// <summary>
		/// 检查字
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool GetByteState(int target, Enum site)
		{
			return GetByteState(target, Convert.ToInt32(site));
		}

		#endregion

		#region 文本

		/// <summary>
		/// 获取此处的物体名称，如果带有（clone）后缀，则省略这个后缀
		/// </summary>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string GetGameObjectNameWithoutClone(GameObject gameObject)
		{
			return GetGameObjectNameWithoutClone(gameObject.name);
		}

		/// <summary>
		/// 获取此处的物体名称，如果带有（clone）后缀，则省略这个后缀
		/// </summary>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string GetGameObjectNameWithoutClone(string gameObjectName)
		{
			const string cloneSuffix = "(Clone)";
			if(gameObjectName.EndsWith(cloneSuffix))
			{
				int suffixIndex = gameObjectName.LastIndexOf(cloneSuffix);
				string nameWithoutClone = gameObjectName.Substring(0, suffixIndex);
				return nameWithoutClone;
			}
			return gameObjectName;
		}

		#endregion
	}
}