using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Interfaces;
using Skybrud.Umbraco.GridData.Json;

namespace Jcdcdev.Umbraco.GridData.DocTypeGridEditor
{
    public class DocTypeGridEditorConfig : GridJsonObject, IGridEditorConfig
    {
        public string[] AllowedDocTypes { get; }
        public string NameTemplate { get; }
        public bool EnablePreview { get; }
        public string ViewPath { get; }
        public string PreviewViewPath { get; }
        public string PreviewCssFilePath { get; }
        public string PreviewJsFilePath { get; }

        public DocTypeGridEditorConfig(GridEditor editor, JObject obj) : base(obj)
        {
            Editor = editor;
            AllowedDocTypes = obj.GetString("allowedDoctypes")?.Split(',');
            NameTemplate = obj.GetString("nameTemplate");
            EnablePreview = obj.GetBoolean("enablePreview");
            ViewPath = obj.GetString("viewPath");
            PreviewViewPath = obj.GetString("previewViewPath");
            PreviewCssFilePath = obj.GetString("previewCssFilePath");
            PreviewJsFilePath = obj.GetString("previewJsFilePath");
        }

        public GridEditor Editor { get; }

        public static DocTypeGridEditorConfig Parse(GridEditor editor, JObject obj)
        {
            return obj == null ? null : new DocTypeGridEditorConfig(editor, obj);
        }
    }
}