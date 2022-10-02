namespace TaskManagementSystem.Business.Helpers
{
    public interface IJwt
    {
        string GetJwtToken(Entities.Models.User user);
    }
}