namespace Bored.Application.Registration.AppServices.Contracts;

public interface IValidator<T>
{
    bool Validate(T model);
}