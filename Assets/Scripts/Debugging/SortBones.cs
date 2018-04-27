using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(BoneSorter))]

public class SortBones : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		BoneSorter sorter = (BoneSorter)target;
		if(GUILayout.Button("Sort Bones"))
		{
			sorter.OrderBones ();
		}
	}
}