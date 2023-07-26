using SampleZoo.Domain.Entities.Common;
using SampleZoo.Domain.IRepository;

namespace SampleZoo.Domain.Entities.Animal
{
    public class Animal : EntityId<int>, IAggregateRoot
    {
        #region constructor and update method

        public Animal(string title, int age) => AddBaseChanges(title, age);

        public void Update(string title, int age)
        {
            BaseUpdate();
            AddBaseChanges(title, age);
        }

        #endregion

        #region properties

        public string Title { get; protected set; }

        public int Age { get; protected set; }

        #endregion

        #region private methods with guards

        void AddBaseChanges(string title, int age)
        {
            SetTitle(title);
            SetAge(age);
        }

        void SetTitle(string title)
        {
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));
            this.Title = title;
        }

        void SetAge(int age)
        {
            GuardAgainstAgeIsNotGreaterThanZero(age);
            this.Age = Age;
        }

        #endregion

        #region guard against age is not greater than zero

        void GuardAgainstAgeIsNotGreaterThanZero(int age)
        {
            if (age <= 0) throw new ArgumentNullException(nameof(age));
        }

        #endregion
    }
}
