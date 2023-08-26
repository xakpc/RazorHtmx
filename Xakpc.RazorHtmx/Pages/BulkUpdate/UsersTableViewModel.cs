using Xakpc.RazorHtmx.Data;

namespace Xakpc.RazorHtmx.Pages.BulkUpdate;

public class UsersTableViewModel
{
    public UsersTableViewModel(List<UserInfoViewModel> users)
    {
        Users = users;
    }

    public List<UserInfoViewModel> Users { get; set; }
    public Dictionary<int, bool> UsersWasActivated { get; set; } = new();
}