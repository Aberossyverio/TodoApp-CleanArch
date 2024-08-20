using Ardalis.Result;
using Ardalis.SharedKernel;

namespace TodoApp.UseCases.Contributors.Update;

public record UpdateContributorCommand(int ContributorId, string NewName) : ICommand<Result<ContributorDTO>>;
