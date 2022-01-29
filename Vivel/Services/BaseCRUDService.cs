using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;
using Vivel.Extensions;
using Vivel.Helpers;
using Vivel.Interfaces;
using Vivel.Model.Requests;

namespace Vivel.Services
{
    public class BaseCRUDService<Dto, TDb, SearchRequest, InsertRequest, UpdateRequest> : IBaseCRUDService<Dto, SearchRequest, InsertRequest, UpdateRequest>
        where Dto : class
        where TDb : class
        where SearchRequest : BaseSearchObject
        where InsertRequest : class
        where UpdateRequest : class
    {
        protected VivelContext _context { get; set; }
        protected IMapper _mapper { get; set; }

        public BaseCRUDService(VivelContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async virtual Task<PagedResult<Dto>> Get(SearchRequest request = null)
        {
            var list = await _context.Set<TDb>().GetPagedAsync(request.Page, request.PageSize);

            var mappedList = _mapper.Map<List<Dto>>(list.Results);

            return new PagedResult<Dto>()
            {
                Results = mappedList,
                CurrentPage = request.Page,
                PageCount = list.PageCount,
                TotalItems = list.TotalItems
            };
        }

        public async virtual Task<Dto> GetById(string id)
        {
            var entity = await _context.Set<TDb>().FindAsync(id);

            return _mapper.Map<Dto>(entity);
        }

        public async virtual Task<Dto> Insert(InsertRequest request)
        {
            var set = _context.Set<TDb>();

            var entity = _mapper.Map<TDb>(request);

            await set.AddAsync(entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Dto>(entity);
        }

        public async virtual Task<Dto> Update(string id, UpdateRequest request)
        {
            var set = _context.Set<TDb>();

            var entity = await set.FindAsync(id);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Dto>(entity);
        }

        public async virtual Task<Dto> Delete(string id)
        {
            var set = _context.Set<TDb>();

            var entity = await set.FindAsync(id);

            set.Remove(entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Dto>(entity);
        }
    }
}
