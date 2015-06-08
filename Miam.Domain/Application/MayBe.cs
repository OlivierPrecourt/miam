using System.Collections;
using System.Collections.Generic;

namespace Miam.Domain.Application
{
    // Classe g�n�rique qui permet d'�viter de retourner Null. 
    //
    // Exemple d'utilisation:
    // La m�thode Validate ci-dessous doit d�terminer si un utilisateur est valide ou non. Elle retourne un MayBe<ApplicationUser>.
    // Si l'utilisateur est valide, le premier �l�ment du IEnumerable est cet utilisateur.
    // Si l'utilisateur est non-valide, le retour est une Ienumerable vide
    //
    //     var user = _validationUserService.Validate(accountLoginViewModel.Email, accountLoginViewModel.Password);
    //


    public class MayBe<T> : IEnumerable<T>
    {
        
        // Selon le constrcuteur appel�e, _value peut contenir aucun �l�ment ou 1 seul �l�ment
        private readonly  IEnumerable<T> _values;

        public MayBe()
        {
            _values = new T[0];
        }

        public MayBe(T value)
        {
            _values = new [] { value };
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}