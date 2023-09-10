using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    var html = $"""
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <title>MinimalAPI + HTMX</title>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@picocss/pico@1/css/pico.min.css">    
        <script src="https://unpkg.com/htmx.org@1.9.5"></script>
    </head>
    <body>
        <main class="container">
            <h1>The Simple Button</h1>
            <!-- have a button POST a click via AJAX -->
            {BuildForm(0)}
        </main>
    </body>
    </html>
    """;

    return Results.Content(html, "text/html");
});

app.MapPost("/click", ([FromForm] int count) => Results.Content(BuildForm(count + 1), "text/html"))
    .DisableAntiforgery();

app.Run();

static string BuildForm(int count)
{
    return $"""
    <form hx-post="/click" hx-swap="outerHTML">
        <label for="count">Count:</label>
        <input type="number" name="count" value="{count}" readonly/>
        <button type="submit">Click Me</button>
    </form>
    """;
}