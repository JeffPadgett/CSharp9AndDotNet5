using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetbook.Contracts.V1;
using Tweetbook.Domain;

namespace Tweetbook.Controllers.V1
{
    public class PostsController : Controller
    {
        private List<Post> _post;

        public PostsController()
        {
            _post = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                _post.Add(new Post { Id = Guid.NewGuid().ToString()});
            }
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_post);
        }
     
    }
}
