using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IInstructorDal, EfInstructorDal>();
builder.Services.AddScoped<IInstructorManager, InstructorManager>();
builder.Services.AddScoped<ICourseDal, EfCourseDal>();
builder.Services.AddScoped<ICourseManager, CourseSpecifactioManager>();
builder.Services.AddScoped<ICourseSpecifactionDal, EfCourseSpecifactionDal>();
builder.Services.AddScoped<ICourseSpecifactionManager, CourseSpecifactionManager>();
builder.Services.AddScoped<ILessonDal, EfLessonDal>();
builder.Services.AddScoped<ILessonManager, LessonManager>();
builder.Services.AddScoped<ILessonVideoDal, EfLessonVideoDal>();
builder.Services.AddScoped<ILessonVideoManager, LessonVideoManager>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "_myAllowOrigins",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithMethods("PUT", "DELETE", "GET");

        }
     );
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("_myAllowOrigins");

app.MapControllers();

app.Run();
