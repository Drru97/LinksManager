using System;
using System.Collections.Generic;
using LinksManager.BusinessLogic.Abstract;
using LinksManager.DataAccess.Abstract;
using LinksManager.Entities;

namespace LinksManager.BusinessLogic.Concrete
{
    public class LinkService : ILinkService
    {
        private readonly ILinkRepository _linkRepository;

        public LinkService(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public Link GetLinkById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("id must me positive number", nameof(id));
            }

            return _linkRepository.Get(id);
        }

        public IEnumerable<Link> GetLinksByCategory(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                throw new ArgumentException("Category name cannot be null or empty", nameof(categoryName));
            }

            return _linkRepository.FindBy(l => l.Category.Name == categoryName);
        }

        public IEnumerable<Link> GetLinksByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title cannot be null or empty", nameof(title));
            }

            return _linkRepository.FindBy(l => l.Title == title);
        }

        public IEnumerable<Link> GetLinksByDescription(string description)
        {
            if (description == null)
            {
                throw new ArgumentException("Description cannot be null", nameof(description));
            }

            return _linkRepository.FindBy(l => l.Description == description);
        }
    }
}
