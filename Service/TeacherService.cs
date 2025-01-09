using summerschool.DMO;
using summerschool.DTO;
using System.Collections.Generic;
using System.Linq;

public interface ITeacherService
{
    bool AddTeacher(TeacherDTO newTeacher);
    bool DeleteTeacher(int id);
    bool UpdateTeacher(TeacherDTO updatedTeacher);
    List<TeacherDTO> GetAllTeachers();
    TeacherDTO GetTeacherById(int id);
}

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;

    // Constructor ile repository'yi alıyoruz
    public TeacherService(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    // Yeni öğretmen ekleme işlemi
    public bool AddTeacher(TeacherDTO newTeacher)
    {
        // DTO'yu DMO'ya dönüştürüyoruz
        var teacher = new TableTeacher
        {
            Tchnamelastname = newTeacher.Tchnamelastname,
            Tchrbranch = newTeacher.Tchrbranch // Bu şekilde Tchrbranch kullanmalısınız
        };
        return _teacherRepository.AddTeacher(teacher);
    }

    // Öğretmen silme işlemi
    public bool DeleteTeacher(int id)
    {
        return _teacherRepository.DeleteTeacher(id);
    }

    // Öğretmen güncelleme işlemi
    public bool UpdateTeacher(TeacherDTO updatedTeacher)
    {
        var teacher = new TableTeacher
        {
            Tchrid = updatedTeacher.Tchrid,
            Tchnamelastname = updatedTeacher.Tchnamelastname,
            Tchrbranch = updatedTeacher.Tchrbranch // TchrbranchName yerine Tchrbranch kullanmalısınız
        };
        return _teacherRepository.UpdateTeacher(teacher);
    }

    // Tüm öğretmenleri listeleme işlemi
    public List<TeacherDTO> GetAllTeachers()
    {
        var teachers = _teacherRepository.GetAllTeachers();
        return teachers.Select(t => new TeacherDTO
        {
            Tchrid = t.Tchrid,
            Tchnamelastname = t.Tchnamelastname,
            Tchrbranch = t.Tchrbranch // TchrbranchName yerine Tchrbranch
        }).ToList();
    }

    // ID'ye göre öğretmen almak
    public TeacherDTO GetTeacherById(int id)
    {
        var teacher = _teacherRepository.GetTeacherById(id);
        if (teacher != null)
        {
            return new TeacherDTO
            {
                Tchrid = teacher.Tchrid,
                Tchnamelastname = teacher.Tchnamelastname,
                Tchrbranch = teacher.Tchrbranch // TchrbranchName yerine Tchrbranch
            };
        }
        return null;  // Eğer öğretmen bulunamazsa null döneriz
    }
}
