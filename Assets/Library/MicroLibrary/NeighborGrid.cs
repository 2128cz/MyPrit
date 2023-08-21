using Library.Type;

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;

namespace Library.Macro
{
	/// <summary>
	/// �ٽ�����
	/// </summary>
	public class NeighborGrid<T> : WeaklyObject
	{
		#region �ֶ�����

		private Vector3 position;
		private Vector3 cellSize;
		private Vector3Int numCells;
		private int maxNeighbor = 8;


		public Vector3 Position
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => position;
		}
		public Vector3 CellSize
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => cellSize;
		}
		public Vector3Int NumCells
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => numCells;
		}


		internal System.Random random = new System.Random();
		private int NeighborRandomIndex
		{
			get => random.Next(maxNeighbor);
		}

		/// <summary>
		/// ����ϵͳ�洢��
		/// </summary>
		private Dictionary<int, List<T>> grid = new Dictionary<int, List<T>>();

		/// <summary>
		/// ������ܳߴ�
		/// </summary>
		public Vector3 Fullsize
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => cellSize.Mul(numCells);
		}

		/// <summary>
		/// ������ϵͳתΪ���巶Χ
		/// </summary>
		public Bounds GridBounds
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => new Bounds(position, Fullsize / 2);
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				position = value.center;
				cellSize = (value.size * 2).Div(numCells);
			}
		}

		#endregion

		#region ����

		public NeighborGrid(Vector3 position, Vector3 cellSize, Vector3Int numCells, int maxNeighbor = 8)
		{
			this.position = position;
			this.cellSize = cellSize;
			this.numCells = Vector3Int.Max(numCells, Vector3Int.one);// ����������Ϊ��
			this.maxNeighbor = maxNeighbor;
		}

		#endregion



		#region �����任

		/// <summary>
		/// ����ռ�任Ϊ����ϵͳ��������ռ�
		/// </summary>
		/// <param name="world">��Ŀ������ռ�����</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 WorldToSimulation(Vector3 world)
			=> world - (position - (Fullsize / 2));
		/// <summary>
		/// ����ϵͳ��������ռ�任Ϊ����ռ�
		/// </summary>
		/// <param name="world">��Ŀ������ռ�����</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 SimulationToWorld(Vector3 simulation)
			=> simulation + (position - (Fullsize / 2));


		/// <summary>
		/// ����ϵͳ��������ռ�תΪ����ϵͳ���ص�λ�ռ�
		/// </summary>
		/// <param name="simulation">����ϵͳ��������ռ�</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 SimulationToUnit(Vector3 simulation)
			=> simulation.Div(Fullsize);
		/// <summary>
		/// ����ϵͳ��������ռ�תΪ����ϵͳ���ص�λ�ռ�
		/// </summary>
		/// <param name="simulation">����ϵͳ��������ռ�</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 UnitToSimulation(Vector3 unit)
			=> unit.Mul(Fullsize);


		/// <summary>
		/// ����ϵͳ���ص�λ�ռ�תΪ��ά����
		/// </summary>
		/// <param name="unit">����ϵͳ���ص�λ�ռ�</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3Int UnitToIndex(Vector3 unit)
			=> unit.IsInUnit() ? unit.Mul(numCells).FloorToInt() : MacroMath.Vector3Int_Negate;
		/// <summary>
		/// ��ά����תΪ����ϵͳ���ص�λ�ռ�
		/// </summary>
		/// <param name="index">��ά����</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 IndexToUnit(Vector3Int index)
			=> index.IsValid() ? (Vector3)index.Div(numCells) : MacroMath.Vector3Int_Negate;


		/// <summary>
		/// ����ϵͳ���ص�λ�ռ�תΪ��������
		/// </summary>
		/// <param name="unit">����ϵͳ��������ռ�</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int UnitToLinear(Vector3 unit)
		{
			if(unit.IsInUnit())
			{
				return IndexToLinear(UnitToIndex(unit));
			}
			return -1;
		}
		/// <summary>
		/// ��ά����תΪ��������
		/// </summary>
		/// <param name="index">��ά����</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int IndexToLinear(Vector3Int index)
		{
			if(index.IsValid() && index.IsInIndexRange(numCells))
			{
				return (int)(index.x +
				(index.y * numCells.x) +
				(index.z * numCells.y * numCells.x));
			}
			return -1;
		}
		/// <summary>
		/// ��������������ȡ����������ƫ����
		/// </summary>
		/// <param name="linear">��������</param>
		/// <param name="side">�߳�</param>
		/// <returns></returns>
		public Vector3Int LinearToGridIndex(int linear, int side)
		{
			return new Vector3Int(linear % side, linear / side, linear / side.Quad());
		}
		/// <summary>
		/// ��������תΪ��ά����
		/// </summary>
		/// <param name="linear">��������</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3Int LinearToIndex(int linear)
		{
			int zz = linear / (numCells.x * numCells.y);
			int yy = (linear - zz) / numCells.x;
			int xx = linear - yy - zz;
			return new Vector3Int(xx, yy, zz);
		}
		/// <summary>
		/// ��������תΪ��ά����
		/// </summary>
		/// <param name="linear">��������</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 LinearToUnit(int linear)
		{
			return IndexToUnit(LinearToIndex(linear));
		}

		#endregion

		#region ��ɾ��

		/// <summary>
		/// �������
		/// </summary>
		public void Clean()
		{
			grid.Clear();
		}

		/// <summary>
		/// �ڸ������������һ����Ŀ
		/// </summary>
		/// <param name="linear">����</param>
		/// <returns>�����Ƿ���ӳɹ�</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Insert(int linear, T obj)
		{
			if(grid.ContainsKey(linear))
			{
				int index = grid[linear].IndexOf(obj);
				if(index < 0)
				{
					grid[linear].Add(obj);
					return true;
				}
				return false;
			}
			else
			{
				grid.Add(linear, new List<T> { obj });
				return true;
			}
		}

		/// <summary>
		/// �Ƴ���������������Ŀ
		/// </summary>
		/// <param name="linear">����</param>
		/// <param name="obj">��Ŀ</param>
		/// <returns>�����Ƿ��Ƴ��ɹ�</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Remove(int linear, T obj)
		{
			if(grid.ContainsKey(linear))
			{
				bool resualt = grid[linear].Remove(obj);
				if(grid[linear].Count <= 0)
					grid.Remove(linear);
				return resualt;
			}
			return false;
		}
		/// <summary>
		/// �Ƴ�����������������Ŀ
		/// </summary>
		/// <param name="linear">����</param>
		/// <returns>�����Ƿ��Ƴ��ɹ�</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Remove(int linear)
		{
			if(grid[linear] is not null)
			{
				grid[linear].Clear();
			}
		}

		/// <summary>
		/// ��ѯ�����������Ƿ������Ŀ
		/// </summary>
		/// <param name="linear">����</param>
		/// <param name="obj">��Ŀ</param>
		/// <returns>������Ŀ�Ƿ����</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(int linear, T obj)
		{
			if(grid[linear] is not null)
			{
				return grid[linear].Contains(obj);
			}
			return false;
		}

		/// <summary>
		/// �������ƻ�ȡ���е��ھ�
		/// <code>
		/// ���棺Ǳ�ڵĸ����ܿ���
		/// </code>
		/// </summary>
		/// <param name="linear"></param>
		/// <returns></returns>
		public List<T> GetAllNeighbor(int linear)
		{
			return grid[linear];
		}

		/// <summary>
		/// ��ȡ����Χ�ڵ��ھ�
		/// </summary>
		/// <param name="linear">����λ�õ�����</param>
		/// <returns></returns>
		public IEnumerable<T> GetNeighbor(int linear)
		{
			int startIndex = NeighborRandomIndex;
			int count = grid[linear].Count;
			for(int i = 0; i < maxNeighbor; i++)
			{
				yield return grid[linear][(startIndex + i) % count];
			}
		}

		/// <summary>
		/// ��ȡ�뾶������������ھ�
		/// </summary>
		/// <param name="linear">����λ�õ�����</param>
		/// <param name="range">���ķ�Χ</param>
		/// <returns></returns>
		public IEnumerable<T> GetNeighbor(int linear, int radius)
		{
			int side = radius * 2 + 1;
			int length = side.Cubic();
			Vector3Int index = LinearToIndex(linear);
			index = index.Sub(radius);

			for(int i = 0; i < length; i++)
			{
				var neighbor = GetNeighbor(IndexToLinear(index +
					LinearToGridIndex(i, side)))
						.GetEnumerator();
				while(neighbor.MoveNext())
				{
					yield return neighbor.Current;
				}
			}
		}

		#endregion
	}
}
