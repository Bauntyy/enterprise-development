namespace FitnesClub.Tests;

public class FitnesTests(FitnesFixtures fixture) : IClassFixture<FitnesFixtures>
{
    private static readonly DateTime date =
    new DateTime(2026, 9, 28, 12, 0, 0);

    /// <summary>
    /// Вывести информацию о всех тренерах, стаж работы которых не менее 5 лет
    /// </summary>
    [Fact]
    public void Trainers_WithExperienceAtLeastFiveYears_ShouldBeReturned()
    {
        var expected = new[]
    {
        fixture.Trainers[0],
        fixture.Trainers[1],
        fixture.Trainers[2],
        fixture.Trainers[4],
        fixture.Trainers[6],
        fixture.Trainers[7],
        fixture.Trainers[8]
    };

        var trainers = fixture.Trainers
            .Where(trainer => trainer.WorkExperienceYears >= 5)
            .ToList();

        Assert.Equal(expected, trainers);
    }

    /// <summary>
    /// Является ли зал доступным для записи в данный момент
    /// </summary>
    [Fact]
    public void Room_ShouldBeAvailable_WhenThereIsNoCurrentBooking()
    {
        var roomName = "Зал №1";

        var isRoomAvailable = !fixture.Bookings.Any(
            booking =>
                booking.RoomName == roomName &&
                booking.LessonDateTime <= date &&
                booking.LessonDateTime.Add(booking.Duration) > date);

        Assert.True(isRoomAvailable);
    }

    /// <summary>
    /// Вывести информацию о клиентах у которых просрочен абонемент, упорядочить по ФИО
    /// </summary>
    [Fact]
    public void ExpiredMemberships_ShouldBeSortedByFullName()
    {
        var expected = new[]
        {
            fixture.Members[6],
            fixture.Members[4],
            fixture.Members[8],
            fixture.Members[2]
        };

        var expiredMembers = fixture.Members
        .Where(member => member.MembershipEndDate < date)
        .OrderBy(member => member.LastName)
        .ThenBy(member => member.FirstName)
        .ToList();

        Assert.Equal(expected, expiredMembers);
    }

    /// <summary>
    /// Вывести информацию о занятиях за текущий месяц, проходящих в выбранном зале
    /// </summary>
    [Fact]
    public void Bookings_ShouldBeReturnedForCurrentMonthAndSelectedRoom()
    {
        var roomName = "Зал №1";

        var expected = new[]
        {
        fixture.Bookings[0],
        fixture.Bookings[2]
    };

        var bookings = fixture.Bookings
            .Where(booking =>
                booking.RoomName == roomName &&
                booking.LessonDateTime.Year == date.Year &&
                booking.LessonDateTime.Month == date.Month)
            .ToList();

        Assert.Equal(expected, bookings);
    }

    /// <summary>
    /// Вывести топ 5 наиболее популярных тренеров
    /// </summary>
    [Fact]
    public void TopFiveMostPopularTrainers_ShouldBeReturned()
    {
        var expected = new[]
        {
        fixture.Trainers[0],
        fixture.Trainers[2],
        fixture.Trainers[4],
        fixture.Trainers[1],
        fixture.Trainers[3]
    };

        var topFive = fixture.Trainers
            .Select(trainer => new
            {
                Trainer = trainer,
                BookingCount = trainer.Bookings.Count
            })
            .OrderByDescending(x => x.BookingCount)
            .ThenBy(x => x.Trainer.LastName)
            .Take(5)
            .Select(x => x.Trainer)
            .ToList();

        Assert.Equal(expected, topFive);
    }
}