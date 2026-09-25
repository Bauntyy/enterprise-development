namespace FitnesClub.Domain.Entities;

/// <summary>
/// Расписание занятия фитнес-клуба
/// </summary>
public class Schedule
{
    /// <summary>
    /// Идентификатор расписания
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Идентификатор занятия
    /// </summary>
    public required Guid FitnesClassId { get; set; }

    /// <summary>
    /// Занятие, указанное в расписании
    /// </summary>
    public FitnesClass FitnesClass { get; set; } = null!;

    /// <summary>
    /// Идентификатор тренера
    /// </summary>
    public required Guid TrainerId { get; set; }

    /// <summary>
    /// Тренер, проводящий занятие
    /// </summary>
    public Trainer Trainer { get; set; } = null!;

    /// <summary>
    /// Дата и время начала занятия
    /// </summary>
    public required DateTime StartTime { get; set; }

    /// <summary>
    /// Номер зала, в котором проводится занятие
    /// </summary>
    /// <example>Зал №1</example>
    public string? RoomNumber { get; set; }

    /// <summary>
    /// Список бронирований на занятие
    /// </summary>
    public List<Booking> Bookings { get; set; } = [];
}