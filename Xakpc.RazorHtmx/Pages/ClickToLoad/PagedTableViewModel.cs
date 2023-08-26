using Xakpc.RazorHtmx.Data;

namespace Xakpc.RazorHtmx.Pages.ClickToLoad;

public record PagedTableViewModel(List<UserInfoViewModel> Users, int Page);