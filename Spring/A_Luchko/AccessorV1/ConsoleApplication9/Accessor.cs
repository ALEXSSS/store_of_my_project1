using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Ac
{
    class Accessor
    {
        public Func<T, Object> AccessorDelegate<T>(string adr)
        {
            string[] adr_object = adr.Split('.');
            LabelTarget null_lable = Expression.Label(typeof(object), "null");
            LabelTarget value_lable = Expression.Label(typeof(object), "value");
            ParameterExpression parameter = Expression.Parameter(typeof(T));
            MemberExpression member = Expression.PropertyOrField(parameter, adr_object[1]);
            List<BinaryExpression> property_object_name = new List<BinaryExpression>();
            ConditionalExpression Condition;

            for (int i = 2; i < adr_object.Length; i++)
            {
                property_object_name.Add(Expression.Equal(member, Expression.Constant(null)));
                member = Expression.PropertyOrField(member, adr_object[i]);
            }

            Condition = Expression.IfThenElse(
                property_object_name[property_object_name.Count - 1],
                Expression.Return(null_lable, Expression.Constant(null)),
                Expression.Return(value_lable, member));
            for (int i = 0; i <=property_object_name.Count-2; i++)
            {
                Condition = Expression.IfThenElse(
                    property_object_name[i],
                    Expression.Return(null_lable, Expression.Constant(null)),
                   Condition);
            } //Тут проблема с последними пути: они могут и не сущевствовать, надо на первом нуле смотреть

            BlockExpression code_block = Expression.Block(
                Condition, Expression.Label(null_lable, Expression.Default(typeof(object))),
                Expression.Label(value_lable, Expression.Default(typeof(object))));

            return Expression.Lambda<Func<T, object>>(code_block, parameter).Compile();
        }
    }
}
