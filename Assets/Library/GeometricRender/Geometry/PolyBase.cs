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
			// 创建一个新的Mesh
			Mesh mesh = new Mesh();

			// 定义模型的顶点坐标
			Vector3[] vertices = new Vector3[]
			{
			new Vector3(0, 0, 0),  // 顶点0
            new Vector3(1, 0, 0),  // 顶点1
            new Vector3(1, 1, 0),  // 顶点2
            new Vector3(0, 1, 0),  // 顶点3
            new Vector3(0, 0, 1),  // 顶点4
            new Vector3(1, 0, 1),  // 顶点5
            new Vector3(1, 1, 1),  // 顶点6
            new Vector3(0, 1, 1)   // 顶点7
			};

			// 定义模型的三角面索引
			int[] triangles = new int[]
			{
            // 前面
            0, 2, 1,
			0, 3, 2,
            // 后面
            5, 6, 4,
			6, 5, 7,
            // 左面
            4, 2, 0,
			2, 4, 6,
            // 右面
            1, 7, 5,
			7, 1, 3,
            // 顶面
            3, 6, 2,
			3, 7, 6,
            // 底面
            0, 5, 1,
			0, 4, 5
			};

			// 设置模型的顶点和三角面
			mesh.vertices = vertices;
			mesh.triangles = triangles;
			

			// 创建一个新的GameObject
			GameObject cube = new GameObject("Cube");

			// 添加MeshFilter组件并将Mesh赋值
			MeshFilter meshFilter = cube.AddComponent<MeshFilter>();
			meshFilter.mesh = mesh;

			// 添加MeshRenderer组件
			MeshRenderer meshRenderer = cube.AddComponent<MeshRenderer>();
		}

		#region 静态方法

		public GameObject CreatNewPolyMesh(out MeshFilter meshFilter, string name = "PolyMesh")
		{
			GameObject obj = new GameObject(name);
			meshFilter = obj.AddComponent<MeshFilter>();
			MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();
			return obj;
		}

		#endregion

		#region 方法


		#endregion
	}
}
