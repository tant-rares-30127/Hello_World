using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        void AddTeamMember(Member member);

        void DeleteTeamMember(Member member);

        TeamInfo GetTeamInfo();
        void EditTeamMember(int id, string name);
    }
}