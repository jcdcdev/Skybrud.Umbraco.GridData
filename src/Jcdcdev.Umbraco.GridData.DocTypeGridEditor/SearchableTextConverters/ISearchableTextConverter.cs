using Umbraco.Core.Models.PublishedContent;

namespace Jcdcdev.Umbraco.GridData.DocTypeGridEditor.SearchableTextConverters
{
    /// <summary>
    /// Implementations of this are used to extract searchable text for a DocTypeGridControlValue
    /// </summary>
    public interface ISearchableTextConverter
    {
        /// <summary>
        /// Determines whether the converter can convert the current instance
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        bool CanConvert(IPublishedElement element);

        /// <summary>
        /// Extracts searchable text from the current instance
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        string Convert(IPublishedElement element);
    }
}