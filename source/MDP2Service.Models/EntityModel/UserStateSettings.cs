using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Xml.Serialization;
using ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Helpers.UserState;
using ASE.MD.MDP2.Product.MDP2Service.Utils;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class UserStateSettings
    //{
    //    public short User_ObjectId { get; set; }
    //    public string StatesJson { get; set; }

    //    public virtual User User_Object { get; set; }
    //}

    #endregion scaffold model

    public class UserStateSettings
    {
        public UserStateSettings() { }

        public UserStateSettings(UserStateSettings settings)
            : this()
        {
            User_ObjectId = settings.User_ObjectId;
            StatesJson = settings.StatesJson;
            InitializeStates();
        }

        [Key, ForeignKey("User")]
        public short User_ObjectId { get; set; }

        public virtual User User { get; set; }

        [XmlArray("UserStates")]
        private List<UserState> mStates;

        public T GetState<T>() where T : UserState, new()
        {
            InitializeStates();
            var res = mStates.OfType<T>().SingleOrDefault();
            if (res == null)
            {
                res = new T();
                mStates.Add(res);
            }
            
            return res;
        }

        public T GetState<T>(Func<T, bool> searchPredicate) where T : UserState, new()
        {
            InitializeStates();
            var res = mStates.OfType<T>().FirstOrDefault(searchPredicate);
            if (res == null)
            {
                res = new T();
                mStates.Add(res);
            }
            
            return res;
        }

        public virtual string StatesJson { get; set; }

        private void InitializeStates()
        {
            if (mStates == null)
                mStates = SerializationManager.JsonDeserialize(StatesJson, new List<UserState>());
        }

        public void Update()
        {
            if (mStates.Empty())
            {
                StatesJson = null;
                return;
            }
            StatesJson = SerializationManager.JsonSerialize(mStates);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is UserStateSettings settings)) return false;

            if (settings.User_ObjectId != User_ObjectId) return false;

            return settings.mStates == null && mStates == null || mStates != null && settings.mStates != null && mStates.SequenceEqual(settings.mStates);
        }
    }
}
