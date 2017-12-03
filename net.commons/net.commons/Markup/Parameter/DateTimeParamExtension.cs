using System;
using System.Windows.Markup;
using Net.Commons.Converter;

namespace Net.Commons.Markup.Parameter
{
    /// \ingroup wpf_single_converter_param
    /// \ingroup wpf_markup
    /// <summary>
    /// Markup extension for <see cref="DateTimeConverter"/> parameter to use in XAML
    /// </summary>
    [MarkupExtensionReturnType(typeof(IDateTimeParam))]
    public class DateTimeParamExtension : MarkupExtension, IDateTimeParam
    {
        /// <inheritdoc />
        public DatePresentation DatePresentation { get; set; } = DatePresentation.Short;
        /// <inheritdoc />
        public TimePresentation TimePresentation { get; set; } = TimePresentation.Short;
        /// <inheritdoc />
        public string Separator { get; set; } = " ";

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Build();
        }

        internal IDateTimeParam Build()
        {
            return new DateTimeParam(DatePresentation, TimePresentation, Separator);
        }
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Interface for the converter parameter of <see cref="DateTimeConverter"/>, see <see cref="DateTimeParam"/>
    /// </summary>
    public interface IDateTimeParam
    {
        /// <summary>
        /// Presentation of date value, defualt is Short
        /// </summary>
        DatePresentation DatePresentation { get; set; }
        /// <summary>
        /// Presentation of time value, defualt is Short
        /// </summary>
        TimePresentation TimePresentation { get; set; }
        /// <summary>
        /// Defines the separator string between date and time
        /// </summary>
        string Separator { get; set; }
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Converter parameter of <see cref="DateTimeConverter"/>
    /// </summary>
    public sealed class DateTimeParam : IDateTimeParam
    {
        /// <inheritdoc />
        public DatePresentation DatePresentation { get; set; }
        /// <inheritdoc />
        public TimePresentation TimePresentation { get; set; }
        /// <inheritdoc />
        public string Separator { get; set; }

        public DateTimeParam()
        {
        }

        public DateTimeParam(DatePresentation datePresentation, TimePresentation timePresentation, string separator)
        {
            DatePresentation = datePresentation;
            TimePresentation = timePresentation;
            Separator = separator;
        }

        public override string ToString()
        {
            return $"{nameof(DatePresentation)}: {DatePresentation}, {nameof(TimePresentation)}: {TimePresentation}, {nameof(Separator)}: {Separator}";
        }
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Presentation of date value
    /// </summary>
    public enum DatePresentation
    {
        /// <summary>
        /// Not included in result string
        /// </summary>
        None,
        /// <summary>
        /// Short variant
        /// </summary>
        Short,
        /// <summary>
        /// Long variant
        /// </summary>
        Long
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Presentation of time value
    /// </summary>
    public enum TimePresentation
    {
        /// <summary>
        /// Not included in result string
        /// </summary>
        None,
        /// <summary>
        /// Short variant
        /// </summary>
        Short,
        /// <summary>
        /// Long variant
        /// </summary>
        Long
    }
}
