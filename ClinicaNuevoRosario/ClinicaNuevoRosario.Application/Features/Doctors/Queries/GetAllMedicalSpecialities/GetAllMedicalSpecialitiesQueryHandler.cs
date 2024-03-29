﻿using AutoMapper;
using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models.Doctors;
using MediatR;

namespace ClinicaNuevoRosario.Application.Features.Doctors.Queries.GetAllMedicalSpecialities
{
    public class GetAllMedicalSpecialitiesQueryHandler : IRequestHandler<GetAllMedicalSpecialitiesQuery, List<MedicalSpecialtyDto>>
    {
        private readonly IMedicalSpecialitiesRepository _medicalSpecialitiesRepository;
        private readonly IMapper _mapper;

        public GetAllMedicalSpecialitiesQueryHandler(IMedicalSpecialitiesRepository medicalSpecialitiesRepository, IMapper mapper)
        {
            this._medicalSpecialitiesRepository = medicalSpecialitiesRepository;
            _mapper = mapper;
        }

        public async Task<List<MedicalSpecialtyDto>> Handle(GetAllMedicalSpecialitiesQuery request, CancellationToken cancellationToken)
        {
            var medicalSpecialties = await _medicalSpecialitiesRepository.GetAllAsync();
            var medicalSpeacialityResponses = _mapper.Map<List<MedicalSpecialtyDto>>(medicalSpecialties.ToList());
            return medicalSpeacialityResponses;
        }
    }
}
