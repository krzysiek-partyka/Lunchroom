//using AutoMapper;
//using Lunchroom.Domain.Interfaces;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Lunchroom.Application.Student.Queries.GetAllStudents
//{
//    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDto>>
//    {
//        private readonly IStudentRepository _studentRepository;
//        private readonly IMapper _mapper;

//        public GetAllStudentsQueryHandler(IStudentRepository studentRepository, IMapper mapper)
//        {
//            _studentRepository = studentRepository;
//            _mapper = mapper;
//        }
//        public async Task<IEnumerable<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
//        {
//            //var students = await _studentRepository.GetAll(request.EncodedName);

//            //var dtos = _mapper.Map<IEnumerable<StudentDto>>(students);
//            //return dtos;
//        }
//    }
//}
