using UnityEngine;
using UnityEditor;

namespace Agava.IdleGame
{
	public static class StackableLayerMaskExtention
	{
#if UNITY_EDITOR
		public static int LayerMaskField(string label, int layermask)
		{
			return FieldToLayerMask(EditorGUILayout.MaskField(label, LayerMaskToField(layermask),
				StackableLayerMask.Layers));
		}

		public static int LayerMaskField(Rect position, string label, int layermask)
		{
			return FieldToLayerMask(EditorGUI.MaskField(position, label, LayerMaskToField(layermask),
				StackableLayerMask.Layers));
		}

		/// <summary>
		/// Converts field LayerMask values to in game LayerMask values
		/// </summary>
		/// <param name="field"></param>
		/// <returns></returns>
		private static int FieldToLayerMask(int field)
		{
			if (field == -1)
				return -1;

			int mask = 0;
			var layers = StackableLayerMask.Layers;
			for (int index = 0; index < layers.Length; index++)
			{
				if ((field & (1 << index)) != 0)
					mask |= 1 << StackableLayerMask.NameToLayer(layers[index]);
				else
					mask &= ~(1 << StackableLayerMask.NameToLayer(layers[index]));
			}

			return mask;
		}

		/// <summary>
		/// Converts in game LayerMask values to field LayerMask values
		/// </summary>
		/// <param name="mask"></param>
		/// <returns></returns>
		private static int LayerMaskToField(int mask)
		{
			if (mask == -1)
				return -1;

			int field = 0;
			var layers = StackableLayerMask.Layers;
			for (int index = 0; index < layers.Length; index++)
				if ((mask & (1 << StackableLayerMask.NameToLayer(layers[index]))) != 0)
					field |= 1 << index;

			return field;
		}
#endif
	}
}