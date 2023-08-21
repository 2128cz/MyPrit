#define _HIGHQUALITYRANDOM_

using Library.Macro;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;

namespace Library.Type
{
    /// <summary>
    /// 弱类型基础
    /// </summary>
    [Serializable]
    public class WeaklyObjectBase : WeaklyObject
	{
		#region 字段

		/// <summary>
		/// 上次操作时的时间标记
		/// </summary>
		private static DateTime lastDate = DateTime.Now;

		/// <summary>
		/// 上次操作时的时间标记
		/// </summary>
		private static ulong lastTime = 0;

		/// <summary>
		/// 同一时间中诞生计数, 使用ulong只是为了不转换，但实际上范围只在short以内，超出了其实也没事，就是有可能发生索引重复
		/// </summary>
		private static ulong sameCount = 0;

		/// <summary>
		/// 序列后缀
		/// </summary>
		[SerializeField] 
		private ulong suffixIndex = 0;

		/// <summary>
		/// 序列哈希
		/// </summary>
		[SerializeField] 
		private string suffixHash;

		/// <summary>
		/// 后缀索引
		/// </summary>
		public ulong SuffixIndex => suffixIndex;

		/// <summary>
		/// 后缀名称
		/// </summary>
		public string SuffixHash => suffixHash;

		/// <summary>
		/// 实例编号
		/// </summary>
		private static ulong InstanceCounters
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if(lastDate.ToString() != DateTime.Now.ToString())
				{
					lastDate = DateTime.Now;
					lastTime = 0;
					string now = DateTime.Now.ToString();
					for(int i = 0; i < now.Length; i++)
					{
						lastTime ^= (ulong)now[i] << (56 - (int)((float)i / now.Length * 63));
#if _HIGHQUALITYRANDOM_
						MacroMath.RandomNumber(lastTime);
#endif
					}
					sameCount = 0;
				}
				return sameCount++ + MacroMath.RandomNumber(lastTime);
			}
		}

		#endregion

		#region 构造

		/// <summary>
		/// 注意不要在类字段中直接初始化，会导致种子时间不变
		/// </summary>
		public WeaklyObjectBase()
		{
			InitWeaklyObjectIndex();
		}

		#endregion

		#region 方法 

		public void InitWeaklyObjectIndex()
		{
			suffixIndex = InstanceCounters;
			suffixHash = MacroMath.MurmurFinalize(suffixIndex).ToString("X");
		}

		#endregion

		

	}
}