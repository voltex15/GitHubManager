using GitHubManager.Data;
using GitHubManager.Libraries.Validator;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubManager.Models
{
	class CommitModel
	{
        public void SaveToDatabase(Commit commit)
        {
            using (var context = new ApplicationDbContext())
            {
                var commitTmp = new Commit()
                {
                    User = commit.User,
                    Repository = commit.Repository,
                    Sha = commit.Sha,
                    Message = commit.Message,
                    Committer = commit.Committer,
            };

            IValidator valid = new ValidatorCommit(commitTmp);

            if (valid.Validate() == true)
            {
                context.Commits.Add(commitTmp);
                context.SaveChanges();
            }
            else
            {
            }
        }
    }
}
}
