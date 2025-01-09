using System.Collections.Generic;
using summerschool.DMO;

public interface IStudentRepository
{
    bool AddStudent(TableStudent student);
    bool DeleteStudent(int id);
    bool AddBalance(int id, decimal amount);
    List<TableStudent> GetAllStudents();
}


public class StudentRepository : IStudentRepository
{
    private readonly SummerSchoolContext _context;

    public StudentRepository(SummerSchoolContext context)
    {
        _context = context;
    }

    public bool AddStudent(TableStudent student)
    {
        _context.TableStudents.Add(student);
        _context.SaveChanges();
        return true;
    }

    public bool DeleteStudent(int id)
    {
        var student = _context.TableStudents.FirstOrDefault(s => s.Stid == id);
        if (student != null)
        {
            _context.TableStudents.Remove(student);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public bool AddBalance(int id, decimal amount)
    {
        var student = _context.TableStudents.FirstOrDefault(s => s.Stid == id);
        if (student != null)
        {
            student.Stbalance += amount;
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public List<TableStudent> GetAllStudents()
    {
        return _context.TableStudents.ToList();
    }
}
