namespace HelloWorldWeb.Services
{
    public interface IBroadcastServices
    {
        void NewTeamMemberAdded(string name, int id);
    }
}