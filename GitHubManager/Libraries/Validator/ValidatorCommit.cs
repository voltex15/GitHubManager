using GitHubManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitHubManager.Libraries.Validator
{
    public class ValidatorCommit : IValidator
    {
        private Commit _commit;

        public ValidatorCommit(Commit commit)
        {
            this._commit = commit;
        }

        private bool CheckExistingInDatabase()
        {
            using (var context = new ApplicationDbContext())
            {
                if (context.Commits.Any(q => q.Sha == this._commit.Sha))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool Validate()
        {
            if (!this.CheckExistingInDatabase())
            {
                return false;
            }

            return true;
        }
    }
}
