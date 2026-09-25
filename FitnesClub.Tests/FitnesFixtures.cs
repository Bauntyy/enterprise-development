using FitnesClub.Domain.Entities;
using FitnesClub.Domain.Enums;

namespace FitnesClub.Tests;

public class FitnesFixtures
{
    public List<Specialization> Specializations { get; } =
    [
        new() { Name = "Фитнес" },
        new() { Name = "Йога" },
        new() { Name = "Силовые тренировки" },
        new() { Name = "Пилатес" },
        new() { Name = "Кардио" },
        new() { Name = "Стретчинг" },
        new() { Name = "Функциональный тренинг" },
        new() { Name = "Кроссфит" },
        new() { Name = "Бокс" },
        new() { Name = "Танцевальные тренировки" }
    ];


    public List<Trainer> Trainers { get; } = [];
    public List<Member> Members { get; } = [];
    public List<Booking> Bookings { get; } = [];

    public FitnesFixtures()
    {
        Trainers.AddRange(
        [
            new() { PassportNumber = "1000000001", FirstName = "Алексей", LastName = "Смирнов", Gender = Gender.Male, BirthDate = new(1985, 3, 15), SpecializationId = Specializations[0].Id, Specialization = Specializations[0], WorkExperienceYears = 8, PhoneNumber = "+79990000001" },
            new() { PassportNumber = "1000000002", FirstName = "Елена", LastName = "Волкова", Gender = Gender.Female, BirthDate = new(1990, 7, 20), SpecializationId = Specializations[1].Id, Specialization = Specializations[1], WorkExperienceYears = 6, PhoneNumber = "+79990000002" },
            new() { PassportNumber = "1000000003", FirstName = "Дмитрий", LastName = "Соколов", Gender = Gender.Male, BirthDate = new(1982, 11, 5), SpecializationId = Specializations[2].Id, Specialization = Specializations[2], WorkExperienceYears = 12, PhoneNumber = "+79990000003" },
            new() { PassportNumber = "1000000004", FirstName = "Ольга", LastName = "Морозова", Gender = Gender.Female, BirthDate = new(1992, 2, 10), SpecializationId = Specializations[3].Id, Specialization = Specializations[3], WorkExperienceYears = 3, PhoneNumber = "+79990000004" },
            new() { PassportNumber = "1000000005", FirstName = "Игорь", LastName = "Новиков", Gender = Gender.Male, BirthDate = new(1980, 9, 25), SpecializationId = Specializations[4].Id, Specialization = Specializations[4], WorkExperienceYears = 15, PhoneNumber = "+79990000005" },
            new() { PassportNumber = "1000000006", FirstName = "Анна", LastName = "Федорова", Gender = Gender.Female, BirthDate = new(1995, 4, 18), SpecializationId = Specializations[5].Id, Specialization = Specializations[5], WorkExperienceYears = 2, PhoneNumber = "+79990000006" },
            new() { PassportNumber = "1000000007", FirstName = "Максим", LastName = "Козлов", Gender = Gender.Male, BirthDate = new(1988, 6, 12), SpecializationId = Specializations[6].Id, Specialization = Specializations[6], WorkExperienceYears = 7, PhoneNumber = "+79990000007" },
            new() { PassportNumber = "1000000008", FirstName = "Татьяна", LastName = "Лебедева", Gender = Gender.Female, BirthDate = new(1986, 12, 1), SpecializationId = Specializations[7].Id, Specialization = Specializations[7], WorkExperienceYears = 10, PhoneNumber = "+79990000008" },
            new() { PassportNumber = "1000000009", FirstName = "Сергей", LastName = "Петров", Gender = Gender.Male, BirthDate = new(1984, 1, 30), SpecializationId = Specializations[8].Id, Specialization = Specializations[8], WorkExperienceYears = 9, PhoneNumber = "+79990000009" },
            new() { PassportNumber = "1000000010", FirstName = "Мария", LastName = "Васильева", Gender = Gender.Female, BirthDate = new(1991, 8, 22), SpecializationId = Specializations[9].Id, Specialization = Specializations[9], WorkExperienceYears = 4, PhoneNumber = "+79990000010" }
        ]);

        Members.AddRange(
        [
            new() { PassportNumber = "2000000001", FirstName = "Иван", LastName = "Иванов", Gender = Gender.Male, BirthDate = new(1995, 5, 10), PhoneNumber = "+79991111111", MembershipStartDate = DateTime.Today.AddMonths(-2), MembershipEndDate = DateTime.Today.AddMonths(1) },
            new() { PassportNumber = "2000000002", FirstName = "Анна", LastName = "Петрова", Gender = Gender.Female, BirthDate = new(1998, 8, 15), PhoneNumber = "+79991111112", MembershipStartDate = DateTime.Today.AddMonths(-3), MembershipEndDate = DateTime.Today.AddMonths(2) },
            new() { PassportNumber = "2000000003", FirstName = "Алексей", LastName = "Сидоров", Gender = Gender.Male, BirthDate = new(1992, 1, 20), PhoneNumber = "+79991111113", MembershipStartDate = DateTime.Today.AddMonths(-6), MembershipEndDate = DateTime.Today.AddDays(-10) },
            new() { PassportNumber = "2000000004", FirstName = "Екатерина", LastName = "Смирнова", Gender = Gender.Female, BirthDate = new(1997, 3, 12), PhoneNumber = "+79991111114", MembershipStartDate = DateTime.Today.AddMonths(-1), MembershipEndDate = DateTime.Today.AddMonths(3) },
            new() { PassportNumber = "2000000005", FirstName = "Михаил", LastName = "Кузнецов", Gender = Gender.Male, BirthDate = new(1989, 10, 3), PhoneNumber = "+79991111115", MembershipStartDate = DateTime.Today.AddMonths(-8), MembershipEndDate = DateTime.Today.AddDays(-30) },
            new() { PassportNumber = "2000000006", FirstName = "Ольга", LastName = "Попова", Gender = Gender.Female, BirthDate = new(1994, 6, 25), PhoneNumber = "+79991111116", MembershipStartDate = DateTime.Today.AddMonths(-2), MembershipEndDate = DateTime.Today.AddMonths(1) },
            new() { PassportNumber = "2000000007", FirstName = "Артем", LastName = "Васильев", Gender = Gender.Male, BirthDate = new(1990, 9, 17), PhoneNumber = "+79991111117", MembershipStartDate = DateTime.Today.AddMonths(-5), MembershipEndDate = DateTime.Today.AddDays(-5) },
            new() { PassportNumber = "2000000008", FirstName = "Наталья", LastName = "Соколова", Gender = Gender.Female, BirthDate = new(1996, 11, 8), PhoneNumber = "+79991111118", MembershipStartDate = DateTime.Today.AddMonths(-1), MembershipEndDate = DateTime.Today.AddMonths(2) },
            new() { PassportNumber = "2000000009", FirstName = "Павел", LastName = "Михайлов", Gender = Gender.Male, BirthDate = new(1987, 4, 14), PhoneNumber = "+79991111119", MembershipStartDate = DateTime.Today.AddMonths(-7), MembershipEndDate = DateTime.Today.AddDays(-15) },
            new() { PassportNumber = "2000000010", FirstName = "Ирина", LastName = "Новикова", Gender = Gender.Female, BirthDate = new(1993, 12, 30), PhoneNumber = "+79991111120", MembershipStartDate = DateTime.Today.AddMonths(-2), MembershipEndDate = DateTime.Today.AddMonths(1) } 
        ]);

        var now = DateTime.Now;

        Bookings.AddRange(
        [
            new() { MemberId = Members[0].Id, Member = Members[0], TrainerId = Trainers[0].Id, Trainer = Trainers[0], LessonDateTime = now.AddDays(1), Duration = TimeSpan.FromHours(1), RoomName = "Зал №1", IsTrial = false },
            new() { MemberId = Members[1].Id, Member = Members[1], TrainerId = Trainers[1].Id, Trainer = Trainers[1], LessonDateTime = now.AddDays(2), Duration = TimeSpan.FromHours(2), RoomName = "Зал №2", IsTrial = true },
            new() { MemberId = Members[2].Id, Member = Members[2], TrainerId = Trainers[2].Id, Trainer = Trainers[2], LessonDateTime = now.AddDays(-2), Duration = TimeSpan.FromHours(1), RoomName = "Зал №1", IsTrial = false },
            new() { MemberId = Members[3].Id, Member = Members[3], TrainerId = Trainers[0].Id, Trainer = Trainers[0], LessonDateTime = now.AddDays(3), Duration = TimeSpan.FromHours(1), RoomName = "Зал №1", IsTrial = false },
            new() { MemberId = Members[4].Id, Member = Members[4], TrainerId = Trainers[2].Id, Trainer = Trainers[2], LessonDateTime = now.AddDays(4), Duration = TimeSpan.FromHours(2), RoomName = "Зал №3", IsTrial = true },
            new() { MemberId = Members[5].Id, Member = Members[5], TrainerId = Trainers[0].Id, Trainer = Trainers[0], LessonDateTime = now.AddDays(5), Duration = TimeSpan.FromHours(1), RoomName = "Зал №1", IsTrial = false },
            new() { MemberId = Members[6].Id, Member = Members[6], TrainerId = Trainers[3].Id, Trainer = Trainers[3], LessonDateTime = now.AddDays(-5), Duration = TimeSpan.FromHours(1), RoomName = "Зал №2", IsTrial = false },
            new() { MemberId = Members[7].Id, Member = Members[7], TrainerId = Trainers[4].Id, Trainer = Trainers[4], LessonDateTime = now.AddDays(6), Duration = TimeSpan.FromHours(2), RoomName = "Зал №3", IsTrial = false },
            new() { MemberId = Members[8].Id, Member = Members[8], TrainerId = Trainers[2].Id, Trainer = Trainers[2], LessonDateTime = now.AddDays(7), Duration = TimeSpan.FromHours(1), RoomName = "Зал №1", IsTrial = true },
            new() { MemberId = Members[9].Id, Member = Members[9], TrainerId = Trainers[4].Id, Trainer = Trainers[4], LessonDateTime = now.AddDays(8), Duration = TimeSpan.FromHours(1), RoomName = "Зал №3", IsTrial = false }
        ]);

        foreach (var booking in Bookings)
        {
            booking.Member.Bookings.Add(booking);
            booking.Trainer.Bookings.Add(booking);
        }
    }
}