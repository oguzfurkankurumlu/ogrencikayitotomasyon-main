using Microsoft.AspNetCore.Mvc;
using summerschool.DTO;

public class TeacherController : Controller
{
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    // Öğretmenleri listeleme
    public IActionResult Index()
    {
        var teachers = _teacherService.GetAllTeachers();
        return View(teachers);  // Öğretmenleri listele
    }

    // Öğretmen ekleme
    [HttpGet]
    public IActionResult AddTeacher()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddTeacher(TeacherDTO teacher)
    {
        if (_teacherService.AddTeacher(teacher))
        {
            return RedirectToAction("Index");  // Başarıyla eklenirse anasayfaya yönlendir
        }
        return View(teacher);  // Başarısız olursa ekranda tekrar göster
    }

    // Öğretmen silme işlemi (POST)
    [HttpPost]
    public IActionResult Delete(int id)
    {
        if (_teacherService.DeleteTeacher(id))
        {
            return RedirectToAction("Index");
        }
        return View();  // Silme işlemi başarısızsa tekrar göster
    }
}
