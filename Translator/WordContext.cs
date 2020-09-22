using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    class WordContext : DbContext
    {
        public WordContext()
            : base("DbConnection")
        { }
        public DbSet<Word> Words { get; set; }
    }
}
