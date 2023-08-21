using Library.Macro;
using Library.Type;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Library.Grometry
{
	/// <summary>
	/// �Զ��������
	/// </summary>
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	public class PolygComponent : WeaklyMonoBase
	{
		#region �ֶ�

		/// <summary>
		/// ģ��¼�����
		/// </summary>
		protected MeshFilter meshFilter;

		/// <summary>
		/// ģ����Ⱦ���
		/// </summary>

		protected MeshRenderer meshRenderer;

		#endregion

		#region ��������

		protected void Awake()
		{
			InitializationComponentQuote();
		}

		#endregion

		#region ����

		/// <summary>
		/// ��ʼ���������
		/// </summary>
		private void InitializationComponentQuote()
		{
			meshFilter = gameObject.GetComponentAnyway<MeshFilter>();
			meshRenderer = gameObject.GetComponentAnyway<MeshRenderer>();
		}


		#endregion
	}
}
