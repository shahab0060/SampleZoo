using SampleZoo.Domain.Entities.Common;
using SampleZoo.Domain.IRepository;

namespace SampleZoo.Domain.Entities.User
{
    public class User : EntityId<int>, IAggregateRoot
    {
        #region constructor and update method

        public User(string userName, string phoneNumber, string password)
        {
            SetUserName(userName);
            AddBaseChanges(phoneNumber, password);
        }

        public void Update(string phoneNumber, string password)
        {
            BaseUpdate();
            AddBaseChanges(phoneNumber, password);
        }

        #endregion

        #region properties

        public string UserName { get; protected set; }

        public string PhoneNumber { get; protected set; }

        public string Password { get; protected set; }

        #endregion

        #region private methods with guards

        void AddBaseChanges(string phoneNumber, string password)
        {
            SetPhoneNumber(phoneNumber);
            SetPassword(password);
        }

        void SetUserName(string username)
        {
            ArgumentException.ThrowIfNullOrEmpty(username, nameof(username));
            this.UserName = username;
        }

        void SetPassword(string password)
        {
            ArgumentException.ThrowIfNullOrEmpty(password, nameof(password));
            this.Password = password;
        }

        void SetPhoneNumber(string phoneNumber)
        {
            ArgumentException.ThrowIfNullOrEmpty(phoneNumber, nameof(phoneNumber));
            this.PhoneNumber = phoneNumber;
        }

        #endregion
    }
}
