using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;


namespace Library.Macro
{
    public static class NeighborGridExtend 
    {
		/// <summary>
		/// 世界空间变换为网格系统本地坐标空间
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="world"></param>
		/// <param name="grid">网格目标</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 WorldToSimulation<T>(this Vector3 world, NeighborGrid<T> grid)
			=> grid.WorldToSimulation(world);
		/// <summary>
		/// 网格系统本地坐标空间变换为世界空间
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="simulation"></param>
		/// <param name="grid">网格目标</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 SimulationToWorld<T>(this Vector3 simulation, NeighborGrid<T> grid)
			=> grid.SimulationToWorld(simulation);


		/// <summary>
		/// 网格系统本地坐标空间转为网格系统本地单位空间
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="simulation"></param>
		/// <param name="grid">网格目标</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 SimulationToUnit<T>(this Vector3 simulation, NeighborGrid<T> grid)
			=> grid.SimulationToUnit(simulation);
		/// <summary>
		/// 网格系统本地坐标空间转为网格系统本地单位空间
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="unit"></param>
		/// <param name="grid">网格目标</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 UnitToSimulation<T>(this Vector3 unit, NeighborGrid<T> grid)
			=> grid.UnitToSimulation(unit);


		/// <summary>
		/// 网格系统本地单位空间转为三维索引
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="unit"></param>
		/// <param name="grid">网格目标</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int UnitToIndex<T>(this Vector3 unit, NeighborGrid<T> grid)
			=> grid.UnitToIndex(unit);
		/// <summary>
		/// 三维索引转为网格系统本地单位空间
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="index"></param>
		/// <param name="grid">网格目标</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 IndexToUnit<T>(this Vector3Int index, NeighborGrid<T> grid)
			=> grid.IndexToUnit(index);


		/// <summary>
		/// 网格系统本地单位空间转为线性索引
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="unit">网格系统本地坐标空间</param>
		/// <param name="grid">网格目标</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int UnitToLinear<T>(this Vector3 unit, NeighborGrid<T> grid)
			=> grid.UnitToLinear(unit);
		/// <summary>
		/// 三维索引转为线性索引
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="index">三维索引</param>
		/// <param name="grid">网格目标</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int IndexToLinear<T>(this Vector3Int index, NeighborGrid<T> grid)
			=> grid.IndexToLinear(index);
		/// <summary>
		/// 网格系统本地单位空间转为线性索引
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="unit">网格系统本地坐标空间</param>
		/// <param name="grid">网格目标</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int LinearToIndex<T>(this int Linear, NeighborGrid<T> grid)
			=> grid.LinearToIndex(Linear);
		/// <summary>
		/// 三维索引转为线性索引
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="index">三维索引</param>
		/// <param name="grid">网格目标</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 LinearToUnit<T>(this int Linear, NeighborGrid<T> grid)
			=> grid.LinearToUnit(Linear);


		/// <summary>
		/// 从世界坐标获取到索引
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="Linear"></param>
		/// <param name="grid"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int WorldToLinear<T>(this Vector3 Linear, NeighborGrid<T> grid)
			=> Linear.WorldToSimulation(grid).SimulationToUnit(grid).UnitToLinear(grid);
	}
}
