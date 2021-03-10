using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GitHubManager.Builder
{
	class CommitBuilder : IBuilder
	{
		private JObject _json;

		private IDictionary<string, string> _commit = new Dictionary<string, string>();


		public CommitBuilder(JObject json)
		{
			this._json = json;
			this._commit = new Dictionary<string, string>();
		}

		private void AddSha()
		{
			string sha = _json["sha"].ToString();
			this._commit["sha"] = sha;
		}

		public void AddMessage()
		{
			string message = _json["commit"]["message"].ToString();
			this._commit["message"] = message;
		}

		public void AddCommitterName()
		{
			string committerName = _json["commit"]["committer"]["name"].ToString();
			this._commit["committerName"] = committerName;
		}

		public IDictionary<string, string> Build()
		{
			this.AddSha();
			this.AddMessage();
			this.AddCommitterName();
			return this._commit;
		}

	}
}
