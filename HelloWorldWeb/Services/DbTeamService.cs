using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Data;
using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public class DbTeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;

        public DbTeamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddTeamMemberAsync(Member member)
        {
            _context.Add(member);
            _context.SaveChanges();
        }

        public void DeleteTeamMember(Member member)
        {
            _context.Member.Remove(member);
            _context.SaveChanges();
        }

        public void EditTeamMember(int id, string name)
        {
            var member = _context.Member.Find(id);
            _context.Update(member);
            _context.SaveChanges();
        }

        public TeamInfo GetTeamInfo()
        {
            var memberList = _context.Member.ToList();
            TeamInfo teamInfo = new TeamInfo("Team2", memberList);
            return teamInfo;
        }
    }
}
