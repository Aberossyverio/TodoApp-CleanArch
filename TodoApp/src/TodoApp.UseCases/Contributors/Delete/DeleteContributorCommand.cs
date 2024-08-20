using Ardalis.Result;
using Ardalis.SharedKernel;

namespace TodoApp.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
