// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEditor;
using UnityEngine;

namespace UBS
{
	public class UBSBuildWindow : EditorWindow
	{
		const float kHeight = 25;

		[NonSerialized]
		UBSProcess mProcess;

		[NonSerialized]
		bool mInit;

		[NonSerialized]
		bool mEmpty = false;

		public static void Init(BuildCollection pData)
		{
			var window = EditorWindow.GetWindow<UBSBuildWindow>(true,"Build",true);

			window.position = new Rect(50,50, 300,300);
			window.minSize = new Vector2(310,260);
			window.maxSize = new Vector2(310,260);
			window.Run(pData);
		}


		public void Run(BuildCollection pCollection)
		{
			UBSProcess.Create(pCollection);
		}

		void Initialize()
		{
			mProcess = UBSProcess.LoadUBSProcess();
			if(mProcess == null)
			{
				mEmpty = true;
				mInit = true;
			}else
			{
				EditorApplication.update -= OnUpdate;
				EditorApplication.update += OnUpdate;
			}
		}

		void OnUpdate()
		{
			//Debug.Log("Update");

			if(mProcess == null)
			{
				EditorApplication.update -= OnUpdate;
				mEmpty = true;
			}


			try
			{
				mProcess.MoveNext();
			}catch (Exception e)
			{
				Debug.LogException(e);
				EditorApplication.update -= OnUpdate;
				return;
			}

			Repaint();
		}
		void OnDestroy()
		{
			EditorApplication.update -= OnUpdate;
		}
		void OnDisable()
		{
			EditorApplication.update -= OnUpdate;
		}
		void OnGUI()
		{


			if(!mInit)
			{
				Initialize();
			}

			if(mEmpty)
			{
				// still no process existing?
				GUILayout.Label("Nothing to build", Styles.bigHint );
				return;
			}

			GUI.Box(new Rect(0,0,300,300), "");


			float fTop = 0;
			float fLeft = 5;
			GUI.BeginGroup(new Rect(fLeft,fTop, 300, kHeight));
			KeyValue( "Collection:", mProcess.BuildCollection.name );
			GUI.EndGroup();

			fTop += kHeight;
			GUI.BeginGroup(new Rect(fLeft,fTop, 300, kHeight));
			KeyValue( "CurrentProcess: ", mProcess.CurrentProcessName );
			GUI.EndGroup();

			fTop += kHeight;
			GUI.BeginGroup(new Rect(fLeft,fTop, 300, kHeight));
			KeyValue( "CurrentState: ", mProcess.CurrentState );
			GUI.EndGroup();


			fTop += kHeight;
			GUI.BeginGroup(new Rect(fLeft,fTop, 300, kHeight));
			KeyProgress( "Pre Steps Progress: ", mProcess.SubPreWalker.Progress );
			GUI.EndGroup();

			fTop += kHeight;
			GUI.BeginGroup(new Rect(fLeft,fTop, 300, kHeight));
			KeyValue( "Pre Step Current: ", mProcess.SubPreWalker.Step );
			GUI.EndGroup();
			
			fTop += kHeight;
			GUI.BeginGroup(new Rect(fLeft,fTop, 300, kHeight));
			KeyProgress( "Post Steps Progress: ", mProcess.SubPostWalker.Progress );
			GUI.EndGroup();
			
			fTop += kHeight;
			GUI.BeginGroup(new Rect(fLeft,fTop, 300, kHeight));
			KeyValue( "Post Step Current: ", mProcess.SubPostWalker.Step );
			GUI.EndGroup();

			fTop += kHeight;
			GUI.BeginGroup(new Rect(fLeft,fTop, 300, kHeight));
			KeyProgress( "Progress: ", mProcess.Progress );
			GUI.EndGroup();

			fTop += kHeight;
			GUILayout.BeginArea(new Rect(fLeft,fTop, 300, kHeight));
			if (UBSProcess.BuildBehavior == UBSBuildBehavior.manual && mProcess.CurrentState == UBSState.building) 
			{
				GUILayout.BeginVertical("Action");
				GUILayout.Label ("Buildpipeline not available in free Unity");
				if (GUILayout.Button(string.Format ("Build {0} manually", mProcess.CurrentProcessName)))
				{
					System.Reflection.Assembly asm = System.Reflection.Assembly.GetAssembly(typeof(EditorWindow));
					var M = asm
						.GetType("UnityEditor.BuildPlayerWindow")
						.GetMethod("ShowBuildPlayerWindow", System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Static);
					M.Invoke(null, null);
				}
				GUILayout.EndVertical();
			}
			GUILayout.EndArea();
		}


		void KeyValue(string pKey, object pValue)
		{
			GUI.Label(new Rect(0,0,140,25),pKey, Styles.boldKey);
			GUI.Label(new Rect(150,0,140,25),pValue.ToString(), Styles.normalValue);

		}


		void KeyProgress(string pKey, float pValue)
		{
			GUI.Label(new Rect(0,0,140,25),pKey, Styles.boldKey);
			EditorGUI.ProgressBar(new Rect(150,5, 140, 15), pValue, Mathf.RoundToInt(pValue * 100).ToString() + "%");
		}

	}
}

