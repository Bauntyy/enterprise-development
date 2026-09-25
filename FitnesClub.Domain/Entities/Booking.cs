using FitnesClub.Domain.Enums;

namespace FitnesClub.Domain.Entities;

/// <summary>
/// Бронирование занятия клиентом
/// </summary>
public class Booking
{
    /// <summary>
    /// Идентификатор бронирования
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public required Guid MemberId { get; set; }

    /// <summary>
    /// Клиент, создавший бронирование
    /// </summary>
    public Member Member { get; set; } = null!;

    /// <summary>
    /// Идентификатор расписания
    /// </summary>
    public required Guid ScheduleId { get; set; }

    /// <summary>
    /// Расписание забронированного занятия
    /// </summary>
    public Schedule Schedule { get; set; } = null!;

    /// <summary>
    /// Дата создания бронирования
    /// </summary>
    public required DateTime BookingDate { get; set; }

    /// <summary>
    /// Статус бронирования
    /// </summary>
    public BookingStatus Status { get; set; } = BookingStatus.Pending;
}