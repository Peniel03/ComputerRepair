namespace ComputerRepair.Presentation.Extensions
{
    public static class AppDependenciesConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration,
            IApplicationBuilder applicationBuilder)
        {
            //services.AddDbContext<InnoGotchiContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
            //    .AddScoped<IPetService, PetService>()
            //    .AddScoped<IPetRepository, PetRepository>()
            //    .AddScoped<IAuthenticateService, AuthenticateService>()
            //    .AddAutoMapper(typeof(UserProfiles));
           

            return services;
        }

        public static void Configure(this WebApplication app)
        {
            app.UseAuthentication();

            app.UseAuthorization();
        }
    }
}
