using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubManager.Builder
{
	class Director
	{
		private IBuilder _builder;

		public Director(IBuilder builder)
		{
			this._builder = builder;
		}

		public IDictionary<string, string> BuildCommitJson()
		{
			return this._builder.Build();
		}
	}
}
