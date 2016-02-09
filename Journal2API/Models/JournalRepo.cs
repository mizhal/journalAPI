using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Journal2API.Models
{
    public class JournalRepo : IRepo,
        ICrudRepoParanoidFor<Quest>,
        ICrudRepoParanoidFor<TodoItem>,
        ICommentableRepo<Quest>,
        ICommentableRepo<TodoItem>,
        ISortableRepo<Quest>,
        ISortableRepo<TodoItem>,
        INestableRepo<TodoItem>
    {
        private JournalContext Context;

        public JournalRepo()
        {
            Context = new JournalContext();
        }

        public DbContext CurrentContext()
        {
            return Context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void Flush()
        {
            Context.Dispose();
            Context = new JournalContext();
        }

        ~JournalRepo()
        {
            Dispose();
        }
    }
}