using Newtonsoft.Json.Linq;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Interfaces;
using Skybrud.Umbraco.GridData.Rendering;

namespace Jcdcdev.Umbraco.GridData.DocTypeGridEditor
{
    public class DocTypeGridConverter : IGridConverter
    {
        public bool ConvertControlValue(GridControl control, JToken token, out IGridControlValue value)
        {
            value = null;

            if (control.IsDtge())
            {
                value = DocTypeGridControlValue.Parse(control, token as JObject);
            }

            return value != null;
        }

        public bool ConvertEditorConfig(GridEditor editor, JToken token, out IGridEditorConfig config)
        {
            config = null;

            if (editor.Control.IsDtge())
            {
                config = DocTypeGridEditorConfig.Parse(editor, token as JObject);
            }

            return config != null;
        }

        public bool GetControlWrapper(GridControl control, out GridControlWrapper wrapper)
        {
            wrapper = null;

            if (control.IsDtge())
            {
                wrapper = control.GetControlWrapper<DocTypeGridControlValue, DocTypeGridEditorConfig>();
            }

            return wrapper != null;
        }
    }
}