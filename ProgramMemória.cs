//using DrabLibrary.Model;
//using Microsoft.AspNetCore.Mvc;

//var builder = WebApplication.CreateBuilder(args);

//var app = builder.Build();

//var books = new List<Book>();
//var id = 0;

//app.MapGet("/drablibrary", () => books);

//app.MapGet("/drablibrary/{id}", (int id) => { 
//    return books.ElementAtOrDefault(id);
//});

//app.MapPost("/drablibrary/", ([FromBody] Book book) =>
//{
//    book.Id = id;
//    books.Add(book);
//    id++;
//    return Results.Created($"/drablibrary/{id-1}", book);
//});

//app.MapPut("/drablibrary/{id}", ([FromBody] Book book, int id) => {

//    if (books.Count - 1 >= id)
//    {
//        book.Id = id;
//        books[id] = book;
//        return Results.Ok();
//    }
//    else
//        return Results.NotFound("Id não existente");

//});

//app.MapDelete("/drablibrary/{id}", (int id) => {
//    if (books.Count - 1 >= id)
//    {
//        books.RemoveAt(id);
//        return Results.Ok();
//    }
//    else
//        return Results.NotFound("Id não existente");
//});

//app.UseHttpsRedirection();

//app.Run();