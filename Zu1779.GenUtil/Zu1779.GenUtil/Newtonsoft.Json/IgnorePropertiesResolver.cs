using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Zu1779.GenUtil.Extension.TypeExtension;

namespace Zu1779.GenUtil.Newtonsoft.Json
{
    public class IgnorePropertiesResolver : DefaultContractResolver
    {
        public IgnorePropertiesResolver()
        {
            ignoreProps = new HashSet<string>();
        }
        public IgnorePropertiesResolver(IEnumerable<string> propNamesToIgnore)
        {
            ignoreProps = new HashSet<string>(propNamesToIgnore);
        }
        private readonly HashSet<string> ignoreProps;

        public IgnorePropertiesResolver IgnoreProperty<T>(Expression<Func<T, object>> exprProperty)
        {
            var propInfo = typeof(T).GetPropertyInfo(exprProperty);
            if (propInfo == null) throw new ApplicationException($"PropertyInfo of {typeof(T).Name}.{exprProperty} was null");
            var propName = propInfo.Name;
            ignoreProps.Add(propName);
            return this;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (ignoreProps.Contains(property.PropertyName)) property.ShouldSerialize = _ => false;
            return property;
        }
    }
}
