using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;

namespace Library.Macro
{
    public static class Vector2Extend 
    {
		/// <summary>
		/// 李若辰规定的编辑表面坐标转换方法
		/// </summary>
		/// <param name="vec"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 ToVector3(this Vector2 vec)
			=> new Vector3(vec.x, 0, vec.y);

		[Obsolete("unfinished")]
		public static Vector2 Projection(this Vector2 point, Vector3 start, Vector3 end)
		{
			Vector3 vec = end - start;
			float xx = Mathf.Pow(vec.x, 2f);
			float yy = Mathf.Pow(vec.y, 2f);
			float denominator = xx + yy;
			if(denominator == 0)
				return point;

			float xy = vec.x * vec.y;
			//float moleculey = yy * 
			return new Vector2(xx, xy);
		}

		public static Vector2 Projection(this Vector2 point, Vector2 start, Vector2 end)
		{
			Vector2 ab = end - start;
			Vector2 ap = point - start;
			return start + ab * Vector2.Dot(ap, ab) / ab.sqrMagnitude;
		}

		/// <summary>
		/// 矢量正交化
		/// </summary>
		/// <param name="vec"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Orthogonalization(this Vector2 vec)
			=> new Vector2(
			(float)Math.Round(vec.x),
			(float)Math.Round(vec.y)
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Min(this Vector2 a, Vector2 b)
		{
			return new Vector2(Math.Min(a.x, b.x), Math.Min(a.y, b.y));
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Max(this Vector2 a, Vector2 b)
		{
			return new Vector2(Math.Max(a.x, b.x), Math.Max(a.y, b.y));
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float MinElement(this Vector2 a)
		{
			return Math.Min(a.x, a.y);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float MaxElement(this Vector2 a)
		{
			return Math.Max(a.x, a.y);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Abs(this Vector2 a)
		{
			return new Vector2(Math.Abs(a.x), Math.Abs(a.y));
		}
		/// <summary>
		/// 获取矢量各轴符号
		/// </summary>
		/// <param name="vec"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Sign(this Vector2 vec)
			=> new Vector2(
			Math.Sign(vec.x),
			Math.Sign(vec.y)
			);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Cross(this Vector2 lhs, Vector2 rhs)
			=> lhs.x * rhs.y - rhs.x * lhs.y;

		/// <summary>
		/// 延斜线对齐一个点
		/// </summary>
		/// <param name="point"></param>
		/// <param name=""></param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 ObliqueAlign(this Vector2 point, Vector2 constPoint, out float exec)
		{
			float b1 = point.y - point.x, b2 = constPoint.y - constPoint.x;
			float dt = b1 + (b2 - b1);
			exec = dt * MacroMath.Sqrt22;
			Vector2 ab = constPoint - point;
			bool cool = ab.x * ab.y < 0;
			return exec * (cool ? Vector2.one : new Vector2(-1, 1));
		}

	}
}
