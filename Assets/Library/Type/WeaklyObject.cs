using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Library.Type
{
    public class WeaklyObject
    {
		#region ����

		public static implicit operator bool(WeaklyObject obj) => obj != null;

		#endregion
	}
}