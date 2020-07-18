namespace EFDemo.Services
{
    using System;
    using System.Threading.Tasks;
    using Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Repositories;

    public class HoAMemberService
    {
        public HoAMemberRepository Repo { get; set; }

        public async Task<HoAMember> Create(HoAMember member)
        {
            if(member.First == "Steve" && member.Last == "Karlsburg")
                throw new ArgumentException("GET OUT OF HERE STEVE");

            var product = await Repo.Create(member);
            return product;
        }

        public async Task<HoAMember> Read(string id)
        {
            var product = await Repo.Read(id);
            return product;
        }
    }
}
