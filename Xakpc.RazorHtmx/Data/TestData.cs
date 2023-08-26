namespace Xakpc.RazorHtmx.Data;

public static class TestData
{
    static TestData()
    {
        Users = new List<UserInfoViewModel>();

        for (int i = 0; i < 100; i++)
        {
            var fn = Faker.Name.First();
            var ln = Faker.Name.Last();
            Users.Add(new UserInfoViewModel
            {
                Id = i + 1,
                FirstName = fn,
                LastName = ln,
                Email = Faker.Internet.Email($"{fn} {ln}"),
                Status = Faker.Boolean.Random() ? "Active" : "Inactive",
                RowId = Guid.NewGuid()
            });
        }
    }

    public static List<UserInfoViewModel> Users { get; set; }
}