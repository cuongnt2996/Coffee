using Coffee.Models.DTOs;
using Coffee.Services;
using Microsoft.AspNetCore.Mvc;

namespace Coffee.Controllers;

public class EmployeesController : BaseController
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(
        ILogger<EmployeesController> logger,
        ISiteProvider siteProvider,
        IEmployeeService employeeService)
        : base(logger, siteProvider)
    {
        _employeeService = employeeService;
    }

    // GET: Employees
    public async Task<IActionResult> Index()
    {
        try
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return View(employees);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving employees");
            return View("Error");
        }
    }

    // GET: Employees/Details/5
    public async Task<IActionResult> Details(int id)
    {
        try
        {
            var employee = await _employeeService.GetEmployeeAsync(id);
            if (employee == null)
                return NotFound();

            return View(employee);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving employee {Id}", id);
            return View("Error");
        }
    }

    // GET: Employees/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Employees/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateEmployeeRequest request)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _employeeService.CreateEmployeeAsync(request);
                TempData["SuccessMessage"] = "Thêm nhân viên thành công";
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(request);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating employee");
            ModelState.AddModelError("", "Có lỗi xảy ra khi thêm nhân viên");
            return View(request);
        }
    }

    // GET: Employees/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        try
        {
            var employee = await _employeeService.GetEmployeeAsync(id);
            if (employee == null)
                return NotFound();

            var updateModel = new UpdateEmployeeRequest
            {
                PhoneNumber = employee.PhoneNumber,
                Department = employee.Department,
                Position = employee.Position,
                Status = employee.Status,
                Address = "",
                Salary = 0
            };

            ViewData["EmployeeId"] = employee.Id;
            ViewData["EmployeeCode"] = employee.EmployeeCode;

            return View(updateModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving employee {Id} for edit", id);
            return View("Error");
        }
    }

    // POST: Employees/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, UpdateEmployeeRequest request)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _employeeService.UpdateEmployeeAsync(id, request);
                TempData["SuccessMessage"] = "Cập nhật thông tin nhân viên thành công";
                return RedirectToAction(nameof(Index));
            }

            var employee = await _employeeService.GetEmployeeAsync(id);
            ViewData["EmployeeId"] = id;
            ViewData["EmployeeCode"] = employee?.EmployeeCode;

            return View(request);
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(request);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating employee {Id}", id);
            ModelState.AddModelError("", "Có lỗi xảy ra khi cập nhật thông tin nhân viên");
            return View(request);
        }
    }

    // GET: Employees/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var employee = await _employeeService.GetEmployeeAsync(id);
            if (employee == null)
                return NotFound();

            return View(employee);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving employee {Id} for delete", id);
            return View("Error");
        }
    }

    // POST: Employees/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            await _employeeService.DeleteEmployeeAsync(id);
            TempData["SuccessMessage"] = "Xóa nhân viên thành công";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting employee {Id}", id);
            TempData["ErrorMessage"] = "Có lỗi xảy ra khi xóa nhân viên";
            return RedirectToAction(nameof(Index));
        }
    }
}