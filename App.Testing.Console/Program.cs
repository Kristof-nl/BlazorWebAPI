using App.Repository;
using App.Repository.ApiClient;
using Core.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

HttpClient httpClient = new();
IWebApiExecuter apiExecuter = new WebApiExecuter("http://localhost:35003", httpClient);


Console.WriteLine("//////////////////");
Console.WriteLine("Reading projects...");
await GetProjects();

Console.WriteLine("//////////////////");
Console.WriteLine("Reading project tickets...");
await GetProjectTickets(2);

async Task GetProjects()
{
    ProjectRepository repository = new(apiExecuter);
    var projects = await repository.Get();
    foreach(var project in projects)
    {
        Console.WriteLine($"Project: {project.Name}");
    }
}

async Task<Project> GetProject(int id)
{
    ProjectRepository repository = new(apiExecuter);
    return await repository.GetById(id);
}

async Task GetProjectTickets(int id)
{
    var project = await GetProject(id);
    Console.WriteLine($"Project: {project.Name}");

    ProjectRepository repository = new(apiExecuter);
    var tickets = await repository.GetProjectTicketsAsync(id);
    foreach (var ticket in tickets)
    {
        Console.WriteLine($"Ticket: {ticket.Title}");
    }

}

