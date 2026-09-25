using FitnesClub.Domain.Entities;
using FitnesClub.Domain.Enums;

namespace FitnesClub.Tests;

/// <summary>
/// Тестовый набор данных для проверки LINQ-запросов
/// </summary>
public class FitnesFixtures
{
    public readonly List<Trainer> Trainers;
    public readonly List<FitnesClass> Classes;
    public readonly List<Member> Members;
    public readonly List<Schedule> Schedules;
    public readonly List<Booking> Bookings;

    public FitnesFixtures()
    {
        Trainers = GetTrainers();
        Classes = GetFitnesClasses();
        Members = GetMembers();
        Schedules = GetSchedules(Classes, Trainers);
        Bookings = GetBookings(Members, Schedules);
    }

    /// <summary>
    /// Создаёт список из 10 тренеров
    /// </summary>
    private static List<Trainer> GetTrainers() =>
    [
        new Trainer { Id = Guid.NewGuid(), FirstName = "Алексей", LastName = "Смирнов", Specialization = "Силовой тренинг", HourlyRate = 2000m, HireDate = new DateTime(2020, 1, 15), PhoneNumber = "+79001110001" },
        new Trainer { Id = Guid.NewGuid(), FirstName = "Елена", LastName = "Волкова", Specialization = "Йога и Растяжка", HourlyRate = 1800m, HireDate = new DateTime(2021, 3, 10), PhoneNumber = "+79001110002" },
        new Trainer { Id = Guid.NewGuid(), FirstName = "Дмитрий", LastName = "Соколов", Specialization = "Кроссфит", HourlyRate = 2200m, HireDate = new DateTime(2019, 5, 20), PhoneNumber = "+79001110003" },
        new Trainer { Id = Guid.NewGuid(), FirstName = "Ольга", LastName = "Морозова", Specialization = "Пилатес", HourlyRate = 1700m, HireDate = new DateTime(2022, 2, 1), PhoneNumber = "+79001110004" },
        new Trainer { Id = Guid.NewGuid(), FirstName = "Игорь", LastName = "Новиков", Specialization = "Бокс", HourlyRate = 2500m, HireDate = new DateTime(2018, 11, 11), PhoneNumber = "+79001110005" },
        new Trainer { Id = Guid.NewGuid(), FirstName = "Анна", LastName = "Федорова", Specialization = "Танцы и Зумба", HourlyRate = 1600m, HireDate = new DateTime(2023, 4, 15), PhoneNumber = "+79001110006" },
        new Trainer { Id = Guid.NewGuid(), FirstName = "Максим", LastName = "Козлов", Specialization = "Тренажерный зал", HourlyRate = 1900m, HireDate = new DateTime(2021, 8, 30), PhoneNumber = "+79001110007" },
        new Trainer { Id = Guid.NewGuid(), FirstName = "Татьяна", LastName = "Лебедева", Specialization = "Аквааэробика", HourlyRate = 2100m, HireDate = new DateTime(2020, 6, 12), PhoneNumber = "+79001110008" },
        new Trainer { Id = Guid.NewGuid(), FirstName = "Сергей", LastName = "Петров", Specialization = "ТРИАТЛОН и Кардио", HourlyRate = 2300m, HireDate = new DateTime(2019, 9, 5), PhoneNumber = "+79001110009" },
        new Trainer { Id = Guid.NewGuid(), FirstName = "Мария", LastName = "Васильева", Specialization = "Стретчинг", HourlyRate = 1750m, HireDate = new DateTime(2022, 10, 1), PhoneNumber = "+79001110010" }
    ];

    /// <summary>
    /// Создаёт список из 10 направлений занятий
    /// </summary>
    private static List<FitnesClass> GetFitnesClasses() =>
    [
        new FitnesClass { Id = Guid.NewGuid(), Name = "Power Body", Description = "Силовая тренировка на все группы мышц", DurationMinutes = 60, Capacity = 15 },
        new FitnesClass { Id = Guid.NewGuid(), Name = "Hatha Yoga", Description = "Классическая йога для ума и тела", DurationMinutes = 90, Capacity = 10 },
        new FitnesClass { Id = Guid.NewGuid(), Name = "Crossfit WOD", Description = "Высокоинтенсивный функциональный тренинг", DurationMinutes = 45, Capacity = 12 },
        new FitnesClass { Id = Guid.NewGuid(), Name = "Pilates Mat", Description = "Укрепление корсета и осанки", DurationMinutes = 60, Capacity = 8 },
        new FitnesClass { Id = Guid.NewGuid(), Name = "Boxing Club", Description = "Отработка техники ударов и выносливости", DurationMinutes = 60, Capacity = 10 },
        new FitnesClass { Id = Guid.NewGuid(), Name = "Zumba Dance", Description = "Танцевальная кардио-тренировка", DurationMinutes = 55, Capacity = 20 },
        new FitnesClass { Id = Guid.NewGuid(), Name = "Aqua Fitness", Description = "Занятия в бассейне с сопротивлением воды", DurationMinutes = 45, Capacity = 12 },
        new FitnesClass { Id = Guid.NewGuid(), Name = "Stretching", Description = "Глубокая растяжка и расслабление мышц", DurationMinutes = 50, Capacity = 15 },
        new FitnesClass { Id = Guid.NewGuid(), Name = "Spinning", Description = "Интенсивная тренировка на сайкл-тренажерах", DurationMinutes = 45, Capacity = 14 },
        new FitnesClass { Id = Guid.NewGuid(), Name = "TRX Suspension", Description = "Тренировка с собственным весом на петлях TRX", DurationMinutes = 60, Capacity = 10 }
    ];

