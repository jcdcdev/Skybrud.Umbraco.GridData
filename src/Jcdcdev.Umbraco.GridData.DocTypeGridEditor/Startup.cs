using Jcdcdev.Umbraco.GridData.DocTypeGridEditor.SearchableTextConverters;
using Skybrud.Umbraco.GridData;
using Umbraco.Core.Composing;

namespace Jcdcdev.Umbraco.GridData.DocTypeGridEditor
{
    public class Startup : IUserComposer
    {
        public void Compose(Composition composition)
        {
            var converters = composition.TypeLoader.GetTypes<ISearchableTextConverter>();

            foreach (var converter in converters)
            {
                composition.RegisterUnique(converter);
            }

            GridContext.Current.Converters.Add(new DocTypeGridConverter());
        }
    }
}