namespace FitnesClub.Domain.Entities;

/// <summary>
/// Занятие фитнес-клуба
/// </summary>
public class FitnesClass
{
    /// <summary>
    /// Идентификатор занятия
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Название занятия
    /// </summary>
    /// <example>Power Body</example>
    public required string Name { get; set; }

    /// <summary>
    /// Описание занятия
    /// </summary>
    /// <example>Силовая тренировка на все группы мышц</example>
    public string? Description { get; set; }

    /// <summary>
    /// Продолжительность занятия в минутах
    /// </summary>
    /// <example>60</example>
    public required int DurationMinutes { get; set; }

    /// <summary>
    /// Максимальное количество участников
    /// </summary>
    /// <example>15</example>
    public required int Capacity { get; set; }

    /// <summary>
    /// Расписание данного занятия
    /// </summary>
    public List<Schedule> Schedules { get; set; } = [];
}