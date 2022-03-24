using ElasticSearchProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ElasticClient elasticClient;
        public HomeController(ILogger<HomeController> logger,ElasticClient elasticClient)
        {
            _logger = logger;
            this.elasticClient = elasticClient;
        }
        /// <summary>
        /// This page shows the available indexes.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            _logger.LogInformation("Home Page Displayed");
            return View();
        }
        /// <summary>
        /// This index is used to retrieve data from Book index(multiple fields).
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index2(string query)
        {
        //    var results = await elasticClient.SearchAsync<Dyn>(s => s
        //      .AllIndices()
        //      .Query(q => q
        //      .QueryString(qs => qs
        //      .AnalyzeWildcard()
        //      //.Query("*" + query.ToLower() + "*")
        //      .Fields(f => f
        //      .Fields("name", "title", "authors", "age")
        //      ).Query("*" + query.ToLower() + "*")
        //      )
        //      ));

            var results = await elasticClient.SearchAsync<Dyn>(s => s.
            AllIndices()
            .From(0)
            .Size(100)
            .Query(q => q
            .Bool(b => b
            .Should(s => s
            //.Wildcard(w => w
            .MultiMatch(m => m
            .Fields(f => f

            .Fields(new string[] { "name", "title", "authors", "age" })
            //.Field("name")
            //.Field("title")
            //.Field("author")
            //.Field("age")
            //.Field("isbn")
            //.Field("education")
            //.Field("categories")
            ).Query(query))))));
        //var resp = elasticClient.Search<dynamic>(s => s

        //   .AllTypes()
        //   .From(0)
        //   .Take(10)
        //   .Query(qry => qry
        //       .Bool(b => b
        //       .Must(m => m
        //           .QueryString(qs => qs
        //               .DefaultField("_all")
        //               .Query(query))))));

        _logger.LogInformation("Book index data displayed succesfully");
            return View(results);
        }
        /// <summary>
        /// This index is used to retrieve data from User index.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index1(string query)
        {
            //if (query == null)
            //{
            //    var result = elasticClient.SearchAsync<Dyn>(s => s.AllIndices());
            //    return View(result);
            //}

            var results = await elasticClient.SearchAsync<Dyn>(s => s
              .AllIndices()
              .Query(q => q
              .QueryString(qs => qs
              .AnalyzeWildcard()
              //.Query("*" + query.ToLower() + "*")
              .Fields(f => f
              .Fields("name", "title", "authors", "age")
              ).Query("*" + query + "*")
              )
              ));
            _logger.LogInformation("User index data displayed successfully");
            return View(results);
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
