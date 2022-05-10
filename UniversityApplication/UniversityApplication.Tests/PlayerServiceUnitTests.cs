using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversityApplication.Data.Entities;
using UniversityApplication.Data.Interfaces;
using UniversityApplication.Models.DTOs;
using UniversityApplication.Service.Services;
using Xunit;

namespace UniversityApplication.Tests
{
    public class PlayerServiceUnitTests
    {
        IPlayerRepository PlayerRepo;
        IMapper mapper;
        Mock<IPlayerRepository> PlayerRepoMock = new Mock<IPlayerRepository>();
        Player Player;
        PlayerDTO PlayerDTO;
        Mock<IMapper> mapperMock = new Mock<IMapper>();
        List<Player> Players = new List<Player>();
        List<PlayerDTO> PlayerDTOList = new List<PlayerDTO>();

        private void SetupMocks()
        {
            PlayerRepo = PlayerRepoMock.Object;
            mapper = mapperMock.Object;
        }

        private void SetupPlayerDTOMocks()
        {
            Player = GetPlayer();
            //var PlayerDTO = GetPlayerDTO();

            mapperMock.Setup(o => o.Map<PlayerDTO>(Player))
                .Returns(GetPlayerDTO());
        }
        private void SetupPlayerDTOListMocks()
        {
            PlayerDTO = GetPlayerDTO();
            var PlayerDTO2 = GetPlayerDTO();
            PlayerDTO2.Id = 2;

            PlayerDTOList.Add(PlayerDTO);
            PlayerDTOList.Add(PlayerDTO2);

            Players = GetPlayers();

            mapperMock.Setup(o => o.Map<List<PlayerDTO>>(Players))
                .Returns(PlayerDTOList);
        }

        private static Player GetPlayer()
        {
            return new Player
            {
                Id = 1,
                FirstName = "Marko",
                LastName = "Kolekjeski",
                DOB = DateTime.Today.AddYears(-22), //za dve godini kje bidam roden vo 2002 ama nema da go otvoram ova za dve godini
                SigningDate = DateTime.Today.AddYears(-5),
                Rank = 1,
                TotalGoals = 976124,
                ClubId = 3
            };
        }

        private static PlayerDTO GetPlayerDTO()
        {
            return new PlayerDTO
            {

                Id = 5,
                FirstName = "Simo",
                LastName = "Hayha",
                DOB = DateTime.Today.AddYears(-24),
                SigningDate = DateTime.Today.AddYears(-5),
                Rank = 4,
                TotalGoals = 14,
                ClubId = 5


            };
        }

        private static List<Player> GetPlayers()
        {
            return new List<Player>()
            {
                new Player()
                {
                     Id = 2,
                     FirstName = "Petar",
                     LastName = "Petkovski",
                     DOB = DateTime.Today.AddYears(-24),
                     SigningDate = DateTime.Today.AddYears(-3),
                     Rank = 5,
                     TotalGoals = 4,
                     ClubId = 4
                },
                 new Player()
                 {
                   Id = 3,
                   FirstName = "Hristijan",
                   LastName = "Hristovski",
                   DOB = DateTime.Today.AddYears(-20),
                   SigningDate = DateTime.Today.AddYears(-1),
                   Rank = 2,
                   TotalGoals = 14,
                   ClubId = 1
                 },
               new Player()
               {
                   Id = 4,
                   FirstName = "Marko",
                   LastName = "Markovski",
                   DOB = DateTime.Today.AddYears(-30),
                   SigningDate = DateTime.Today.AddYears(-10),
                   Rank = 3,
                   TotalGoals = 8,
                   ClubId = 2
               }
            };
        }

        [Fact]
        public void GetPlayerByIdWhenCalledReturnsPlayer()
        {
            //Arrange
            Player = GetPlayer();
            SetupMocks();
            SetupPlayerDTOMocks();

            PlayerRepoMock
                .Setup(o => o.GetPlayerById(It.IsAny<int>()))
                .Returns(Player);

            var PlayerService = new PlayerService(PlayerRepo, mapper);
            int id = 1;


            //Act 
            PlayerDTO response = PlayerService.GetPlayerById(id);

            //Assert
            Assert.True(response != null);
            Assert.NotNull(response);
            Assert.Equal(5, response.Id);
            Assert.NotEqual(id, response.Id);
        }

        [Fact]
        public void GetPlayersWhenCalledReturnsPlayer()
        {
            //Arrage 
            Players = GetPlayers();
            SetupMocks();
            SetupPlayerDTOListMocks();

            PlayerRepoMock
            .Setup(o => o.GetPlayers())
            .Returns(Players);

            var PlayerService = new PlayerService(PlayerRepo, mapper);

            // Act
            List<PlayerDTO> response = PlayerService.GetPlayers();

            // Assert
            Assert.True(response != null);
        }

        [Fact]
        public void GetPlayersWhenCalledOnThreePlayersReturnsTwoPlayer()
        {
            //Arrange
            Players = GetPlayers();
            SetupMocks();
            SetupPlayerDTOListMocks();

            PlayerRepoMock
                .Setup(o => o.GetPlayers())
                .Returns(Players);

            var PlayerService = new PlayerService(PlayerRepo, mapper);

            //Act
            List<PlayerDTO> response = PlayerService.GetPlayers();

            //Assert
            Assert.NotNull(response);
            Assert.Equal(2, response.Count());
            Assert.NotEqual(1, response.Count());
        }
    }
}
