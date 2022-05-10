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
    public class ClubServiceUnitTests
    {


        IClubRepository ClubRepo;
        IMapper mapper;
        Mock<IClubRepository> ClubRepoMock = new Mock<IClubRepository>();
        Club Club;
        ClubDTO ClubDTO;
        Mock<IMapper> mapperMock = new Mock<IMapper>();
        List<Club> Clubs = new List<Club>();
        List<ClubDTO> ClubDTOList = new List<ClubDTO>();

        private void SetupMocks()
        {
            ClubRepo = ClubRepoMock.Object;
            mapper = mapperMock.Object;
        }

        private void SetupClubDTOMocks()
        {
            Club = GetClub();
            //var ClubDTO = GetClubDTO();

            mapperMock.Setup(o => o.Map<ClubDTO>(Club))
                .Returns(GetClubDTO());
        }
        private void SetupClubDTOListMocks()
        {
            ClubDTO = GetClubDTO();
            var ClubDTO2 = GetClubDTO();
            ClubDTO2.Id = 2;

            ClubDTOList.Add(ClubDTO);
            ClubDTOList.Add(ClubDTO2);

            Clubs = GetClubs();

            mapperMock.Setup(o => o.Map<List<ClubDTO>>(Clubs))
                .Returns(ClubDTOList);
        }

        private static Club GetClub()
        {
            return new Club
            {
                Id = 1,
                Name = "Vardar",
                Owner = "Marko",
                City = "Skopje",
                Country = "Macedonia"
            };
        }

        private static ClubDTO GetClubDTO()
        {
            return new ClubDTO
            {
                Id = 2,
                Name = "Manchester",
                Owner = "Dino",
                City = "Manchester City",
                Country = "United Kingdom"

            };
        }


        private static List<Club> GetClubs()
        {
            return new List<Club>()
            {
                new Club()
                {
                      Id = 3,
                    Name = "House Of Grappling Arts",
                    Owner = "David",
                    City = "Skopje",
                    Country = "Macedonia"
                },
                 new Club()
                 {
                   Id = 4,
                   Name = "Bayern", 
                     Owner = "Ne znam", 
                     City = "Munich", 
                     Country = "Germany"
                 },
               new Club()
               {
                    Id = 5, Name = "Partizan",
                   Owner = "Ante",
                   City = "Belgrade",
                   Country = "Serbia"
               }
            };
        }


        [Fact]
        public void GetClubByIdWhenCalledReturnsClub()
        {
            //Arrange
            Club = GetClub();
            SetupMocks();
            SetupClubDTOMocks();

            ClubRepoMock
                .Setup(o => o.GetClubById(It.IsAny<int>()))
                .Returns(Club);

            var ClubService = new ClubService(ClubRepo, mapper);
            int id = 1;


            //Act 
            ClubDTO response = ClubService.GetClubById(id);

            //Assert
            Assert.True(response != null);
            Assert.NotNull(response);
            Assert.Equal(2, response.Id);
            Assert.NotEqual(id, response.Id);
        }

        [Fact]
        public void GetClubsWhenCalledReturnsClub()
        {
            //Arrage 
            Clubs = GetClubs();
            SetupMocks();
            SetupClubDTOListMocks();

            ClubRepoMock
            .Setup(o => o.GetClubs())
            .Returns(Clubs);

            var ClubService = new ClubService(ClubRepo, mapper);

            // Act
            IEnumerable<ClubDTO> response = ClubService.GetClubs();

            // Assert
            Assert.True(response != null);
        }

        [Fact]
        public void GetClubsWhenCalledOnThreeClubsReturnsTwoClub()
        {
            //Arrange
            Clubs = GetClubs();
            SetupMocks();
            SetupClubDTOListMocks();

            ClubRepoMock
                .Setup(o => o.GetClubs())
                .Returns(Clubs);

            var ClubService = new ClubService(ClubRepo, mapper);

            //Act
            IEnumerable<ClubDTO> response = ClubService.GetClubs();

            //Assert
            Assert.NotNull(response);
            Assert.Equal(2, response.Count());
            Assert.NotEqual(1, response.Count());
        }



    }
}




