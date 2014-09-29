using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mindscape.LightSpeed.MetaData;
using WebGrease.Css.Extensions;

// ReSharper disable once CheckNamespace
namespace Mindscape.LightSpeed
{
    public static class LightspeedExtensionMethods
    {
        private static readonly KeyValueKeyOnlyComparer PatchComparer = new KeyValueKeyOnlyComparer();

        public static void ResetId(this Entity entity)
        {
            entity.EntityInfo().Fields.First(f => f.PropertyName == "Id").SetValue(entity, 0);
        }

        public static void Patch<T>(this T entity, Dictionary<string, string> patch)
        {
            var keysToExclude = new List<String> { "id","CreatedOn","UpdatedOn", "DeletedOn" };
            var keyValuesToExclude = keysToExclude.Select(s => new KeyValuePair<string, string>(s, String.Empty));

            var filteredPatches = patch.Except(keyValuesToExclude, PatchComparer);

            PropertyInfo[] userPropertyInfo = entity.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);

            var propertyValueMashUp = filteredPatches.Join(
                userPropertyInfo,
                p => p.Key.ToLowerInvariant(),
                prop => prop.Name.ToLowerInvariant(),
                (p, prop) => new KeyValuePair<PropertyInfo, String>(prop, p.Value)
                );
            propertyValueMashUp.ForEach(q => q.Key.SetValue(entity, Convert.ChangeType(q.Value, q.Key.PropertyType)));
        }
    }

    class KeyValueKeyOnlyComparer : IEqualityComparer<KeyValuePair<String, String>>
    {

        public bool Equals(KeyValuePair<String, String> kv1, KeyValuePair<String, String> kv2)
        {
            return kv1.Key.Equals(kv2.Key, StringComparison.OrdinalIgnoreCase);
        }


        public int GetHashCode(KeyValuePair<String, String> kv)
        {
            return kv.Key.ToLowerInvariant().GetHashCode();
        }

    }
}