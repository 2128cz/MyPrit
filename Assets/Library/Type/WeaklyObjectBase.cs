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
    /// �����ͻ���
    /// </summary>
    [Serializable]
    public class WeaklyObjectBase : WeaklyObject
	{
		#region �ֶ�

		/// <summary>
		/// �ϴβ���ʱ��ʱ����
		/// </summary>
		private static DateTime lastDate = DateTime.Now;

		/// <summary>
		/// �ϴβ���ʱ��ʱ����
		/// </summary>
		private static ulong lastTime = 0;

		/// <summary>
		/// ͬһʱ���е�������, ʹ��ulongֻ��Ϊ�˲�ת������ʵ���Ϸ�Χֻ��short���ڣ���������ʵҲû�£������п��ܷ��������ظ�
		/// </summary>
		private static ulong sameCount = 0;

		/// <summary>
		/// ���к�׺
		/// </summary>
		[SerializeField] 
		private ulong suffixIndex = 0;

		/// <summary>
		/// ���й�ϣ
		/// </summary>
		[SerializeField] 
		private string suffixHash;

		/// <summary>
		/// ��׺����
		/// </summary>
		public ulong SuffixIndex => suffixIndex;

		/// <summary>
		/// ��׺����
		/// </summary>
		public string SuffixHash => suffixHash;

		/// <summary>
		/// ʵ�����
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

		#region ����

		/// <summary>
		/// ע�ⲻҪ�����ֶ���ֱ�ӳ�ʼ�����ᵼ������ʱ�䲻��
		/// </summary>
		public WeaklyObjectBase()
		{
			InitWeaklyObjectIndex();
		}

		#endregion

		#region ���� 

		public void InitWeaklyObjectIndex()
		{
			suffixIndex = InstanceCounters;
			suffixHash = MacroMath.MurmurFinalize(suffixIndex).ToString("X");
		}

		#endregion

		

	}
}