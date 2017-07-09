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

        public IEnumerable<Link> GetAll()
        {
            return _linkRepository.GetAll();
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

        public bool AddLink(Link link)
        {
            if (link == null)
            {
                throw new ArgumentNullException(nameof(link), "Link cannot be null");
            }

            var newLink = _linkRepository.Get(link.Id);
            if (newLink != null)
            {
                return false;
            }

            _linkRepository.Add(link);
            _linkRepository.Save();
            return true;
        }

        public bool EditLink(int id, Link link)
        {
            if (id < 0)
            {
                throw new ArgumentException("id must be positive number");
            }
            if (link == null)
            {
                throw new ArgumentNullException(nameof(link), "Link cannot be null");
            }

            var editLink = _linkRepository.Get(id);
            if (editLink == null)
            {
                return false;
            }

            // TODO: Needs be refactored
            editLink.Title = link.Title;
            editLink.Url = link.Url;
            editLink.Description = link.Description;
            editLink.Category = link.Category;
            editLink.CategoryId = link.CategoryId;

            _linkRepository.Edit(editLink);
            _linkRepository.Save();
            return true;
        }

        public bool DeleteLink(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("id must be positive number");
            }

            var deleteLink = _linkRepository.Get(id);
            if (deleteLink == null)
            {
                return false;
            }

            _linkRepository.Delete(deleteLink);
            _linkRepository.Save();
            return true;
        }
    }
}
