using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApplication.Data;
using UniversityApplication.Data.Entities;
using UniversityApplication.Models.DTOs;
using UniversityApplication.Service.Interfaces;
using AutoMapper;
using UniversityApplication.Data.Interfaces;

namespace UniversityApplication.Service.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IMapper _mapper;
        private readonly IPlayerRepository _PlayerRepository;

        public PlayerService(IPlayerRepository PlayerRepository, IMapper mapper)
        {
            _PlayerRepository = PlayerRepository;
            _mapper = mapper;
        }

        public List<PlayerDTO> GetPlayers()
        {

            var Players = _PlayerRepository.GetPlayers();
            return _mapper.Map<List<PlayerDTO>>(Players);
        }

        public PlayerDTO GetPlayerById(int id)
        {

            var Player = _PlayerRepository.GetPlayerById(id);
            return _mapper.Map<PlayerDTO>(Player);
        }

        public PlayerDTO AddPlayer(PlayerDTO Player)
        {
            Player newPlayer = _mapper.Map<Player>(Player);

            if (_PlayerRepository.GetPlayerById(Player.Id) == null)
            {
                _PlayerRepository.AddPlayer(newPlayer);
            }
            return _mapper.Map<PlayerDTO>(newPlayer);
        }

        public PlayerDTO UpdatePlayer(PlayerDTO Player)
        {
            Player newPlayer = _mapper.Map<Player>(Player);
            Player oldPlayer = _PlayerRepository.GetPlayerById(newPlayer.Id);

            if (oldPlayer != null)
            {
                _PlayerRepository.UpdatePlayer(oldPlayer, newPlayer);
            }
            return _mapper.Map<PlayerDTO>(newPlayer);
        }

        public bool DeletePlayer(int id)
        {
            var PlayerEntity = _PlayerRepository.GetPlayerById(id);

            return _PlayerRepository.DeletePlayer(PlayerEntity);
        }
    }
}
