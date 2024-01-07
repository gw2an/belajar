using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using OopModel;
using System.Diagnostics.Eventing.Reader;

static public class EpFnRef
{


    public static void FnTBBase<DB, T>(this IEndpointRouteBuilder app) where T : entTBBase where DB : DbContext
    {
        Type t = typeof(T);
        string route = t.Name;
        app.MapGet(route, async (DB db, T data) =>
        {
            var dbset = db.Set<T>();
            return (dbset != null) ? await dbset.ToListAsync() is List<T> item ?
              Results.Ok(item) : Results.NotFound()
              : Results.NotFound();
        });
        app.MapGet(route + "/{id}", async (DB db, int id) =>
        {
            var dbset = db.Set<T>();
            return (dbset != null) ? await dbset.FindAsync(id) is T item ?
              Results.Ok(item) : Results.NotFound()
              : Results.NotFound();
        });
        app.MapPost(route, async (DB db, T item) =>
        {
            var dbset = db.Set<T>();
            if (dbset != null)
            {
                if (item.Id == 0)
                { dbset.Add(item); }
                else
                { dbset.Update(item); }
                await db.SaveChangesAsync();
            }
        });
        app.MapDelete(route + "/{id}", async (DB db, int id) =>
        {
            var dbset = db.Set<T>();

            if (dbset != null)
            {
                if (await dbset.FindAsync(id) is T item)
                {
                    dbset.Remove(item);
                    await db.SaveChangesAsync();
                    return Results.Ok("Deleted");
                }
                else
                {
                    return Results.NotFound();
                }
            }
            return Results.Problem();
        });
    }
}