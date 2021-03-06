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
        private readonly IBroadcastServices broadcastService;

        public DbTeamService(ApplicationDbContext context, IBroadcastServices broadcastService)
        {
            _context = context;
            this.broadcastService = broadcastService;
        }

        public void AddTeamMemberAsync(Member member)
        {
            _context.Add(member);
            _context.SaveChanges();
            broadcastService.NewTeamMemberAdded(member.Name, member.Id);
        }

        public void DeleteTeamMember(Member member)
        {
            _context.Member.Remove(member);
            _context.SaveChanges();
            this.broadcastService.DeleteTheTeamMember(member.Id);
        }

        public void EditTeamMember(int id, string name)
        {
            var member = _context.Member.Find(id);
            member.Name = name;
            _context.Update(member);
            _context.SaveChanges();
            this.broadcastService.EditTheTeamMember(id, name);
        }

        public TeamInfo GetTeamInfo()
        {
            var memberList = _context.Member.ToList().OrderBy(_ => _.Id).ToList();
            TeamInfo teamInfo = new TeamInfo("Team2", memberList);
            return teamInfo;
        }
    }
}
