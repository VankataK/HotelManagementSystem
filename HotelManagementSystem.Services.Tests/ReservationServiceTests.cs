using NUnit.Framework;
using Moq;
using FluentAssertions;
using HotelManagementSystem.Services.Data;
using HotelManagementSystem.Services.Data.Interfaces;
using HotelManagementSystem.Data.Repository.Interfaces;
using HotelManagementSystem.Data.Models;
using HotelManagementSystem.Web.ViewModels.Room;
using HotelManagementSystem.Web.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockQueryable;

[TestFixture]
public class ReservationServiceTests
{
    private Mock<IRepository<Reservation, Guid>> _reservationRepositoryMock;
    private Mock<IRepository<Room, Guid>> _roomRepositoryMock;
    private Mock<IRoomAvailabilityRepository> _roomAvailabilityRepositoryMock;
    private ReservationService _reservationService;

    private IList<Room> roomData = new List<Room>()
    {
        new Room()
                {
                    RoomNumber = "101",
                    CategoryId = 1,
                    Description = "This room is located on the first floor of the hotel and has hot / cold air conditioned, a furnished balcony and free WI FI.",
                    ImageUrl = "https://webbox.imgix.net/images/owvecfmxulwbfvxm/c56a0c0d-8454-431a-9b3e-f420c72e82e3.jpg?auto=format,compress&fit=crop&crop=entropy",
                    PricePerNight = 70.00m,
                    MaxCapacity = 1
                },
                new Room()
                {
                    RoomNumber = "102",
                    CategoryId = 2,
                    Description = "Stylishly designed, this double room offers comfort and functionality for a memorable stay.",
                    ImageUrl = "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708595213/Uploads/Hotel7/Cosy_Room_Hero_643fdf08b9.jpg",
                    PricePerNight = 120.00m,
                    MaxCapacity = 2
                },
                new Room()
                {
                    RoomNumber = "103",
                    CategoryId = 2,
                    Description = "Designed for convenience, this room features two comfortable twin beds, ideal for friends or colleagues.",
                    ImageUrl = "https://media.hotel7dublin.com/image/upload/f_auto,g_auto,c_auto,w_3840,q_auto/v1708601916/Uploads/Hotel7/Twin_Room_Hero_07817fcfab.jpg",
                    PricePerNight = 110.00m,
                    MaxCapacity = 2
                },
                new Room()
                {
                    RoomNumber = "104",
                    CategoryId = 3,
                    Description = "A spacious room designed for families, offering a combination of beds to accommodate up to four guests.",
                    ImageUrl = "https://manorhousecountryhotel.s3-assets.com/executive-family-room-main.png",
                    PricePerNight = 250.00m,
                    MaxCapacity = 4
                },
                new Room()
                {
                    RoomNumber = "501",
                    CategoryId = 5,
                    Description = "Indulge in opulence with this expansive suite, featuring a private lounge and top-tier furnishings.",
                    ImageUrl = "https://www.manila-hotel.com.ph/wp-content/uploads/2023/07/TMH_Presidential-Suite_Bedroom-1024x682.jpg",
                    PricePerNight = 7000.00m,
                    MaxCapacity = 6
                },
    };

    [SetUp]
    public void Setup()
    {
        _reservationRepositoryMock = new Mock<IRepository<Reservation, Guid>>();
        _roomRepositoryMock = new Mock<IRepository<Room, Guid>>();
        _roomAvailabilityRepositoryMock = new Mock<IRoomAvailabilityRepository>();

        _reservationService = new ReservationService(
            _reservationRepositoryMock.Object,
            _roomRepositoryMock.Object,
            _roomAvailabilityRepositoryMock.Object);
    }

