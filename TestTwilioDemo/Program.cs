
using TestTwilioDemo.dto;
using TestTwilioDemo.General_settings;
using TestTwilioDemo.services;

namespace TestTwilioDemo
{
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
            builder.Services.Configure<TwilioSetting>(builder.Configuration.GetSection("Twilio"));
            builder.Services.AddTransient<ISMSservices, SMSservices>();
            builder.Services.AddTransient<IEmailService, EmailService>();
           // builder.Services.Configure<TwilioSetting>(builder.Configuration.GetSection("EmailConfiguration"));
            var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<MailSettings>();
            builder.Services.AddSingleton(emailConfig);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
