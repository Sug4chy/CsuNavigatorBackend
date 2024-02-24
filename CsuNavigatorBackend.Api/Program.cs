using CsuNavigatorBackend.Api;

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(builder =>
    {
        builder.UseStartup<Startup>()
            .UseConfiguration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build());
    })
    .Build()
    .Run();