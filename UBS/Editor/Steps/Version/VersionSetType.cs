using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UBS.Version
{
	[BuildStepDescriptionAttribute("Sets the Version type to final or beta. Provide a parameter 'final' to set the version type to final. ")]
	[BuildStepParameterFilterAttribute(EBuildStepParameterType.String)]
	public class SetType : IBuildStepProvider
	{
		#region IBuildStepProvider implementation

		public void BuildStepStart(BuildConfiguration pConfiguration)
		{
			var collection = pConfiguration.GetCurrentBuildCollection();
			List<string> parameters = new List<string>(pConfiguration.Params.Split(';'));

			if(parameters.Contains("final"))
				collection.version.type = BuildVersion.BuildType.final;
			else
				collection.version.type = BuildVersion.BuildType.beta;

			collection.SaveVersion();
		}

		public void BuildStepUpdate()
		{

		}

		public bool IsBuildStepDone()
		{
			return true;
		}

		#endregion


	}
}

