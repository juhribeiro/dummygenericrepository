using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste.Contracts;
using Teste.Models;
using Teste.Services.Base;

namespace Teste.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : BaseController<Category>
    {
        public CategoriesController(ICategoryService service) : base(service)
        {
        }

        /// <summary>
        /// bla teste de escrita
        /// </summary>
        /// <returns></returns>
        public override async Task<ActionResult<List<Category>>> GetAsync()
        {
            return await base.GetAsync();
        }
    }
}