using Journal2API.Models.Auth;
using System.Data.Entity;
using System;

namespace Journal2API.Models
{
    public class JournalRepo : IRepo,
        ICrudRepoParanoidFor<Quest>,
        ICrudRepoParanoidFor<TodoItem>,
        ICrudRepoParanoidFor<Workflow>,
        ICrudRepoParanoidFor<WorkflowState>,
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

        public bool ValidateUser(string client_id, string client_secret)
        {
            return client_id.Equals("admin") && client_secret.Equals("admin"); 
        }
    }
}