using System;

namespace ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Helpers.UserState
{
    /// <summary>
    /// Менеджер работы с состоянием пользователя
    /// </summary>
    public interface IUserStateSettingsManager
    {
        TProperty GetValue<TState, TProperty>(Func<TState, TProperty> func) where TState : UserState, new();

        TProperty GetValue<TState, TProperty>(Func<TState, TProperty> func, Func<TState, bool> searchFunc)
            where TState : UserState, new();

        void SetValue<TState>(Action<TState> action) where TState : UserState, new();
        void SetValue<TState>(Action<TState> action, Func<TState, bool> searchFunc) where TState : UserState, new();
    }
}
