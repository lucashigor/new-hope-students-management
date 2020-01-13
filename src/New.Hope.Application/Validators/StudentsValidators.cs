using New.Hope.Domain;
using FluentValidation;

namespace New.Hope.Application
{
    public class StudentsValidator : AbstractValidator<Student>
    {
        public StudentsValidator()
        {
            RuleFor(x => x.FullName).NotEmpty();
            RuleFor(x => x.FullName).MinimumLength(20);
        }
    }
}