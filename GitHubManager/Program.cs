using GitHubManager.Builder;
using GitHubManager.Data;
using GitHubManager.Libraries.RestApi;
using GitHubManager.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace GitHubManager
{
	class Program
	{
		static void Main(string[] args)
		{
            do
            {
                Console.WriteLine("*** GitHub Manager ***");

                string user = GetUserFromConsole();
                string repository = GetRepositoryFromConsole();

                var api = new CommitApi();
                string result = api.GetResponse(user, repository);

                try
                {
                    JArray resultArray = JArray.Parse(result);

                    foreach (JObject commit in resultArray)
                    {
                        IBuilder builder = new CommitBuilder(commit);
                        Director director = new Director(builder);

                        var commitJson = builder.Build();
                        string commitConsoleLine = GetOneCommitLine(repository, commitJson);

						Commit commitToDatabase = new Commit
						{
							User = user,
							Repository = repository,
							Sha = commitJson["sha"],
							Message = commitJson["message"],
                            Committer = commitJson["committerName"]
                        };

                        try
                        {
                            CommitModel model = new CommitModel();
                            model.SaveToDatabase(commitToDatabase);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error 002: Database write error.");
                        }

                        Console.WriteLine(commitConsoleLine);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error 001: Bad request. Try Again.");
                }
            }
            while (true);
        }

        public static string GetOneCommitLine(string repository, IDictionary<string, string> commit)
        {
            return repository + "/" + commit["sha"] + ": " + commit["message"] + " [" + commit["committerName"] + "]";
        }

        public static string GetUserFromConsole()
        {
            Console.Write("User: ");
            string user = Console.ReadLine();
            return user;
        }

        public static string GetRepositoryFromConsole()
        {
            Console.Write("Repository: ");
            string repository = Console.ReadLine();
            return repository;
        }

    }
}
