using Newtonsoft.Json;

namespace The_guardian_pro_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapPut("/put{model}", (string model, object textObject) =>
            {
                if (model != null)
                {
                    if (textObject != null)
                    {
                        switch (model)
                        {
                            case "Request":
                                Models.Request request;
                                try
                                {
                                    request = JsonConvert.DeserializeObject<Models.Request>(textObject.ToString());
                                    if (Context.context.Requests.ToList().FirstOrDefault(x => x.Id == request.Id) != null)
                                    {
                                        Context.context.Requests.Remove(Context.context.Requests.ToList().FirstOrDefault(x => x.Id == request.Id));
                                    }
                                    Context.context.Requests.Add(request);
                                    Context.context.SaveChanges();
                                    return Results.Ok();
                                }
                                catch (Exception ex)
                                {
                                    return Results.BadRequest(ex);
                                }

                            case "Status":
                                Models.Status status;
                                try
                                {
                                    status = JsonConvert.DeserializeObject<Models.Status>(textObject.ToString());
                                    if (Context.context.Statuses.ToList().FirstOrDefault(x => x.Id == status.Id) != null)
                                    {
                                        Context.context.Statuses.Remove(Context.context.Statuses.ToList().FirstOrDefault(x => x.Id == status.Id));
                                    }
                                    Context.context.Statuses.Add(status);
                                    Context.context.SaveChanges();
                                    return Results.Ok();
                                }
                                catch (Exception ex)
                                { 
                                    return Results.BadRequest(ex);
                                }

                            case "Visitor":
                                Models.Visitor visitor;
                                try
                                {
                                    visitor = JsonConvert.DeserializeObject<Models.Visitor>(textObject.ToString());
                                    if (Context.context.Visitors.ToList().FirstOrDefault(x => x.Id == visitor.Id) != null)
                                    {
                                        Context.context.Visitors.Remove(Context.context.Visitors.ToList().FirstOrDefault(x => x.Id == visitor.Id));
                                    }
                                    Context.context.Visitors.Add(visitor);
                                    Context.context.SaveChanges();
                                    return Results.Ok("Успешно");
                                }
                                catch (Exception ex)
                                {
                                    return Results.BadRequest(ex);
                                }

                            case "Department":
                                Models.Department department;
                                try
                                {
                                    department = JsonConvert.DeserializeObject<Models.Department>(textObject.ToString());
                                    if (Context.context.Departments.ToList().FirstOrDefault(x => x.Id == department.Id) != null)
                                    {
                                        Context.context.Departments.Remove(Context.context.Departments.ToList().FirstOrDefault(x => x.Id == department.Id));
                                    }
                                    Context.context.Departments.Add(department);
                                    Context.context.SaveChanges();
                                    return Results.Ok();
                                }
                                catch (Exception ex)
                                {
                                    return Results.BadRequest(ex);
                                }

                            case "Division":
                                Models.Division division;
                                try
                                {
                                    division = JsonConvert.DeserializeObject<Models.Division>(textObject.ToString());
                                    if (Context.context.Divisions.ToList().FirstOrDefault(x => x.Id == division.Id) != null)
                                    {
                                        Context.context.Divisions.Remove(Context.context.Divisions.ToList().FirstOrDefault(x => x.Id == division.Id));
                                    }
                                    Context.context.Divisions.Add(division);
                                    Context.context.SaveChanges();
                                    return Results.Ok();
                                }
                                catch (Exception ex)
                                {
                                    return Results.BadRequest(ex);
                                }

                            case "Group":
                                Models.Group group;
                                try
                                {
                                    group = JsonConvert.DeserializeObject<Models.Group>(textObject.ToString());
                                    if (Context.context.Groups.ToList().FirstOrDefault(x => x.GroupId == group.GroupId) != null)
                                    {
                                        Context.context.Groups.Remove(Context.context.Groups.ToList().FirstOrDefault(x => x.GroupId == group.GroupId));
                                    }
                                    Context.context.Groups.Add(group);
                                    Context.context.SaveChanges();
                                    return Results.Ok();
                                }
                                catch (Exception ex)
                                {
                                    return Results.BadRequest(ex);
                                }

                            case "Staff":
                                Models.Staff staff;
                                try
                                {
                                    staff = JsonConvert.DeserializeObject<Models.Staff>(textObject.ToString());
                                    if (Context.context.Staff.ToList().FirstOrDefault(x => x.StaffId == staff.StaffId) != null)
                                    {
                                        Context.context.Staff.Remove(Context.context.Staff.ToList().FirstOrDefault(x => x.StaffId == staff.StaffId));
                                    }
                                    Context.context.Staff.Add(staff);
                                    Context.context.SaveChanges();
                                    return Results.Ok();
                                }
                                catch (Exception ex)
                                {
                                    return Results.BadRequest(ex);
                                }

                            case "Visit":
                                Models.Visit visit;
                                try
                                {
                                    visit = JsonConvert.DeserializeObject<Models.Visit>(textObject.ToString());
                                    if (Context.context.Visits.ToList().FirstOrDefault(x => x.VisitId == visit.VisitId) != null)
                                    {
                                        Context.context.Visits.Remove(Context.context.Visits.ToList().FirstOrDefault(x => x.VisitId == visit.VisitId));
                                    }
                                    Context.context.Visits.Add(visit);
                                    Context.context.SaveChanges();
                                    return Results.Ok();
                                }
                                catch (Exception ex)
                                {
                                    return Results.BadRequest(ex);
                                }

                            default:
                                return Results.NotFound("Ошибка! Такая модель не найдена");
                        }
                    }
                    else
                        return Results.BadRequest("Ошибка! Объект пустой");
                }
                else
                    Results.BadRequest("Ошибка! Неверно написана модель.");
                return Results.BadRequest("Произошла неизвестная ошибка");
            });

            app.MapGet("/maxId{model}", (string model) =>
            {
                switch (model)
                {
                    case "Department":
                        if (Context.context.Departments.ToList().Count() != 0)
                        {
                            return Results.Json(Context.context.Departments.ToList().Max(x => x.Id));
                        }
                        else return Results.Json(1);

                    case "Division":
                        if (Context.context.Divisions.ToList().Count() != 0)
                        {
                            return Results.Json(Context.context.Divisions.ToList().Max(x => x.Id));
                        }
                        else return Results.Json(1);

                    case "Group":
                        if (Context.context.Groups.ToList().Count() != 0)
                        {
                            return Results.Json(Context.context.Groups.ToList().Max(x => x.GroupId));
                        }
                        else return Results.Json(1);

                    case "Request":
                        if (Context.context.Requests.ToList().Count() != 0)
                        {
                            return Results.Json(Context.context.Requests.ToList().Max(x => x.Id));
                        }
                        else return Results.Json(1);

                    case "Staff":
                        if (Context.context.Staff.ToList().Count() != 0)
                        {
                            return Results.Json(Context.context.Staff.ToList().Max(x => x.StaffId));
                        }
                        else return Results.Json(1);

                    case "Status":
                        if (Context.context.Statuses.ToList().Count() != 0)
                        {
                            return Results.Json(Context.context.Statuses.ToList().Max(x => x.Id));
                        }
                        else return Results.Json(1);

                    case "Visit":
                        if (Context.context.Visits.ToList().Count() != 0)
                        {
                            return Results.Json(Context.context.Visits.ToList().Max(x => x.VisitId));
                        }
                        else return Results.Json(1);

                    case "Visitor":
                        if (Context.context.Visitors.ToList().Count() != 0)
                        {
                            return Results.Json(Context.context.Visitors.ToList().Max(x => x.Id));
                        }
                        else return Results.Json(1);

                    default:
                        return Results.NotFound("Ошибка! Такая модель не найдена");
                }
            });

            app.MapGet("/get{model}/{Id}", (int Id, string model) =>
            {
                if (model != null)
                {
                    switch (model)
                    {
                        case "Requests":
                            if (Context.context.Requests.ToList().FirstOrDefault(x => x.Id == Id) != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.Requests.ToList().FirstOrDefault(x => x.Id == Id), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        case "Status":
                            if (Context.context.Statuses.ToList().FirstOrDefault(x => x.Id == Id) != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.Statuses.ToList().FirstOrDefault(x => x.Id == Id), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        case "Visitor":
                            if (Context.context.Visitors.ToList().FirstOrDefault(x=>x.Id == Id) != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.Visitors.ToList().FirstOrDefault(x => x.Id == Id), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        case "Department":
                            if (Context.context.Departments.ToList().FirstOrDefault(x => x.Id == Id) != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.Departments.ToList().FirstOrDefault(x => x.Id == Id), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        case "Division":
                            if (Context.context.Divisions.ToList().FirstOrDefault(x => x.Id == Id) != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.Divisions.ToList().FirstOrDefault(x => x.Id == Id), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        case "Group":
                            if (Context.context.Groups.ToList().FirstOrDefault(x => x.GroupId == Id) != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.Groups.ToList().FirstOrDefault(x => x.GroupId == Id), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        case "Staff":
                            if (Context.context.Staff.ToList().FirstOrDefault(x => x.StaffId == Id) != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.Staff.ToList().FirstOrDefault(x => x.StaffId == Id), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        case "Visit":
                            if (Context.context.Visits.ToList().FirstOrDefault(x => x.VisitId == Id) != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.Visits.ToList().FirstOrDefault(x => x.VisitId == Id), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        case "PurposeOfTheVisit":
                            if (Context.context.PurposOfTheVisits.ToList().FirstOrDefault(x => x.Id == Id) != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.PurposOfTheVisits.ToList().FirstOrDefault(x => x.Id == Id), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        default:
                            return Results.NotFound("Ошибка! Такая модель не найдена");
                    }
                }
                else
                    Results.BadRequest("Ошибка! Неверно написан Id или модель.");
                return Results.BadRequest("Произошла неизвестная ошибка");
            });

            app.MapGet("/get{model}", (string model) =>
            {
                if (model != null)
                {
                    switch (model)
                    {
                        case "Requests":
                            if (Context.context.Requests.ToList() != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.Requests.ToList(), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        case "Status":
                            if (Context.context.Statuses.ToList() != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.Statuses.ToList(), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        case "Visitor": 
                            if (Context.context.Visitors.ToList() != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.Visitors.ToList(), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        case "Department":
                            if (Context.context.Departments.ToList() != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.Departments.ToList(), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        case "Division":
                            if (Context.context.Divisions.ToList() != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.Divisions.ToList(), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        case "Group":
                            if (Context.context.Groups.ToList() != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.Groups.ToList(), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        case "Staff":
                            if (Context.context.Staff.ToList() != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.Staff.ToList(), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        case "Visit":
                            if (Context.context.Visits.ToList() != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.Visits.ToList(), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        case "PurposeOfTheVisit":
                            if (Context.context.PurposOfTheVisits.ToList() != null)
                            {
                                return Results.Text(JsonConvert.SerializeObject(Context.context.PurposOfTheVisits.ToList(), new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                            }
                            else
                                return Results.NotFound("Ошибка! По такому Id ничего не найдено");

                        default:
                            return Results.NotFound("Ошибка! Такая модель не найдена");
                    }
                }
                else
                    Results.BadRequest("Ошибка! Неверно написан Id или модель.");
                return Results.BadRequest("Произошла неизвестная ошибка");
            });

            app.MapDelete("delete{model}/{Id}", (string model, int Id) =>
            {
                if (model != null)
                {
                    switch (model)
                    {
                        case "Status":
                            if (Context.context.Statuses.ToList().FirstOrDefault(x => x.Id == Id) != null)
                            {
                                Context.context.Statuses.Remove(Context.context.Statuses.ToList().FirstOrDefault(x => x.Id == Id));
                                Context.context.SaveChanges();
                                return Results.Ok();
                            }
                            else return Results.NotFound("Ошибка! Посетителя с таким Id нет");

                        case "Requests":
                            if (Context.context.Requests.ToList().FirstOrDefault(x => x.Id == Id) != null)
                            {
                                Context.context.Requests.Remove(Context.context.Requests.ToList().FirstOrDefault(x => x.Id == Id));
                                Context.context.SaveChanges();
                                return Results.Ok();
                            }
                            else return Results.NotFound("Ошибка! Посетителя с таким Id нет");

                        case "Visitor":
                            if (Context.context.Visitors.ToList().FirstOrDefault(x => x.Id == Id) != null)
                            {
                                Context.context.Visitors.Remove(Context.context.Visitors.ToList().FirstOrDefault(x => x.Id == Id));
                                Context.context.SaveChanges();
                                return Results.Ok();
                            }
                            else return Results.NotFound("Ошибка! Посетителя с таким Id нет");

                        case "Department":
                            if (Context.context.Departments.ToList().FirstOrDefault(x => x.Id == Id) != null)
                            {
                                Context.context.Departments.Remove(Context.context.Departments.ToList().FirstOrDefault(x => x.Id == Id));
                                Context.context.SaveChanges();
                                return Results.Ok();
                            }
                            else return Results.NotFound("Ошибка! Объект с таким Id не найден");

                        case "Division":
                            if (Context.context.Divisions.ToList().FirstOrDefault(x => x.Id == Id) != null)
                            {
                                Context.context.Divisions.Remove(Context.context.Divisions.ToList().FirstOrDefault(x => x.Id == Id));
                                Context.context.SaveChanges();
                                return Results.Ok();
                            }
                            else return Results.NotFound("Ошибка! Объект с таким Id не найден");

                        case "Group":
                            if (Context.context.Groups.ToList().FirstOrDefault(x => x.GroupId == Id) != null)
                            {
                                Context.context.Groups.Remove(Context.context.Groups.ToList().FirstOrDefault(x => x.GroupId == Id));
                                Context.context.SaveChanges();
                                return Results.Ok();
                            }
                            else return Results.NotFound("Ошибка! Объект с таким Id не найден");

                        case "Staff":
                            if (Context.context.Staff.ToList().FirstOrDefault(x => x.StaffId == Id) != null)
                            {
                                Context.context.Staff.Remove(Context.context.Staff.ToList().FirstOrDefault(x => x.StaffId == Id));
                                Context.context.SaveChanges();
                                return Results.Ok();
                            }
                            else return Results.NotFound("Ошибка! Объект с таким Id не найден");

                        case "Visit":
                            if (Context.context.Visits.ToList().FirstOrDefault(x => x.VisitId == Id) != null)
                            {
                                Context.context.Visits.Remove(Context.context.Visits.ToList().FirstOrDefault(x => x.VisitId == Id));
                                Context.context.SaveChanges();
                                return Results.Ok();
                            }
                            else return Results.NotFound("Ошибка! Объект с таким Id не найден");

                        default:
                            return Results.NotFound("Ошибка! Такая модель не найдена");
                    }
                }
                else
                    Results.BadRequest("Ошибка! Неверно написана модель.");
                return Results.BadRequest("Произошла неизвестная ошибка");
            });

            app.Run();
        }
    }
}