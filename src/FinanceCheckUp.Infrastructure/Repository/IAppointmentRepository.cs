using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;

namespace FinanceCheckUp.Infrastructure.Repository;

public interface IAppointmentRepository : IGenericRepository<Appointment, int>
{ }