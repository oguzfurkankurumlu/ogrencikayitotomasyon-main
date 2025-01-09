using System.Collections.Generic;
using System.Linq;
using summerschool.DMO;
using summerschool.DTO;

public interface IStudentService
{
    bool AddStudent(StudentDTO newStudent);
    bool DeleteStudent(int id);
    bool AddBalance(int id, decimal amount);
    List<StudentDTO> GetAllStudents();
}




public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public bool AddStudent(StudentDTO newStudent)
    {
        var student = new TableStudent
        {
            Stname = newStudent.Stname,
            Stlastname = newStudent.Stlastname,
            Stnumber = newStudent.Stnumber,
            Stmail = newStudent.Stmail,
            Stbalance = newStudent.Stbalance
        };
        return _studentRepository.AddStudent(student);
    }

    public bool DeleteStudent(int id)
    {
        return _studentRepository.DeleteStudent(id);
    }

    public bool AddBalance(int id, decimal amount)
    {
        return _studentRepository.AddBalance(id, amount);
    }

    public List<StudentDTO> GetAllStudents()
    {
        var students = _studentRepository.GetAllStudents();
        return students.Select(s => new StudentDTO
        {
            Stid = s.Stid,
            Stname = s.Stname,
            Stlastname = s.Stlastname,
            Stnumber = s.Stnumber,
            Stmail = s.Stmail,
            Stbalance = s.Stbalance ?? 0
        }).ToList();
    }
}


