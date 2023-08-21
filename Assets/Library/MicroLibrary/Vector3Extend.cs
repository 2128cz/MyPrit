using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;

namespace Library.Macro
{
    public static class Vector3Extend
    {
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Add(this Vector3 a, Vector3 b)
			=> new Vector3(
			a.x + b.x,
			a.y + b.y,
			a.z + b.z
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Add(this Vector3 a, Vector3Int b)
			=> new Vector3(
			a.x + b.x,
			a.y + b.y,
			a.z + b.z
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Add(this Vector3 a, float b)
			=> new Vector3(
			a.x + b,
			a.y + b,
			a.z + b
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Sub(this Vector3 a, Vector3 b)
			=> new Vector3(
			a.x - b.x,
			a.y - b.y,
			a.z - b.z
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Sub(this Vector3 a, Vector3Int b)
			=> new Vector3(
			a.x - b.x,
			a.y - b.y,
			a.z - b.z
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Sub(this Vector3 a, float b)
			=> new Vector3(
			a.x - b,
			a.y - b,
			a.z - b
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Mul(this Vector3 a, Vector3 b)
			=> new Vector3(
			a.x * b.x,
			a.y * b.y,
			a.z * b.z
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Mul(this Vector3 a, Vector3Int b)
			=> new Vector3(
			a.x * b.x,
			a.y * b.y,
			a.z * b.z
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Mul(this Vector3 a, float b)
			=> new Vector3(
			a.x * b,
			a.y * b,
			a.z * b
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Div(this Vector3 a, Vector3 b)
			=> new Vector3(
			a.x / b.x,
			a.y / b.y,
			a.z / b.z
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Div(this Vector3 a, Vector3Int b)
			=> new Vector3(
			a.x / b.x,
			a.y / b.y,
			a.z / b.z
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Div(this Vector3 a, float b)
			=> new Vector3(
			a.x / b,
			a.y / b,
			a.z / b
			);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Xonly(this Vector3 a)
			=> new Vector3(
			a.x,
			0f,
			0f
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Yonly(this Vector3 a)
			=> new Vector3(
			0f,
			a.y,
			0f
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Zonly(this Vector3 a)
			=> new Vector3(
			0f,
			0f,
			a.z
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Mode(this Vector3 a, Vector3 b)
		{
			return new Vector3(a.x % b.x, a.y % b.y, a.z % b.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Mode(this Vector3 a, float b)
		{
			return new Vector3(a.x % b, a.y % b, a.z % b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Sign(this Vector3 vec)
			=> new Vector3(
			Math.Sign(vec.x),
			Math.Sign(vec.y),
			Math.Sign(vec.z)
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int CeilToInt(this Vector3 vec)
			=> new Vector3Int((int)Mathf.Ceil(vec.x), (int)Mathf.Ceil(vec.y), (int)Mathf.Ceil(vec.z));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Ceil(this Vector3 vec)
			=> new Vector3(Mathf.Ceil(vec.x), Mathf.Ceil(vec.y), Mathf.Ceil(vec.z));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int RoundToInt(this Vector3 vec)
			=> new Vector3Int((int)Mathf.Round(vec.x), (int)Mathf.Round(vec.y), (int)Mathf.Round(vec.z));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Round(this Vector3 vec)
			=> new Vector3(Mathf.Round(vec.x), Mathf.Round(vec.y), Mathf.Round(vec.z));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int FloorToInt(this Vector3 vec)
			=> new Vector3Int((int)vec.x, (int)vec.y, (int)vec.z);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Floor(this Vector3 vec)
			=> new Vector3((int)vec.x, (int)vec.y, (int)vec.z);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Min(this Vector3 a, Vector3 b)
		{
			return new Vector3(Math.Min(a.x, b.x), Math.Min(a.y, b.y), Math.Min(a.z, b.z));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Max(this Vector3 a, Vector3 b)
		{
			return new Vector3(Math.Max(a.x, b.x), Math.Max(a.y, b.y), Math.Max(a.z, b.z));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float MinElement(this Vector3 a)
		{
			return Math.Min(Math.Min(a.x, a.y), a.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float MaxElement(this Vector3 a)
		{
			return Math.Max(Math.Max(a.x, a.y), a.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Abs(this Vector3 a)
		{
			return new Vector3(Mathf.Abs(a.x), Mathf.Abs(a.y), Mathf.Abs(a.z));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Negative(this Vector3 a)
			=> new Vector3(-a.x, -a.y, -a.z);


		/// <summary>
		/// 李若辰规定的编辑表面坐标转换方法
		/// </summary>
		/// <param name="vec"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 ToVector2(this Vector3 vec)
			=> new Vector2(vec.x, vec.z);

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Vector2 ToVector2(this Vector3 vec, string format)
		{
			Vector2 result = new Vector2();
			for(int i = 0; i < format.Length && i < 2; i++)
			{
				int index = MacroMath.MinPositive(format[i] - 'X', format[i] - 'x');
				result[index] = format[i] switch
				{
					'x' => vec.x,
					'X' => vec.x,
					'y' => vec.y,
					'Y' => vec.y,
					'z' => vec.z,
					'Z' => vec.z,
					_ => 0
				};
			}
			return result;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Vector3 AxisZero(this Vector3 vec, string format)
		{
			Vector3 result = vec;
			for(int i = 0; i < format.Length && i < 2; i++)
			{
				int index = MacroMath.MinPositive(format[i] - 'X', format[i] - 'x');
				result[index] = 0;
			}
			return result;
		}


		/// <summary>
		/// 将这个向量投影到一个给定坐标的向上的平面上，同时变换到平面坐标
		/// </summary>
		/// <param name="vec">矢量或坐标</param>
		/// <param name="planeOrigin">平面原点</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 ProjectToUpPlane(this Vector3 vec, Vector3 planeOrigin)
			=> vec - new Vector3(0, (vec - planeOrigin).y, 0);

		/// <summary>
		/// 向量吸附到网格上，在比例中央不进行吸附
		/// </summary>
		/// <param name="vec">矢量或坐标</param>
		/// <param name="offset">偏移量</param>
		/// <param name="unit">网格单位</param>
		/// <param name="thresholdPorp">阈值比例[0-1]</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 CoordinateGridAdsorb(this Vector3 vec, Vector3 offset, float unit, float thresholdPorp)
		{
			Vector3 vecInUnit = (vec + offset).Mode(unit);
			Vector3 sig = vecInUnit.Sign() * unit / 2;
			Vector3 dis = sig - vecInUnit;
			Vector3 drive = dis.Abs().Sub(unit * thresholdPorp).Sign();
			Vector3 ofs = (dis - sig).Mul(drive * 2) + vecInUnit;
			return ofs;
		}

		/// <summary>
		/// 向量吸附到网格上
		/// </summary>
		/// <param name="vec">矢量或坐标</param>
		/// <param name="offset">偏移量</param>
		/// <param name="unit">网格单位</param>
		/// <param name="thresholdPorp">阈值比例[0-1]</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 CoordinateGridAdsorbRound(this Vector3 vec, Vector3 offset, float unit)
		{
			return ((vec + offset) / unit).Round() * unit;
		}


		/// <summary>
		/// 矢量正交化
		/// </summary>
		/// <param name="vec"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Orthogonalization(this Vector3 vec)
			=> new Vector3(
			(float)Math.Round(vec.x),
			(float)Math.Round(vec.y),
			(float)Math.Round(vec.z)
			);

	}



	public static class Vector3IntExtend
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int Add(this Vector3Int a, Vector3Int b)
			=> new Vector3Int(
			a.x + b.x,
			a.y + b.y,
			a.z + b.z
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int Add(this Vector3Int a, Vector3 b)
			=> new Vector3Int(
			(int)(a.x + b.x),
			(int)(a.y + b.y),
			(int)(a.z + b.z)
			);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int Add(this Vector3Int a, int b)
			=> new Vector3Int(
			a.x + b,
			a.y + b,
			a.z + b
			);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int Sub(this Vector3Int a, Vector3Int b)
			=> new Vector3Int(
			a.x - b.x,
			a.y - b.y,
			a.z - b.z
			);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int Sub(this Vector3Int a, Vector3 b)
			=> new Vector3Int(
			(int)(a.x - b.x),
			(int)(a.y - b.y),
			(int)(a.z - b.z)
			);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int Sub(this Vector3Int a, int b)
			=> new Vector3Int(
			a.x - b,
			a.y - b,
			a.z - b
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int Mul(this Vector3Int a, Vector3Int b)
			=> new Vector3Int(
			a.x * b.x,
			a.y * b.y,
			a.z * b.z
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int Mul(this Vector3Int a, Vector3 b)
			=> new Vector3Int(
			(int)(a.x * b.x),
			(int)(a.y * b.y),
			(int)(a.z * b.z)
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int Mul(this Vector3Int a, int b)
			=> new Vector3Int(
			a.x * b,
			a.y * b,
			a.z * b
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int Div(this Vector3Int a, Vector3Int b)
			=> new Vector3Int(
			a.x / b.x,
			a.y / b.y,
			a.z / b.z
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int Div(this Vector3Int a, Vector3 b)
			=> new Vector3Int(
			(int)(a.x / b.x),
			(int)(a.y / b.y),
			(int)(a.z / b.z)
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int Div(this Vector3Int a, int b)
			=> new Vector3Int(
			a.x / b,
			a.y / b,
			a.z / b
			);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int Negative(this Vector3Int a)
			=> new Vector3Int(-a.x, -a.y, -a.z);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int Min(this Vector3Int a, Vector3Int b)
		{
			return new Vector3Int(Math.Min(a.x, b.x), Math.Min(a.y, b.y), Math.Min(a.z, b.z));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int Max(this Vector3Int a, Vector3Int b)
		{
			return new Vector3Int(Math.Max(a.x, b.x), Math.Max(a.y, b.y), Math.Max(a.z, b.z));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsValid(this Vector3Int lhs)
		{
			return lhs.x >= 0 && lhs.y >= 0 && lhs.z >= 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsInIndexRange(this Vector3Int lhs, Vector3Int max)
		{
			return
			lhs.x.IsInIndexRange(0, max.x) &&
			lhs.y.IsInIndexRange(0, max.y) &&
			lhs.z.IsInIndexRange(0, max.z);
		}

	}
}
