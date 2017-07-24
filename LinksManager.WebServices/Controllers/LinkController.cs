using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.OData;
using LinksManager.Entities;
using LinksManager.BusinessLogic.Abstract;

namespace LinksManager.WebServices.Controllers
{
    public class LinkController : ApiController
    {
        private readonly ILinkService _linkService;

        public LinkController(ILinkService linkService)
        {
            _linkService = linkService;
        }

        [HttpGet]
        public IHttpActionResult GetLink(int id)
        {
            var link = _linkService.GetLinkById(id);

            if (link == null)
            {
                return NotFound();
            }

            return Ok(link);
        }

        [HttpGet]
        [EnableQuery]
        public IHttpActionResult GetAll()
        {
            return Ok(_linkService.GetAll());
        }

        [HttpPost]
        public IHttpActionResult AddLink(Link link)
        {
            if (!ModelState.IsValid || link == null)
            {
                return BadRequest(ModelState);
            }

            var result = _linkService.AddLink(link);
            if (!result)
            {
                return Conflict();
            }

            return Ok(link);
        }

        [HttpPut]
        public IHttpActionResult EditLink(int id, Link link)
        {
            if (!ModelState.IsValid || link == null)
            {
                return BadRequest(ModelState);
            }

            var result = _linkService.EditLink(id, link);
            if (!result)
            {
                return NotFound();
            }

            return Ok(link);
        }

        [HttpDelete]
        public IHttpActionResult DeleteLink(int id)
        {
            var result = _linkService.DeleteLink(id);
            if (!result)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(_linkService.GetLinkById(id));
        }

        [Route("api/link/category/{categoryName}")]
        [HttpGet]
        public IHttpActionResult GetLinkByCategory(string categoryName)
        {
            return Ok(_linkService.GetLinksByCategory(categoryName));
        }

        [Route("api/link/title/{title}")]
        [HttpGet]
        public IHttpActionResult GetLinkByTitle(string title)
        {
            return Ok(_linkService.GetLinksByTitle(title));
        }

        [Route("api/link/description/{description}")]
        [HttpGet]
        public IHttpActionResult GetLinkByDescription(string description)
        {
            return Ok(_linkService.GetLinksByDescription(description));
        }
    }
}
