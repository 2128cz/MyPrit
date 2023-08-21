using Library.Type;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Library.Grometry
{

	[ExecuteInEditMode]
	public class PolyBase : WeaklyMonoBase
	{
		private void Start()
		{
			// ����һ���µ�Mesh
			Mesh mesh = new Mesh();

			// ����ģ�͵Ķ�������
			Vector3[] vertices = new Vector3[]
			{
			new Vector3(0, 0, 0),  // ����0
            new Vector3(1, 0, 0),  // ����1
            new Vector3(1, 1, 0),  // ����2
            new Vector3(0, 1, 0),  // ����3
            new Vector3(0, 0, 1),  // ����4
            new Vector3(1, 0, 1),  // ����5
            new Vector3(1, 1, 1),  // ����6
            new Vector3(0, 1, 1)   // ����7
			};

			// ����ģ�͵�����������
			int[] triangles = new int[]
			{
            // ǰ��
            0, 2, 1,
			0, 3, 2,
            // ����
            5, 6, 4,
			6, 5, 7,
            // ����
            4, 2, 0,
			2, 4, 6,
            // ����
            1, 7, 5,
			7, 1, 3,
            // ����
            3, 6, 2,
			3, 7, 6,
            // ����
            0, 5, 1,
			0, 4, 5
			};

			// ����ģ�͵Ķ����������
			mesh.vertices = vertices;
			mesh.triangles = triangles;
			

			// ����һ���µ�GameObject
			GameObject cube = new GameObject("Cube");

			// ���MeshFilter�������Mesh��ֵ
			MeshFilter meshFilter = cube.AddComponent<MeshFilter>();
			meshFilter.mesh = mesh;

			// ���MeshRenderer���
			MeshRenderer meshRenderer = cube.AddComponent<MeshRenderer>();
		}

		#region ��̬����

		public GameObject CreatNewPolyMesh(out MeshFilter meshFilter, string name = "PolyMesh")
		{
			GameObject obj = new GameObject(name);
			meshFilter = obj.AddComponent<MeshFilter>();
			MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();
			return obj;
		}

		#endregion

		#region ����


		#endregion
	}
}
