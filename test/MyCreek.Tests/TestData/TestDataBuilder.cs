using MyCreek.Entities;
using MyCreek.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCreek.Tests
{
    public class TestDataBuilder
    {
        private readonly MyCreekDbContext _context;

        public TestDataBuilder(MyCreekDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            var neo = new Person("Neo");
            _context.People.Add(neo);
            _context.SaveChanges();

            _context.Tasks.AddRange(
                new MyTask("Follow the white rabbit", "Follow the white rabbit in order to know the reality.",neo.Id),
                new MyTask("Clean your room") { State = TaskState.Completed }
                );
        }
    }
}
