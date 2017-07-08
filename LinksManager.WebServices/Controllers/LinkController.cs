using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LinksManager.Entities;
using LinksManager.DataAccess.Abstract;
using LinksManager.BusinessLogic.Abstract;
using LinksManager.DataAccess.Concrete;

namespace LinksManager.WebServices.Controllers
{
    public class LinkController : ApiController
    {
        private readonly ILinkService _linkService;

        public LinkController(ILinkService linkService)
        {
            _linkService = linkService;
        }
    }
}
