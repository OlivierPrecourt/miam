using FluentValidation;

namespace Miam.Web.ViewModels.Review
{
    public class ReviewCreateViewModelValidator: AbstractValidator<ReviewCreateViewModel>
    {
        //Todo : Externaliser les messages
        public ReviewCreateViewModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Rating)
                .NotEmpty().WithMessage("Le champ �valuation est requis")
                .InclusiveBetween(1, 5).WithMessage("Le champ �valuation doit �tre compris entre 1 et 5");

            RuleFor(x => x.Body)
                .NotEmpty().WithMessage("Le champ critique est requis")
                .Length(1, 2);//.WithMessage("Le champ critique doit contenir moins de 1024 caract�res");

            RuleFor(x => x.RestaurantId)
                .NotEmpty().WithMessage("Le champ restaurant est requis");
        }
    }
}