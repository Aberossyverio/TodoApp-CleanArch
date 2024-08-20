using Ardalis.Result;
using Ardalis.SharedKernel;

namespace TodoApp.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
