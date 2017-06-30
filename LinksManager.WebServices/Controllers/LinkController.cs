using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinksManager.Entities;
using LinksManager.DataAccess.Abstract;
using LinksManager.DataAccess.Concrete;

namespace LinksManager.WebServices.Controllers
{
    public class LinkController : ApiController
    {
        private static readonly ILinkRepository _linkRepository;

        static LinkController()
        {
            _linkRepository = new EFLinkRepository();
        }

        public IEnumerable<Link> Get()
        {
            return _linkRepository.GetAll();
        }
    }
}
