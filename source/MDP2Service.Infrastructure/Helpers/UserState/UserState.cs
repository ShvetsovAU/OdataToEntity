namespace ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Helpers.UserState
{
    /// <summary>
    /// Состояние пользователя
    /// </summary>
    public abstract class UserState
    {
        public override bool Equals(object obj)
        {
            if (!(obj is UserState state)) return false;

            return RequiredEquals(state);
        }

        protected abstract bool RequiredEquals(UserState userState);
    }
}
