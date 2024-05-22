using FluentValidation;
using WildHealth.Application.Commands._Base;
using MediatR;

namespace WildHealth.Application.Commands.Practices
{
    public class InvalidateCachePracticeCommand : IRequest, IValidatabe
    {
        public int PracticeId { get; }

        public InvalidateCachePracticeCommand(int practiceId)
        {
            PracticeId = practiceId;
        }

        #region validation

        public class Validator : AbstractValidator<InvalidateCachePracticeCommand>
        {
            public Validator()
            {
                RuleFor(x => x.PracticeId).GreaterThan(0);
            }
        }

        public bool IsValid() => new Validator().Validate(this).IsValid;

        public void Validate() => new Validator().ValidateAndThrow(this);

        #endregion
    }
}