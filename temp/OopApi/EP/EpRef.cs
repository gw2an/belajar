using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using OopModel;
using System.Diagnostics.Eventing.Reader;

 public static class EpFnRef
{

    public static void FnMap<DB, T>(WebApplication ap, string grp, string tags) where DB : DbContext where T : entTBBase
    {
        Type t = typeof(T);
        string route = t.Name;
        var apku = ap.MapGroup(grp).WithTags(tags);
        apku.MapGet(route, async (DB db) =>
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

        apku.MapGet(route + "/{id}", async (DB db, int id) =>
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
        apku.MapPost(route, async (DB db, T item) =>
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

        apku.MapDelete(route + "/{id}", async (DB db, int id) =>
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

    public static void FnTblBase<DB, T>(this IEndpointRouteBuilder ap,  string grp, string tags) where T : entTBBase where DB : DbContext
    {
        Type t = typeof(T);
        string route = "/" + t.Name + "/";
        var app = ap.MapGroup(grp).WithTags(tags);
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

        app.MapGet(route + "{id}", async (DB db, int id) =>
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

        app.MapDelete(route + "{id}", async (DB db, int id) =>
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

    public static void FnRefTblBase<DB, T>(this RouteGroupBuilder grp) where T : entTBBase where DB : DbContext
    {
        Type t = typeof(T);
        string route = "/" + t.Name + "/";
        grp.MapGet(route, async (DB db) =>
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

        grp.MapGet(route + "{id}", async (DB db, int id) =>
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
        grp.MapPost(route, async (DB db, T item) =>
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

        grp.MapDelete(route + "{id}", async (DB db, int id) =>
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