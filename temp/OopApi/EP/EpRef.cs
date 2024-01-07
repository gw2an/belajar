using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using OopModel;
using System.Diagnostics.Eventing.Reader;

static public class EpFnRef
{


    public static void FnTblBase<DB, T>(this IEndpointRouteBuilder app) where T : entTBBase where DB : DbContext
    {
        Type t = typeof(T);
        string route = t.Name;
        app.MapGet(route, async (DB db) =>
        {
            var dbset = db.Set<T>();
            if (dbset == null) return Results.Problem("Unknown Data Object Format");
            try
            {
                return await dbset.ToListAsync() is List<T> item ?
                  Results.Ok(item) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });
        app.MapGet(route + "/{id}", async (DB db, int id) =>
        {
            var dbset = db.Set<T>();
            if (dbset == null) return Results.Problem("Unknown Data Object Format");
            try
            {
                return await dbset.FindAsync(id) is T item ?
                  Results.Ok(item) : Results.NotFound("Data Not Found"); 
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });
        app.MapPost(route, async (DB db, T item) =>
        {
            var dbset = db.Set<T>();
            if (dbset == null) return Results.Problem("Unknown Data Object Format");
            try
            {
                bool IsChange = false;
                if (dbset != null)
                {
                    if (item.Id == 0)
                    {
                        IsChange = true;
                        dbset.Add(item);
                    }
                    else
                    {
                        if (await dbset.FindAsync(item.Id) is T x)
                        {
                            IsChange = true;
                            dbset.Update(x);
                        }
                    }
                    if (IsChange)
                    {
                        await db.SaveChangesAsync();
                        return Results.Created($"{route}/{item.Id}", item);
                    }
                }
                return Results.NotFound("Data to be update is not found");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });

        app.MapDelete(route + "/{id}", async (DB db, int id) =>
        {
            var dbset = db.Set<T>();
            if (dbset == null) return Results.Problem("Unknown Data object format");
            try
            {
                if (await dbset.FindAsync(id) is T item)
                {
                    dbset.Remove(item);
                    await db.SaveChangesAsync();
                    return Results.Ok("Deleted");
                }
                else
                    return Results.NotFound("Data not Found");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });
    }
}