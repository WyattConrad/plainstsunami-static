using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api;
using Api.Classes;
using BlazorApp.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiIsolated
{
    public class HttpTrigger
    {
        private readonly ILogger _logger;
        private readonly MyDbContext _context;

        public HttpTrigger(ILoggerFactory loggerFactory, MyDbContext context)
        {
            _logger = loggerFactory.CreateLogger<HttpTrigger>();
            _context = context;
        }

        [Function("GetAllTeams")]
        public async Task<HttpResponseData> RunGetAllTeams([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            var teams = new List<Team>();
            try
            {
                teams = await _context.Teams.Where(t => t.Active).OrderBy(t => t.Name).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            var newResponse = req.CreateResponse(HttpStatusCode.OK);
            await newResponse.WriteAsJsonAsync(teams);
            return newResponse;
        }

        [Function("GetTeam")]
        public async Task<HttpResponseData> RunGetTeam([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req, int id)
        {
            var teams = new List<Team>();
            try
            {
                teams = await _context.Teams.Where(t => t.Active && t.Id == id).OrderBy(t => t.Name).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            var newResponse = req.CreateResponse(HttpStatusCode.OK);
            await newResponse.WriteAsJsonAsync(teams);
            return newResponse;
        }

    }
}
