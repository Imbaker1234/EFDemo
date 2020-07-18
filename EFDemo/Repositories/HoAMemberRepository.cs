namespace EFDemo.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Controllers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Storage;

    public class HoAMemberRepository
    {
        public HoADbContext DbContext { get; set; }

        public async Task<HoAMember> Create(HoAMember member)
        {
            //Open a transaction. A line of communication to the database.
            IDbContextTransaction transaction = await DbContext.Database.BeginTransactionAsync();
            try
            {
                await DbContext.AddAsync(member);
                await DbContext.SaveChangesAsync();
                transaction.Commit();
            }
            finally
            {
                if (transaction != null)
                    await transaction.DisposeAsync();
            }

            HoAMember obj = await this.Read(member.Id);
            HoAMember product = obj;
            obj = default;
            return product;
        }

        public async Task<HoAMember> Read(string id)
        {
            // //APPROACH 1 - Bad
            // var list = DbContext.Set<HoAMember>().ToList(); //SELECT * FROM Clowncar;
            // var karlsburgAccounts = list.Where(unit => unit.Last == "Karlsburg");
            //
            // //APPROACH 2 - Good
            // var queryable = DbContext.Set<HoAMember>().AsQueryable(); //SELECT * FROM Clowncar;
            // var karlsburgAccountsQuery =
            //     queryable.Where(unit => unit.Last == "Karlsburg"); //WHERE Last = 'Karlsburg';
            // var karlsburgAccountsExecuted = karlsburgAccountsQuery.ToList();

            //Assuming id is 414141
            //SELECT TOP 1 * FROM Clowncar WHERE Id == '414141'

            var product =
                await DbContext.Set<HoAMember>().SingleOrDefaultAsync(member => member.Id == id);

            if(product is null) throw new Exception("Didn't find it bruh.");

            return product;
        }
    }
}
