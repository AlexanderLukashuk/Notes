using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notes.Infrastructure;

namespace Notes.Tests.Common
{
    public class TestCommandBase : IDisposable
    {
        protected readonly NotesDbContext Context;

        public TestCommandBase()
        {
            Context = NotesContextFactory.Create();
        }

        public void Dispose()
        {
            NotesContextFactory.Destroy(Context);
        }
    }
}