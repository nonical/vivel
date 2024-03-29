﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using Vivel.Database;
using Vivel.Extensions;
using Vivel.Interfaces;
using Vivel.Model.Pagination;
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
            return await _context.Set<TDb>().GetPagedAsync<TDb, Dto>(_mapper, request.Page, request.PageSize, request.Paginate);
        }

        public async virtual Task<Dto> GetById(Guid id)
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

        public async virtual Task<Dto> Update(Guid id, UpdateRequest request)
        {
            var set = _context.Set<TDb>();

            var entity = await set.FindAsync(id);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Dto>(entity);
        }

        public async virtual Task<Dto> Delete(Guid id)
        {
            var set = _context.Set<TDb>();

            var entity = await set.FindAsync(id);

            set.Remove(entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Dto>(entity);
        }
    }
}
