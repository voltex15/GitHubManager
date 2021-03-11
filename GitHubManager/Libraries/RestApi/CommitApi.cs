using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace GitHubManager.Libraries.RestApi
{
	class CommitApi : RestApi
	{
        public string GetResponse(string user, string repository)
        {
            string url = string.Format(_baseUrl + "/repos/{0}/{1}/commits", user, repository);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")
            );
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

            HttpResponseMessage response = client.GetAsync(url).Result;

            string result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                result = response.StatusCode.ToString();
            }

            client.Dispose();

            return result;
        }
    }
}
