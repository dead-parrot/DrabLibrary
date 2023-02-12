using AutoMapper;
using DrabLibrary.Data;
using DrabLibrary.Model;
using DrabLibrary.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("mysqlserver"); 

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.MapGet("/books", async (AppDbContext context) => {
    return await context.Books.ToListAsync();
});

app.MapGet("/books/{id}", async (AppDbContext context, int id) => {
    Book? book = await context.Books.FindAsync(id);
    if (book == null)
        return Results.NotFound();
    else
        return Results.Ok(book);
});

app.MapPost("/books", async (AppDbContext context, Book bookDTO, IMapper mapper) => {
    Book book = mapper.Map<Book>(bookDTO);
    context.Books.Add(book);
    await context.SaveChangesAsync();
    return Results.Created($"/books/{book.Id}", book);
});

app.MapPut("/books/{id}", async (AppDbContext context, BookUpdateDTO bookDTO, IMapper mapper, int id) => {
    Book? book = await context.Books.FindAsync(id);
    if (book == null)
        return Results.NotFound("Id not found");
    mapper.Map(bookDTO, book);
    await context.SaveChangesAsync();  
    return Results.Ok(book);
});

app.MapDelete("/books/{id}", async (AppDbContext context, int id) => {
    Book? book = await context.Books.FindAsync(id);
    if (book == null)
        return Results.NotFound("Id not found");

    context.Books.Remove(book);
    await context.SaveChangesAsync();
    return Results.Ok();
    
});

app.UseHttpsRedirection();

app.Run();