    [Test]
    public async Task CreateReservationAsync_ShouldReturnFalse_WhenRoomIsNotAvailable()
    {
        // Arrange
        var model = new AddReservationFormModel
        {
            Room = new AddRoomToReservationViewModel { Id = Guid.NewGuid().ToString() },
            CheckInDate = "2024-12-20",
            CheckOutDate = "2024-12-22"
        };

        var roomId = Guid.Parse(model.Room.Id);
        _roomAvailabilityRepositoryMock
            .Setup(r => r.IsAvailableAsync(roomId, It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .ReturnsAsync(false);

        // Act
        var result = await _reservationService.CreateReservationAsync(model, Guid.NewGuid().ToString());

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public async Task CreateReservationAsync_ShouldReturnTrue_WhenReservationIsSuccessful()
    {
        // Arrange
        var model = new AddReservationFormModel
        {
            Room = new AddRoomToReservationViewModel { Id = roomData[0].ToString() },
            CheckInDate = "2024-12-20",
            CheckOutDate = "2024-12-22"
        };

        var roomId = Guid.Parse(model.Room.Id);
        _roomAvailabilityRepositoryMock
            .Setup(r => r.IsAvailableAsync(roomId, It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .ReturnsAsync(true);

        _reservationRepositoryMock
            .Setup(r => r.AddAsync(It.IsAny<Reservation>()))
            .Returns(Task.CompletedTask);

        _roomAvailabilityRepositoryMock
            .Setup(r => r.BlockRoomDatesAsync(roomId, It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _reservationService.CreateReservationAsync(model, Guid.NewGuid().ToString());

        // Assert
        Assert.IsTrue(result);
        _reservationRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Reservation>()), Times.Once);
        _roomAvailabilityRepositoryMock.Verify(r => r.BlockRoomDatesAsync(roomId, It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once);
    }

    [Test]
    public async Task GetAllByUserIdOrderedByCheckInAsync_ShouldReturnReservations()
    {
        // Arrange
        var userId = Guid.NewGuid().ToString();
        var reservations = new List<Reservation>
        {
            new Reservation
            {
                Id = Guid.NewGuid(),
                GuestId = Guid.Parse(userId),
                CheckInDate = new DateTime(2024, 12, 20),
                CheckOutDate = new DateTime(2024, 12, 22),
                TotalPrice = 200m,
                Room = new Room { RoomNumber = "101" }
            }
        };

        _reservationRepositoryMock
            .Setup(r => r.GetAllAttached())
            .Returns(reservations.AsQueryable().BuildMock());

        // Act
        var result = await _reservationService.GetAllByUserIdOrderedByCheckInAsync(userId);

        // Assert
        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("101", result.First().RoomNumber);
    }

    [Test]
    public async Task EditReservationAsync_ShouldReturnFalse_WhenDatesAreUnavailable()
    {
        // Arrange
        var model = new EditReservationFormModel
        {
            Id = Guid.NewGuid().ToString(),
            RoomId = Guid.NewGuid().ToString(),
            CheckInDate = "2024-12-20",
            CheckOutDate = "2024-12-22"
        };

        _roomAvailabilityRepositoryMock
            .Setup(r => r.IsAvailableAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .ReturnsAsync(false);

        // Act
        var result = await _reservationService.EditReservationAsync(model);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public async Task EditReservationAsync_ShouldReturnTrue_WhenDatesAreValid()
    {
        // Arrange
        var reservationId = Guid.NewGuid();
        var roomId = Guid.NewGuid();

        var reservation = new Reservation
        {
            Id = reservationId,
            RoomId = roomId,
            CheckInDate = new DateTime(2024, 12, 20),
            CheckOutDate = new DateTime(2024, 12, 22),
            TotalPrice = 200m
        };

        _reservationRepositoryMock
            .Setup(r => r.GetByIdAsync(reservationId))
            .ReturnsAsync(reservation);

        _roomAvailabilityRepositoryMock
            .Setup(r => r.IsAvailableAsync(roomId, It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .ReturnsAsync(true);

        _roomAvailabilityRepositoryMock
            .Setup(r => r.BlockRoomDatesAsync(roomId, It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .Returns(Task.CompletedTask);

        _reservationRepositoryMock
            .Setup(r => r.UpdateAsync(It.IsAny<Reservation>()))
            .ReturnsAsync(true);

        var model = new EditReservationFormModel
        {
            Id = reservationId.ToString(),
            RoomId = roomId.ToString(),
            CheckInDate = "2024-12-23",
            CheckOutDate = "2024-12-25"
        };

        // Act
        var result = await _reservationService.EditReservationAsync(model);

        // Assert
        Assert.IsTrue(result);
        _reservationRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Reservation>()), Times.Once);
    }
}
