using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;

public class EditorFont : Editor
{
	[MenuItem("Assets/Load Font Settings...")]
	static void LoadFontSettings()
	{
		if (Selection.activeObject.GetType() == typeof(Font))
		{
			Font font = Selection.activeObject as Font;
			string path = EditorUtility.OpenFilePanel("Read", "", "txt");
			string[] lines = File.ReadAllLines(path);
			
			var info = new CharacterInfo[lines.Length];
			
			for (int i = 0; i < lines.Length; i++)
			{
				string[] v = lines[i].Split(',');
				info[i].index = int.Parse(v[0]);
				info[i].uv.x = float.Parse(v[1]);
				info[i].uv.y = float.Parse(v[2]);
				info[i].uv.width = float.Parse(v[3]);
				info[i].uv.height = float.Parse(v[4]);
				info[i].vert.x = float.Parse(v[5]);
				info[i].vert.y = float.Parse(v[6]);
				info[i].vert.width = float.Parse(v[7]);
				info[i].vert.height = float.Parse(v[8]);
				info[i].width = info[i].vert.width;
			}
			
			
			font.characterInfo = info;
			EditorUtility.SetDirty(font);
		}
	}
}
