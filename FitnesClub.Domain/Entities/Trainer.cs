namespace FitnesClub.Domain.Entities;

/// <summary>
/// Тренер фитнес-клуба
/// </summary>
public class Trainer
{
    /// <summary>
    /// Идентификатор тренера
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Имя тренера
    /// </summary>
    /// <example>Алексей</example>
    public required string FirstName { get; set; }

    /// <summary>
    /// Фамилия тренера
    /// </summary>
    /// <example>Смирнов</example>
    public required string LastName { get; set; }

    /// <summary>
    /// Специализация тренера
    /// </summary>
    /// <example>Силовой тренинг</example>
    public required string Specialization { get; set; }

    /// <summary>
    /// Почасовая ставка тренера
    /// </summary>
    /// <example>2000</example>
    public required decimal HourlyRate { get; set; }

    /// <summary>
    /// Дата приема на работу
    /// </summary>
    public required DateTime HireDate { get; set; }

    /// <summary>
    /// Номер телефона тренера
    /// </summary>
    /// <example>+79001110001</example>
    public required string PhoneNumber { get; set; }

    /// <summary>
    /// Адрес электронной почты тренера
    /// </summary>
    /// <example>trainer@test.com</example>
    public string? Email { get; set; }

    /// <summary>
    /// Список занятий тренера
    /// </summary>
    public List<Schedule> Schedules { get; set; } = [];
}