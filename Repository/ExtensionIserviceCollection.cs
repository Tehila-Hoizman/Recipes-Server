using Microsoft.Extensions.DependencyInjection;
using Repository.Entity;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class ExtensionIserviceCollection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Category>, CategoryRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Measure>, MeasureRepository>();
            services.AddScoped<IRepository<Ingredient>, IngredientRepository>();
            services.AddScoped<IRepository<Recipe>, RecipeRepository>();
            services.AddScoped<IRepository<Follower>, FollowerRepository>();
            services.AddScoped<IRepository<Comment>, CommentRepository>();

            return services;
        }
    }
}
