using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lab1.DAL
{
    public class AuthDbContext:IdentityDbContext
    {
       
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var adminId =Guid.NewGuid().ToString();
            var studentId =Guid.NewGuid().ToString();
            var instructourID =Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();
            var roles = new List<IdentityRole>
            {
                new IdentityRole{Id=adminId,Name="Admin",NormalizedName="ADMIN"},
                new IdentityRole{Id=studentId,Name="Student",NormalizedName="STUDENT"},
                new IdentityRole{Id=instructourID,Name="Instractour",NormalizedName="INSTRACTOUR"}
            };
            var user = new IdentityUser
            { 
            
            Id=userId,
            UserName="admin@iti.gov",
            NormalizedUserName= "admin@iti.gov".ToUpper(),
            Email ="admin@iti.gov",
            NormalizedEmail= "admin@iti.gov".ToUpper()
            };
            user.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(user, "Admin@123");
            builder.Entity<IdentityRole>(s =>
            {
                s.HasData(roles);


            });
            builder.Entity<IdentityUser>(s =>
            {
                s.HasData(user);


            });


            builder.Entity<IdentityUserRole<string>>(s =>
            {
                s.HasData(new IdentityUserRole<string> { 
                
                RoleId=adminId,
                UserId=userId
                
                }
                );
            });

            base.OnModelCreating(builder);
         }



    }
}
