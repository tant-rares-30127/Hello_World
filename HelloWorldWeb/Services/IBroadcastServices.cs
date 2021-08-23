namespace HelloWorldWeb.Services
{
    public interface IBroadcastServices
    {
        void NewTeamMemberAdded(string name, int id);

        void DeleteTheTeamMember(int id);

        void EditTheTeamMember(int id, string name);
    }
}