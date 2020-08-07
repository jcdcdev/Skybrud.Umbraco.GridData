using Jcdcdev.Umbraco.GridData.DocTypeGridEditor.SearchableTextConverters;
using Newtonsoft.Json.Linq;
using Our.Umbraco.DocTypeGridEditor.Helpers;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Values;
using System.Linq;
using Umbraco.Core.Composing;
using Umbraco.Core.Models.PublishedContent;

namespace Jcdcdev.Umbraco.GridData.DocTypeGridEditor
{
    public class DocTypeGridControlValue : GridControlValueBase
    {
        public string Id { get; }
        public IPublishedElement Content { get; }
        public string ContentTypeAlias { get; }

        public DocTypeGridControlValue(GridControl control, JObject obj) : base(control, obj)
        {
            Id = obj.GetString("id");
            ContentTypeAlias = obj.GetString("dtgeContentTypeAlias");

            //Note, we need an UmbracoContext for this to work so we must use a scope provider when outside of a request scope (Indexing for example)
            Content = DocTypeGridEditorHelper.ConvertValueToContent(Id, ContentTypeAlias, obj.GetObject<string>("value"));
        }

        public override string GetSearchableText()
        {
            //Let's check for any implementations of the converter interface
            var converters = Current.Factory.GetAllInstances<ISearchableTextConverter>();

            //Can any convert the current instance?
            var converter = converters.FirstOrDefault(x => x.CanConvert(Content));

            if (converter == null)
            {
                return base.GetSearchableText();
            }

            //Extract searchable text
            return converter.Convert(Content);
        }

        public static DocTypeGridControlValue Parse(GridControl control, JObject obj)
        {
            return obj == null ? null : new DocTypeGridControlValue(control, obj);
        }
    }
}