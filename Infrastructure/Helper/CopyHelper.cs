using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Infrastructure.Extensions;

namespace Infrastructure.Helper
{
    public class CopyHelper
    {
        #region 浅拷贝
        /// <summary>
        /// 表达式树拷贝对象方式
        /// 用于大批量的集合的浅拷贝
        /// </summary>
        /// <typeparam name="Tin"></typeparam>
        /// <typeparam name="Tout"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public Tout ExpressionShallowCopy<Tin, Tout>(Tin model)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(Tin), "p");

            List<MemberBinding> binds = new List<MemberBinding>();
            foreach (var item in typeof(Tout).GetProperties().Where(p => p.CanWrite && p.CanRead))
            {
                var Property = Expression.Property(parameterExpression, typeof(Tin).GetProperty(item.Name));
                binds.Add(Expression.Bind(item, Property));
            }

            var body = Expression.MemberInit(Expression.New(typeof(Tout)), binds.ToArray());

            Expression<Func<Tin, Tout>> func = Expression.Lambda<Func<Tin, Tout>>(body, new ParameterExpression[] { parameterExpression });
            return func.Compile()(model);
        }

        /// <summary>
        /// 反射拷贝
        /// </summary>
        /// <typeparam name="tIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public TOut ReflectionShallowCopy<tIn, TOut>(tIn model)
        {
            TOut tOut = Activator.CreateInstance<TOut>();
            var tInType = model.GetType();
            foreach (var itemOut in tOut.GetType().GetProperties())
            {
                var itemIn = tInType.GetProperty(itemOut.Name); ;
                if (itemIn != null)
                {
                    itemOut.SetValue(tOut, itemIn.GetValue(model);
                }
            }
            return tOut;
        }

        #endregion

        #region 深拷贝
        /// <summary>
        /// 二进制流拷贝
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T BinaryDeepCopy<T>(T obj)
        {
            object retval;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                //序列化成流
                bf.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                //反序列化成对象
                retval = bf.Deserialize(ms);
                ms.Close();
            }
            return (T)retval;
        }

        /// <summary>
        /// Json拷贝
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T JsonDeepCopy<T>(T obj) where T : class
        {
            return obj.ToJson().ToObject<T>();
        }
        #endregion
    }
}
