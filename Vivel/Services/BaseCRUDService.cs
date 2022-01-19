﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vivel.Database;

namespace Vivel.Services
{
    public class BaseCRUDService<Dto, TDb, SearchRequest, InsertRequest, UpdateRequest> : IBaseCRUDService<Dto, SearchRequest, InsertRequest, UpdateRequest>
        where Dto : class
        where TDb : class
        where SearchRequest : class
        where InsertRequest : class
        where UpdateRequest : class
    {
        protected vivelContext _context { get; set; }
        protected IMapper _mapper { get; set; }

        public BaseCRUDService(vivelContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async virtual Task<List<Dto>> Get(SearchRequest request = null)
        {
            var list = await _context.Set<TDb>().ToListAsync();

            return _mapper.Map<List<Dto>>(list);
        }

        public async virtual Task<Dto> GetById(string id)
        {
            var entity = await _context.Set<TDb>().FindAsync(id);

            return _mapper.Map<Dto>(entity);
        }

        public async virtual Task<Dto> Insert(InsertRequest request)
        {
            var set = _context.Set<TDb>();

            TDb entity = _mapper.Map<TDb>(request);

            await set.AddAsync(entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Dto>(entity);
        }

        public async Task<Dto> Update(string id, UpdateRequest request)
        {
            var set = _context.Set<TDb>();

            TDb entity = set.Find(id);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Dto>(entity);
        }

        public async Task<Dto> Delete(string id)
        {
            var set = _context.Set<TDb>();

            var entity = await set.FindAsync(id);

            set.Remove(entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Dto>(entity);
        }
    }
}
