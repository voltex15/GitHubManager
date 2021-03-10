using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GitHubManager.Data
{
    public class Commit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommitId { get; set; }

        [Required]
        [MaxLength(256)]
        public string User { get; set; }

        [Required]
        [MaxLength(256)]
        public string Repository { get; set; }

        [Required]
        [MaxLength(2048)]
        public string Sha { get; set; }

        [MaxLength(2048)]
        public string Message { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Committer { get; set; }
    }
}
