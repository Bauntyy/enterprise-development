using FitnesClub.Domain.Entities;

namespace FitnesClub.Tests;

public class FitnesTests
{
    private readonly FitnesFixtures _fixture = new();

    /// <summary>
    /// Вывести информацию о всех тренерах, стаж работы которых не менее 5 лет
    /// </summary>
    [Fact]
    public void Trainers_WithExperienceAtLeastFiveYears_ShouldBeReturned()
    {
        var trainers = _fixture.Trainers
            .Where(t => t.WorkExperienceYears >= 5)
            .ToList();

        Assert.NotEmpty(trainers);
        Assert.All(
            trainers,
            trainer => Assert.True(trainer.WorkExperienceYears >= 5));
    }

    /// <summary>
    /// Является ли зал доступным для записи в данный момент
    /// </summary>
    [Fact]
    public void Room_ShouldBeAvailable_WhenThereIsNoCurrentBooking()
    {
        var roomName = "Зал №1";
        var now = DateTime.Now;

        var isRoomAvailable = !_fixture.Bookings.Any(
            booking =>
                booking.RoomName == roomName &&
                booking.LessonDateTime <= now &&
                booking.LessonDateTime > now.AddHours(-1));

        Assert.True(isRoomAvailable);
    }

    /// <summary>
    /// Вывести информацию о клиентах у которых просрочен абонемент, упорядочить по ФИО
    /// </summary>
    [Fact]
    public void ExpiredMemberships_ShouldBeSortedByFullName()
    {
        var expiredMembers = _fixture.Members
            .Where(member => member.MembershipEndDate < DateTime.Today)
            .OrderBy(member => member.LastName)
            .ThenBy(member => member.FirstName)
            .ToList();

        Assert.NotEmpty(expiredMembers);

        Assert.Equal(
            expiredMembers.OrderBy(
                member => member.LastName)
                .ThenBy(member => member.FirstName),
            expiredMembers);
    }

    /// <summary>
    /// Вывести информацию о занятиях за текущий месяц, проходящих в выбранном зале
    /// </summary>
    [Fact]
    public void Bookings_ShouldBeReturnedForCurrentMonthAndSelectedRoom()
    {
        var roomName = "Зал №1";
        var today = DateTime.Today;

        var bookings = _fixture.Bookings
            .Where(booking =>
                booking.RoomName == roomName &&
                booking.LessonDateTime.Year == today.Year &&
                booking.LessonDateTime.Month == today.Month)
            .ToList();

        Assert.NotEmpty(bookings);

        Assert.All(
            bookings,
            booking =>
            {
                Assert.Equal(roomName, booking.RoomName);
                Assert.Equal(today.Year, booking.LessonDateTime.Year);
                Assert.Equal(today.Month, booking.LessonDateTime.Month);
            });
    }

    /// <summary>
    /// Вывести топ 5 наиболее популярных тренеров
    /// </summary>
    [Fact]
    public void TopFiveMostPopularTrainers_ShouldBeReturned()
    {
        var topFive = _fixture.Trainers
            .Select(trainer => new
            {
                Trainer = trainer,
                BookingCount = trainer.Bookings.Count
            })
            .OrderByDescending(x => x.BookingCount)
            .ThenBy(x => x.Trainer.LastName)
            .Take(5)
            .ToList();

        Assert.Equal(5, topFive.Count);

        Assert.True(
            topFive.Zip(
                    topFive.Skip(1),
                    (first, second) =>
                        first.BookingCount >= second.BookingCount)
                .All(result => result));
    }
}