    /// <summary>
    /// Создаёт список из 10 клиентов
    /// </summary>
    private static List<Member> GetMembers() =>
    [
        new Member { Id = Guid.NewGuid(), FirstName = "Иван", LastName = "Иванов", PhoneNumber = "+79991112233", Email = "ivan@test.com", BirthDate = new DateTime(1995, 5, 20), JoinDate = DateTime.Now.AddMonths(-12), MembershipType = MembershipType.VIP },
        new Member { Id = Guid.NewGuid(), FirstName = "Анна", LastName = "Петрова", PhoneNumber = "+79992223344", Email = "anna@test.com", BirthDate = new DateTime(2000, 3, 15), JoinDate = DateTime.Now.AddMonths(-6), MembershipType = MembershipType.Premium },
        new Member { Id = Guid.NewGuid(), FirstName = "Алексей", LastName = "Сидоров", PhoneNumber = "+79993334455", Email = null, BirthDate = new DateTime(1988, 11, 2), JoinDate = DateTime.Now.AddMonths(-3), MembershipType = MembershipType.Standard },
        new Member { Id = Guid.NewGuid(), FirstName = "Екатерина", LastName = "Смирнова", PhoneNumber = "+79994445566", Email = "katya@test.com", BirthDate = new DateTime(1997, 8, 19), JoinDate = DateTime.Now.AddMonths(-8), MembershipType = MembershipType.Premium },
        new Member { Id = Guid.NewGuid(), FirstName = "Михаил", LastName = "Кузнецов", PhoneNumber = "+79995556677", Email = "misha@test.com", BirthDate = new DateTime(1992, 1, 30), JoinDate = DateTime.Now.AddMonths(-1), MembershipType = MembershipType.Standard },
        new Member { Id = Guid.NewGuid(), FirstName = "Ольга", LastName = "Попова", PhoneNumber = "+79996667788", Email = null, BirthDate = new DateTime(2002, 7, 7), JoinDate = DateTime.Now.AddMonths(-2), MembershipType = MembershipType.Standard },
        new Member { Id = Guid.NewGuid(), FirstName = "Артем", LastName = "Васильев", PhoneNumber = "+79997778899", Email = "artem@test.com", BirthDate = new DateTime(1985, 4, 12), JoinDate = DateTime.Now.AddMonths(-24), MembershipType = MembershipType.VIP },
        new Member { Id = Guid.NewGuid(), FirstName = "Наталья", LastName = "Соколова", PhoneNumber = "+79998889900", Email = "natasha@test.com", BirthDate = new DateTime(1999, 12, 5), JoinDate = DateTime.Now.AddMonths(-5), MembershipType = MembershipType.Premium },
        new Member { Id = Guid.NewGuid(), FirstName = "Павел", LastName = "Михайлов", PhoneNumber = "+79999990011", Email = "pavel@test.com", BirthDate = new DateTime(1991, 9, 25), JoinDate = DateTime.Now.AddMonths(-15), MembershipType = MembershipType.VIP },
        new Member { Id = Guid.NewGuid(), FirstName = "Ирина", LastName = "Новикова", PhoneNumber = "+79990001122", Email = null, BirthDate = new DateTime(2003, 2, 14), JoinDate = DateTime.Now.AddMonths(-4), MembershipType = MembershipType.Standard }
    ];

    /// <summary>
    /// Создаёт список из 10 занятий в расписании
    /// </summary>
    private static List<Schedule> GetSchedules(List<FitnesClass> classes, List<Trainer> trainers)
    {
        var list = new List<Schedule>();

        for (int i = 0; i < 10; i++)
        {
            var schedule = new Schedule
            {
                Id = Guid.NewGuid(),
                FitnesClassId = classes[i].Id,
                FitnesClass = classes[i],
                TrainerId = trainers[i].Id,
                Trainer = trainers[i],
                StartTime = DateTime.Now.AddDays(i - 5).AddHours(10 + i),
                RoomNumber = $"Зал №{(i % 3) + 1}"
            };

            classes[i].Schedules.Add(schedule);
            trainers[i].Schedules.Add(schedule);

            list.Add(schedule);
        }

        return list;
    }

    /// <summary>
    /// Создаёт список из 10 бронирований/записей
    /// </summary>
    private static List<Booking> GetBookings(List<Member> members, List<Schedule> schedules)
    {
        var list = new List<Booking>();
        var statuses = new[] { BookingStatus.Confirmed, BookingStatus.Attended, BookingStatus.Pending, BookingStatus.Canceled };

        for (int i = 0; i < 10; i++)
        {
            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                MemberId = members[i].Id,
                Member = members[i],
                ScheduleId = schedules[i % schedules.Count].Id,
                Schedule = schedules[i % schedules.Count],
                BookingDate = DateTime.Now.AddDays(-i),
                Status = statuses[i % statuses.Length]
            };

            members[i].Bookings.Add(booking);
            schedules[i % schedules.Count].Bookings.Add(booking);

            list.Add(booking);
        }

        return list;
    }
}