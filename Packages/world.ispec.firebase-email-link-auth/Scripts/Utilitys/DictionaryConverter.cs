using System.Collections.Generic;
using System.Linq;

namespace ispec.FirebaseEmailLinkAuth
{
    internal static class DictionaryConverter
    {
        public static Dictionary<string, string> ToDictionary<T>(this T model)
        {
            return model.GetType()
                .GetProperties()
                .Where(t => t.GetValue(model, null) != null)
                .Select(i => (i.Name, i.GetValue(model, null)?.ToString()))
                .ToDictionary(x => x.Item1, x => x.Item2);
        }
    }
}
