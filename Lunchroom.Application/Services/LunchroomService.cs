﻿using AutoMapper;
using Lunchroom.Application.Lunchroom;
using Lunchroom.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Services
{
    public interface ILunchroomService
    {
        Task Create(LunchroomDto lunchroomDto);
        Task<IEnumerable<LunchroomDto>> GetAll();
    }

    public class LunchroomService
    {
        private readonly ILunchroomRepository _lunchroomRepository;
        private readonly IMapper _mapper;

        public LunchroomService(ILunchroomRepository lunchroomRepository, IMapper mapper)
        {
            _lunchroomRepository = lunchroomRepository;
            _mapper = mapper;
        }
        
    }
}
