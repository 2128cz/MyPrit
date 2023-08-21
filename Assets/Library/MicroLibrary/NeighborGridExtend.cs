using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;


namespace Library.Macro
{
    public static class NeighborGridExtend 
    {
		/// <summary>
		/// ����ռ�任Ϊ����ϵͳ��������ռ�
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="world"></param>
		/// <param name="grid">����Ŀ��</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 WorldToSimulation<T>(this Vector3 world, NeighborGrid<T> grid)
			=> grid.WorldToSimulation(world);
		/// <summary>
		/// ����ϵͳ��������ռ�任Ϊ����ռ�
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="simulation"></param>
		/// <param name="grid">����Ŀ��</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 SimulationToWorld<T>(this Vector3 simulation, NeighborGrid<T> grid)
			=> grid.SimulationToWorld(simulation);


		/// <summary>
		/// ����ϵͳ��������ռ�תΪ����ϵͳ���ص�λ�ռ�
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="simulation"></param>
		/// <param name="grid">����Ŀ��</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 SimulationToUnit<T>(this Vector3 simulation, NeighborGrid<T> grid)
			=> grid.SimulationToUnit(simulation);
		/// <summary>
		/// ����ϵͳ��������ռ�תΪ����ϵͳ���ص�λ�ռ�
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="unit"></param>
		/// <param name="grid">����Ŀ��</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 UnitToSimulation<T>(this Vector3 unit, NeighborGrid<T> grid)
			=> grid.UnitToSimulation(unit);


		/// <summary>
		/// ����ϵͳ���ص�λ�ռ�תΪ��ά����
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="unit"></param>
		/// <param name="grid">����Ŀ��</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int UnitToIndex<T>(this Vector3 unit, NeighborGrid<T> grid)
			=> grid.UnitToIndex(unit);
		/// <summary>
		/// ��ά����תΪ����ϵͳ���ص�λ�ռ�
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="index"></param>
		/// <param name="grid">����Ŀ��</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 IndexToUnit<T>(this Vector3Int index, NeighborGrid<T> grid)
			=> grid.IndexToUnit(index);


		/// <summary>
		/// ����ϵͳ���ص�λ�ռ�תΪ��������
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="unit">����ϵͳ��������ռ�</param>
		/// <param name="grid">����Ŀ��</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int UnitToLinear<T>(this Vector3 unit, NeighborGrid<T> grid)
			=> grid.UnitToLinear(unit);
		/// <summary>
		/// ��ά����תΪ��������
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="index">��ά����</param>
		/// <param name="grid">����Ŀ��</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int IndexToLinear<T>(this Vector3Int index, NeighborGrid<T> grid)
			=> grid.IndexToLinear(index);
		/// <summary>
		/// ����ϵͳ���ص�λ�ռ�תΪ��������
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="unit">����ϵͳ��������ռ�</param>
		/// <param name="grid">����Ŀ��</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3Int LinearToIndex<T>(this int Linear, NeighborGrid<T> grid)
			=> grid.LinearToIndex(Linear);
		/// <summary>
		/// ��ά����תΪ��������
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="index">��ά����</param>
		/// <param name="grid">����Ŀ��</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 LinearToUnit<T>(this int Linear, NeighborGrid<T> grid)
			=> grid.LinearToUnit(Linear);


		/// <summary>
		/// �����������ȡ������
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
