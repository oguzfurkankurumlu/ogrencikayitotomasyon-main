using summerschool.DMO;
using System.Collections.Generic;
using System.Linq;

public interface ITeacherRepository
{
    bool AddTeacher(TableTeacher teacher);
    bool DeleteTeacher(int id);
    bool UpdateTeacher(TableTeacher teacher);
    List<TableTeacher> GetAllTeachers();
    TableTeacher GetTeacherById(int id);  // Tek öğretmen bilgisi almak için
}

public class TeacherRepository : ITeacherRepository
{
    private readonly SummerSchoolContext _context;  // Veritabanı bağlamını kullanıyoruz

    // Constructor ile veritabanı bağlamını alıyoruz
    public TeacherRepository(SummerSchoolContext context)
    {
        _context = context;
    }

    // Öğretmen ekleme işlemi
    public bool AddTeacher(TableTeacher teacher)
    {
        try
        {
            _context.TableTeachers.Add(teacher);  // Yeni öğretmeni ekliyoruz
            _context.SaveChanges();  // Değişiklikleri kaydediyoruz
            return true;  // Başarıyla eklenirse true döneriz
        }
        catch
        {
            return false;  // Hata olursa false döneriz
        }
    }

    // Öğretmen silme işlemi
    public bool DeleteTeacher(int id)
    {
        try
        {
            var teacher = _context.TableTeachers.FirstOrDefault(t => t.Tchrid == id);  // Öğretmeni ID'ye göre arıyoruz
            if (teacher != null)
            {
                _context.TableTeachers.Remove(teacher);  // Öğretmeni siliyoruz
                _context.SaveChanges();  // Değişiklikleri kaydediyoruz
                return true;
            }
            return false;  // Öğretmen bulunamazsa false döneriz
        }
        catch
        {
            return false;  // Hata olursa false döneriz
        }
    }

    // Öğretmen güncelleme işlemi
    public bool UpdateTeacher(TableTeacher teacher)
    {
        try
        {
            var existingTeacher = _context.TableTeachers.FirstOrDefault(t => t.Tchrid == teacher.Tchrid);  // ID'ye göre öğretmeni buluyoruz
            if (existingTeacher != null)
            {
                existingTeacher.Tchnamelastname = teacher.Tchnamelastname;  // Öğretmen bilgilerini güncelliyoruz
                _context.SaveChanges();  // Değişiklikleri kaydediyoruz
                return true;
            }
            return false;  // Öğretmen bulunamazsa false döneriz
        }
        catch
        {
            return false;  // Hata olursa false döneriz
        }
    }

    // Tüm öğretmenleri listeleme işlemi
    public List<TableTeacher> GetAllTeachers()
    {
        return _context.TableTeachers.ToList();  // Tüm öğretmenleri veritabanından alıp liste halinde döndürüyoruz
    }

    // Tek bir öğretmeni ID ile almak
    public TableTeacher GetTeacherById(int id)
    {
        return _context.TableTeachers.FirstOrDefault(t => t.Tchrid == id);  // Öğretmeni ID ile buluyoruz
    }
}
