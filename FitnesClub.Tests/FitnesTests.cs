using FitnesClub.Domain.Entities;
using FitnesClub.Domain.Enums;

namespace FitnesClub.Tests;

/// <summary>
/// Тесты LINQ-запросов к данным фитнес-клуба
/// </summary>
/// <param name="fixture">Тестовый набор данных</param>

public class QueriesTest(FitnesFixtures fixture) : IClassFixture<FitnesFixtures>
{
    private readonly List<Member> _members = fixture.Members;
    private readonly List<Trainer> _trainers = fixture.Trainers;
    private readonly List<FitnesClass> _classes = fixture.Classes;
    private readonly List<Schedule> _schedules = fixture.Schedules;
    private readonly List<Booking> _bookings = fixture.Bookings;

    /// <summary>
    /// Получение активных VIP клиентов с сортировкой по фамилии и имени
    /// </summary>
    [Fact]
    public void GetActiveVipMembers_OrderedByLastName()
    {
        var result = _members
            .Where(m =>
                m.IsActive &&
                m.MembershipType == MembershipType.VIP)
            .OrderBy(m => m.LastName)
            .ThenBy(m => m.FirstName)
            .ToList();

        Assert.Equal(3, result.Count);

        Assert.Equal("Васильев", result[0].LastName);
        Assert.Equal("Иванов", result[1].LastName);
        Assert.Equal("Михайлов", result[2].LastName);

        Assert.All(result, member =>
        {
            Assert.True(member.IsActive);
            Assert.Equal(MembershipType.VIP, member.MembershipType);
        });
    }

    /// <summary>
    /// Получение расписания конкретного тренера
    /// </summary>
    [Fact]
    public void GetSchedulesByTrainerId()
    {
        var targetTrainerId = _trainers[0].Id;

        var resultSchedules = _schedules
            .Where(s => s.TrainerId == targetTrainerId)
            .OrderBy(s => s.StartTime)
            .ToList();

        Assert.Single(resultSchedules);

        Assert.Equal(
            targetTrainerId,
            resultSchedules[0].TrainerId);

        Assert.Equal(
            _trainers[0].Id,
            resultSchedules[0].Trainer.Id);

        Assert.Equal(
            _classes[0].Id,
            resultSchedules[0].FitnesClassId);
    }

    /// <summary>
    /// Подсчёт количества бронирований по статусам
    /// </summary>
    [Fact]
    public void GetBookingCountsByStatus()
    {
        var statusCounts = _bookings
            .GroupBy(b => b.Status)
            .Select(g => new
            {
                Status = g.Key,
                Count = g.Count()
            })
            .ToDictionary(
                x => x.Status,
                x => x.Count);

        Assert.Equal(4, statusCounts.Count);

        Assert.Equal(
            3,
            statusCounts[BookingStatus.Confirmed]);

        Assert.Equal(
            3,
            statusCounts[BookingStatus.Attended]);

        Assert.Equal(
            2,
            statusCounts[BookingStatus.Pending]);

        Assert.Equal(
            2,
            statusCounts[BookingStatus.Canceled]);
    }

    /// <summary>
    /// Расчёт общей стоимости подтверждённых записей на основе почасовой ставки тренеров
    /// </summary>
    
    [Fact]
    public void GetTotalRevenueFromConfirmedBookings()
    {
        var totalRevenue = _bookings
            .Where(b =>
                b.Status == BookingStatus.Confirmed &&
                b.Schedule?.Trainer != null)
            .Sum(b => b.Schedule!.Trainer!.HourlyRate);

        Assert.Equal(6800m, totalRevenue);
    }

    /// <summary>
    /// Получение трёх самых популярных занятий по количеству бронирований
    /// </summary>
    [Fact]
    public void GetTopThreePopularClasses()
    {
        var topClasses = _bookings
            .Where(b => b.Schedule?.FitnesClass != null)
            .GroupBy(b => b.Schedule!.FitnesClass!)
            .OrderByDescending(g => g.Count())
            .ThenBy(g => g.Key.Name)
            .Take(3)
            .Select(g => new
            {
                FitnessClass = g.Key,
                BookingsCount = g.Count()
            })
            .ToList();

        Assert.Equal(3, topClasses.Count);

        Assert.All(
            topClasses,
            item => Assert.Equal(1, item.BookingsCount));

        Assert.Equal(
            new[]
            {
                "Aqua Fitness",
                "Boxing Club",
                "Crossfit WOD"
            },
            topClasses
                .Select(x => x.FitnessClass.Name)
                .ToArray());
    }

    /// <summary>
    /// Получение занятий с продолжительностью не менее 45 минут
    /// </summary>
    [Fact]
    public void GetClassesByMinimumDuration()
    {
        const int minDurationMinutes = 45;

        var resultClasses = _classes
            .Where(c => c.DurationMinutes >= minDurationMinutes)
            .OrderBy(c => c.DurationMinutes)
            .ThenBy(c => c.Name)
            .ToList();

        Assert.Equal(10, resultClasses.Count);

        Assert.All(
            resultClasses,
            fitnessClass =>
                Assert.True(
                    fitnessClass.DurationMinutes >=
                    minDurationMinutes));

        for (int i = 1; i < resultClasses.Count; i++)
        {
            Assert.True(
                resultClasses[i - 1].DurationMinutes <=
                resultClasses[i].DurationMinutes);
        }
    }
}