using Library.Type;

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;

namespace Library.Macro
{
	/// <summary>
	/// 临近网络
	/// </summary>
	public class NeighborGrid<T> : WeaklyObject
	{
		#region 字段属性

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
		/// 网格系统存储地
		/// </summary>
		private Dictionary<int, List<T>> grid = new Dictionary<int, List<T>>();

		/// <summary>
		/// 网格的总尺寸
		/// </summary>
		public Vector3 Fullsize
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => cellSize.Mul(numCells);
		}

		/// <summary>
		/// 此网格系统转为盒体范围
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

		#region 构造

		public NeighborGrid(Vector3 position, Vector3 cellSize, Vector3Int numCells, int maxNeighbor = 8)
		{
			this.position = position;
			this.cellSize = cellSize;
			this.numCells = Vector3Int.Max(numCells, Vector3Int.one);// 不允许数量为零
			this.maxNeighbor = maxNeighbor;
		}

		#endregion



		#region 索引变换

		/// <summary>
		/// 世界空间变换为网格系统本地坐标空间
		/// </summary>
		/// <param name="world">项目的世界空间坐标</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 WorldToSimulation(Vector3 world)
			=> world - (position - (Fullsize / 2));
		/// <summary>
		/// 网格系统本地坐标空间变换为世界空间
		/// </summary>
		/// <param name="world">项目的世界空间坐标</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 SimulationToWorld(Vector3 simulation)
			=> simulation + (position - (Fullsize / 2));


		/// <summary>
		/// 网格系统本地坐标空间转为网格系统本地单位空间
		/// </summary>
		/// <param name="simulation">网格系统本地坐标空间</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 SimulationToUnit(Vector3 simulation)
			=> simulation.Div(Fullsize);
		/// <summary>
		/// 网格系统本地坐标空间转为网格系统本地单位空间
		/// </summary>
		/// <param name="simulation">网格系统本地坐标空间</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 UnitToSimulation(Vector3 unit)
			=> unit.Mul(Fullsize);


		/// <summary>
		/// 网格系统本地单位空间转为三维索引
		/// </summary>
		/// <param name="unit">网格系统本地单位空间</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3Int UnitToIndex(Vector3 unit)
			=> unit.IsInUnit() ? unit.Mul(numCells).FloorToInt() : MacroMath.Vector3Int_Negate;
		/// <summary>
		/// 三维索引转为网格系统本地单位空间
		/// </summary>
		/// <param name="index">三维索引</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 IndexToUnit(Vector3Int index)
			=> index.IsValid() ? (Vector3)index.Div(numCells) : MacroMath.Vector3Int_Negate;


		/// <summary>
		/// 网格系统本地单位空间转为线性索引
		/// </summary>
		/// <param name="unit">网格系统本地坐标空间</param>
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
		/// 三维索引转为线性索引
		/// </summary>
		/// <param name="index">三维索引</param>
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
		/// 根据线性索引获取网格中索引偏移量
		/// </summary>
		/// <param name="linear">线性索引</param>
		/// <param name="side">边长</param>
		/// <returns></returns>
		public Vector3Int LinearToGridIndex(int linear, int side)
		{
			return new Vector3Int(linear % side, linear / side, linear / side.Quad());
		}
		/// <summary>
		/// 线性索引转为三维索引
		/// </summary>
		/// <param name="linear">线性索引</param>
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
		/// 线性索引转为三维索引
		/// </summary>
		/// <param name="linear">线性索引</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 LinearToUnit(int linear)
		{
			return IndexToUnit(LinearToIndex(linear));
		}

		#endregion

		#region 增删查

		/// <summary>
		/// 清空网格
		/// </summary>
		public void Clean()
		{
			grid.Clear();
		}

		/// <summary>
		/// 在给定索引处添加一个项目
		/// </summary>
		/// <param name="linear">索引</param>
		/// <returns>返回是否添加成功</returns>
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
		/// 移除给定索引处的项目
		/// </summary>
		/// <param name="linear">索引</param>
		/// <param name="obj">项目</param>
		/// <returns>返回是否移除成功</returns>
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
		/// 移除给定索引下所有项目
		/// </summary>
		/// <param name="linear">索引</param>
		/// <returns>返回是否移除成功</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Remove(int linear)
		{
			if(grid[linear] is not null)
			{
				grid[linear].Clear();
			}
		}

		/// <summary>
		/// 查询给定索引处是否存在项目
		/// </summary>
		/// <param name="linear">索引</param>
		/// <param name="obj">项目</param>
		/// <returns>返回项目是否存在</returns>
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
		/// 忽略限制获取所有的邻居
		/// <code>
		/// 警告：潜在的高性能开销
		/// </code>
		/// </summary>
		/// <param name="linear"></param>
		/// <returns></returns>
		public List<T> GetAllNeighbor(int linear)
		{
			return grid[linear];
		}

		/// <summary>
		/// 获取允许范围内的邻居
		/// </summary>
		/// <param name="linear">所在位置的索引</param>
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
		/// 获取半径内所有允许的邻居
		/// </summary>
		/// <param name="linear">所在位置的索引</param>
		/// <param name="range">检查的范围</param>
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
