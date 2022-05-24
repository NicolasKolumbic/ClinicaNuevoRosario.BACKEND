﻿using ClinicaNuevoRosario.Domain;

namespace ClinicaNuevoRosario.Application.Contracts.Persistence
{
    public interface IDoctorRepository: IAsyncRepository<Doctor>
    {
       public Task<IQueryable<Doctor>> GetByName(string name);
    }
}
