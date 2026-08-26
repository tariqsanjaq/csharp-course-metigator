// Models.cs

namespace Task20_YieldRecordsTopLevelNullHandling;

/// <summary>
/// One employee record, produced by the Transform stage from a single
/// non-blank, non-header CSV line. A line becomes an <see cref="Employee"/>
/// only if all of <paramref name="EmployeeId"/>, <paramref name="Salary"/>,
/// and <paramref name="HireDate"/> are present and parse successfully —
/// any one of those failing means the row is dropped, not defaulted.
/// <paramref name="Bonus"/> is the one genuinely optional field — absent
/// or blank input means null, not zero.
/// </summary>
/// <param name="EmployeeId">Required. Empty or missing id is a fatal parse failure, same tier as Salary and HireDate.</param>
/// <param name="Department">
/// Required on the record — every <see cref="Employee"/> instance has a
/// non-null, non-empty Department. Not required in the input: blank CSV
/// input is coalesced to "Unassigned" during parsing rather than causing
/// a fatal row.
/// </param>
/// <param name="Salary">Required. Must parse as a decimal; failure to parse is fatal for the row.</param>
/// <param name="HireDate">Required. Must parse as a date; failure to parse is fatal for the row.</param>
/// <param name="Bonus">Optional. Null means "no bonus on file", not zero.</param>
public record Employee(
    string EmployeeId,
    string Department,
    decimal Salary,
    DateTime HireDate,
    decimal? Bonus
);

/// <summary>
/// A projected view of an <see cref="Employee"/>, built downstream of
/// Transform via <see cref="From"/> (not parsed directly from CSV).
/// Carries the same source values as <see cref="Employee"/> — Salary,
/// Bonus, HireDate — plus the reference date the summary was computed
/// against, so that <c>TotalCompensation</c> and <c>YearsOfService</c>
/// are derived properties rather than baked-in numbers. A <c>with</c>
/// expression that changes <see cref="Salary"/> after a raise, or
/// <see cref="AsOf"/> on an anniversary, genuinely recomputes both —
/// nothing needs to be rebuilt from the original <see cref="Employee"/>.
/// </summary>
/// <param name="EmployeeId">Carried over unchanged from the source <see cref="Employee"/>.</param>
/// <param name="Department">Carried over unchanged from the source <see cref="Employee"/>.</param>
/// <param name="Salary">Carried over unchanged from the source <see cref="Employee"/>; drives <see cref="TotalCompensation"/>.</param>
/// <param name="Bonus">Carried over unchanged from the source <see cref="Employee"/>; drives <see cref="TotalCompensation"/>.</param>
/// <param name="HireDate">Carried over unchanged from the source <see cref="Employee"/>; drives <see cref="YearsOfService"/>.</param>
/// <param name="AsOf">The reference date the summary is computed against; drives <see cref="YearsOfService"/>.</param>
public record EmployeeSummary(
    string EmployeeId,
    string Department,
    decimal Salary,
    decimal? Bonus,
    DateTime HireDate,
    DateTime AsOf
)
{
    /// <summary>Salary plus Bonus, treating a missing Bonus as zero.</summary>
    public decimal TotalCompensation => Salary + (Bonus ?? 0m);

    /// <summary>Whole years between HireDate and AsOf.</summary>
    public int YearsOfService => (int)((AsOf - HireDate).TotalDays / 365.25);

    /// <summary>
    /// Builds a summary from an employee via deconstruction, rather than
    /// copying fields by hand. The caller supplies <paramref name="asOf"/>
    /// explicitly — the record never reaches for <c>DateTime.Today</c>
    /// itself, so the same <see cref="Employee"/> produces a reproducible,
    /// testable summary regardless of when the code happens to run.
    /// </summary>
    public static EmployeeSummary From(Employee employee, DateTime asOf)
    {
        var (employeeId, department, salary, hireDate, bonus) = employee;
        return new EmployeeSummary(employeeId, department, salary, bonus, hireDate, asOf);
    }
}