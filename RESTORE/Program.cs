using Microsoft.EntityFrameworkCore;
using RESTORE.Data;
using RESTORE.Middleware;

namespace RESTORE;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<StoreContext>(opt =>
        {
             opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        // 注册 CORS（跨源资源共享）服务到依赖注入容器中，允许配置跨域请求的规则。
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhost3000", policy =>
            {
                policy.WithOrigins("http://localhost:3000") // 允许的前端地址
                    .AllowAnyHeader()                     // 允许所有请求头
                    .AllowAnyMethod();                    // 允许所有 HTTP 方法
            });
        });
        
        var app = builder.Build();

        // Configure the HTTP request pipeline. 
        app.UseMiddleware<ExceptionMiddleware>();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
         
        //app.UseHttpsRedirection();

        app.UseCors("AllowLocalhost3000");
        
        app.UseAuthorization();
        
        app.MapControllers();

        // CreateScope() 方法会创建一个新的依赖注入范围 (scope)。
        // 在 ASP.NET Core 中，Scope 生命周期 是在请求级别（每个请求都有一个新的 scope），
        // 但在 Program.cs 中没有 HTTP 请求，所以需要手动创建一个 scope。
        var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        try 
        {
            // 如果没有所对应的数据库，会进行数据迁移
            context.Database.Migrate();
            DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
           logger.LogError(ex, "An error occurred while migrating the DB." );
        }
        
        app.Run();
    }
}