using Skybrud.Essentials.Json.Extensions;
using Skybrud.Umbraco.GridData;

namespace Jcdcdev.Umbraco.GridData.DocTypeGridEditor
{
    public static class GridControlExtensions
    {
        public static bool IsDtge(this GridControl control)
        {
            return control.JObject.HasValue("value.dtgeContentTypeAlias");
        }
    }
}