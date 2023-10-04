using AutoMapper;
using Lunchroom.Application.Student;
using Lunchroom.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Services
{
    public interface IStudentService
    {
        Task StudentsRaportToFile(IEnumerable<StudentDto> students, string path);
    }

    public class StudentService : IStudentService
    {
        private readonly ILunchroomRepository _lunchroomRepository;
        private readonly IMapper _mapper;

        public StudentService(ILunchroomRepository lunchroomRepository, IMapper mapper)
        {
            _lunchroomRepository = lunchroomRepository;
            _mapper = mapper;
        }

        public async Task StudentsRaportToFile(IEnumerable<StudentDto> students, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                await writer.WriteLineAsync("Firstname, Lastname, Lunches number, Payment");
                foreach (StudentDto student in students)
                {
                    string studentLine = student.FirstName + student.LastName.PadLeft(10) + student.Payment.ToString().PadLeft(10);
                    await writer.WriteLineAsync(studentLine);
                }
                
            }
            
        }

    }
}
