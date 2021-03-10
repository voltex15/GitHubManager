using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubManager.Builder
{
	interface IBuilder
	{
		IDictionary<string, string> Build();
	}
}
