using System;
using System.Collections.Generic;
using UBS;
using UnityEditor;

namespace UBS
{
	[BuildStepDescriptionAttribute("Adds a compiler flag to your build.")]
	public class AddCompilerFlag : IBuildStepProvider
	{
		
		#region IBuildStepProvider implementation
		
		public void BuildStepStart (BuildConfiguration pConfiguration)
		{
			BuildTargetGroup btg = UBS.Helpers.GroupFromBuildTarget( pConfiguration.GetCurrentBuildProcess().mPlatform );
			string symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(btg);
			List<string> symbolsArray = new List<string>(symbols.Split(';'));

			if(!symbolsArray.Contains(pConfiguration.Params))
				symbolsArray.Add(pConfiguration.Params);
			symbols = string.Join(";", symbolsArray.ToArray());

			PlayerSettings.SetScriptingDefineSymbolsForGroup(btg, symbols);
		}
		
		public void BuildStepUpdate ()
		{
			
		}
		
		public bool IsBuildStepDone ()
		{
			return true;
		}
		
		#endregion
	}

}