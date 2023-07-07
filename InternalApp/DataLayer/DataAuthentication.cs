using AutoMapper;
using BM = BusinessModels.User;
using DM = DataModels.User;

namespace DataLayer
{
    /// <summary>
    /// DataAuthentication class
    /// </summary>
    internal class DataAuthentication : IDataAuthentication
    {
        /// <summary>
        /// Validating login in datalayer
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsValidLogin(BM user)
        {
            for (int i = 0; i < DataSource.dataBase.Count; i++)
            {
                if (DataSource.dataBase[i].username == user.username && DataSource.dataBase[i].password == user.password)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Validating new password
        /// </summary>
        /// <param name="user"></param>
        public void CorrectPasswd(BM user)
        {
            for (int i = 0; i < DataSource.dataBase.Count; i++)
            {
                if (DataSource.dataBase[i].username == user.username)
                {
                    DataSource.dataBase[i].password = user.new_passwd;
                }
            }
        }

        /// <summary>
        /// Validating if user is present already in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsRegistered(BM user)
        {
            for (int i = 0; i < DataSource.dataBase.Count; i++)
            {
                if (DataSource.dataBase[i].username == user.username && DataSource.dataBase[i].phoneNumber == user.phoneNumber && DataSource.dataBase[i].email == user.email)
                {
                    return false;
                }
            }
           
            DataSource dataSource = new DataSource();

            //retrieving object using Reflection technique
            dataSource.AddDetails(GetObjectUsingProperties<BM, DM>(user));

            //retrieving object using Automapper technique
            //dataSource.AddDetails(GetObjectUsingMapper(user));

            //retrieving object using non-generic method
            //dataSource.AddDetails(ConvertObj(user));

            //retrieving object using Generic method and dynamic keyword
            //dataSource.AddDetails(GetObject<DM, BM, DM>(user));
            return true;
        }

        /// <summary>
        /// Converting business model user object to data model user object
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DM ConvertObj(BM user)
        {
            DM obj = new DM();
            obj.username = user.username;
            obj.password = user.password;
            obj.phoneNumber = user.phoneNumber;
            obj.email = user.email;
            return obj;
        }

        /// <summary>
        /// GetObject of DataModel or BuisnessModel using dynamic keyword 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="B"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T GetObject<T, B, U>(dynamic obj) where B : BM, new() where U : DM, new()
        {
            if (obj is B)
            {
                U userObj = new();
                userObj.username = obj.username;
                userObj.password = obj.password;
                userObj.phoneNumber = obj.phoneNumber;
                userObj.email = obj.email;
                return (dynamic)userObj;
            }
            else
            {
                B userObj = new();
                userObj.username = obj.Username;
                userObj.password = obj.Password;
                userObj.phoneNumber = obj.PhoneNumber;
                userObj.email = obj.Email;
                return (dynamic)userObj;
            }
        }

        /// <summary>
        /// Conversion of objects using reflection technique
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public U GetObjectUsingProperties<T, U>(T t) where T : BM where U : DM, new()
        {
            U userObj = new U();
            var BMObj = t.GetType().GetProperties();
            var DMObj = userObj.GetType().GetProperties();
            foreach (var BMProperty in BMObj)
            {
                var DMProperty = DMObj.FirstOrDefault(userObj => userObj.Name == BMProperty.Name && userObj.PropertyType == BMProperty.PropertyType);
                if (DMProperty != null)
                {
                    DMProperty.SetValue(userObj, BMProperty.GetValue(t));
                }
            }
            return userObj;
        }

        /// <summary>
        /// Conversion of objects using AutoMapper technique
        /// </summary>
        /// <param name="bM"></param>
        /// <returns></returns>
        public DM GetObjectUsingMapper(BM bM)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BM, DM>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<BM, DM>(bM);
        }
    }
}
