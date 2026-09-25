namespace FitnesClub.Domain.Entities;

/// <summary>
/// Тренер фитнес-клуба
/// </summary>
public class Trainer : Person
{
    /// <summary>
    /// Идентификатор специализации тренера
    /// </summary>
    public required Guid SpecializationId { get; set; }

    /// <summary>
    /// Специализация тренера
    /// </summary>
    public Specialization Specialization { get; set; } = null!;

    /// <summary>
    /// Стаж работы тренера в годах
    /// </summary>
    public required int WorkExperienceYears { get; set; }

    /// <summary>
    /// Номер телефона тренера
    /// </summary>
    /// <example>+79998887766</example>
    public required string PhoneNumber { get; set; }

    /// <summary>
    /// Электронная почта тренера
    /// </summary>
    /// <example>trainer@test.com</example>
    public string? Email { get; set; }

    /// <summary>
    /// Записи клиентов на занятия с тренером.
    /// </summary>
    public List<Booking> Bookings { get; set; } = [];
}