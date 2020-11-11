using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        private CategoryService CreateCategoryService()
        {
            var useId = Guid.Parse(User.Identity.GetUserId());
            var categoryService = new CategoryService(useId);
            return categoryService;
        }

        //Create
        public IHttpActionResult Post(CategoryCreate category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCategoryService();

            if (!service.CreateCategory(category))
                return InternalServerError();
            return Ok();
        }
    }
}
