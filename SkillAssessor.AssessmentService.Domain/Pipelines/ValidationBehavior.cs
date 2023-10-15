using FluentValidation;
using MediatR;
using SkillAssessor.Common.Exceptions.Request;

namespace SkillAssessor.AssessmentService.Domain.Pipelines;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest: class, IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            var response = await next();

            return response;
        }

        var results = _validators
            .Select(v => v.Validate(request));
        
        var hasError = results.Any(e => !e.IsValid);

        if (!hasError)
        {
            return await next();
        }

        var errorMessages = results
            .SelectMany(r => r.Errors)
            .Select(r => r.ErrorMessage)
            .Aggregate("", (str, obj) => str + obj + '\n');

        throw new BadRequestException(errorMessages);
    }
}