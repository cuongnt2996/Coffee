# TODO: Update UpdateEmployeeAsync to use AutoMapper

- [x] Update MappingProfile.cs to add .ReverseMap() for bidirectional mapping between Employee and UpdateEmployeeRequest
- [x] Modify EmployeeService.cs UpdateEmployeeAsync: Comment out manual field assignments
- [x] Modify EmployeeService.cs UpdateEmployeeAsync: Replace incorrect mapper call with _mapper.Map(request, employee)
- [x] Verify TerminationDate logic remains intact
