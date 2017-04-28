using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace net.commons.Markup
{
    #region Parameters Markup Extensions

    public abstract class TextManipulationParamExtension : MarkupExtension, ITextManipulationParam
    {
    }

    [MarkupExtensionReturnType(typeof(TextManipulationChangeCaseParam))]
    public class TextManipulationUpperCaseParamExtension : TextManipulationParamExtension, ITextManipulationChangeCaseParam
    {
        public ChangeCaseVariant Variant { get; set; } = ChangeCaseVariant.AllCharacters;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new TextManipulationChangeCaseParam(ChangeCaseType.Upper, Variant);
        }
    }

    [MarkupExtensionReturnType(typeof(TextManipulationChangeCaseParam))]
    public class TextManipulationLowerCaseParamExtension : TextManipulationParamExtension, ITextManipulationChangeCaseParam
    {
        public ChangeCaseVariant Variant { get; set; } = ChangeCaseVariant.AllCharacters;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new TextManipulationChangeCaseParam(ChangeCaseType.Lower, Variant);
        }
    }

    [MarkupExtensionReturnType(typeof(TextManipulationReplaceParam))]
    public class TextManipulationReplaceParamExtension : TextManipulationParamExtension, ITextManipulationReplaceParam
    {
        public string SourceString { get; set; }
        public string TargetString { get; set; }
        public int Repeat { get; set; } = -1;
        public bool IgnoreCase { get; set; } = false;

        public TextManipulationReplaceParamExtension(string sourceString, string targetString)
        {
            SourceString = sourceString;
            TargetString = targetString;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new TextManipulationReplaceParam(SourceString, TargetString, Repeat, IgnoreCase);
        }
    }

    #endregion

    #region Parameters Interfaces

    public interface ITextManipulationParam
    {
    }

    public interface ITextManipulationChangeCaseParam : ITextManipulationParam
    {
        ChangeCaseVariant Variant { get; set; }
    }

    public interface ITextManipulationReplaceParam : ITextManipulationParam
    {
        string SourceString { get; set; }
        string TargetString { get; set; }
        int Repeat { get; set; }
        bool IgnoreCase { get; set; }
    }

    #endregion

    #region Parameters

    internal class TextManipulationChangeCaseParam : ITextManipulationChangeCaseParam
    {
        public ChangeCaseType Type { get; set; }
        public ChangeCaseVariant Variant { get; set; }

        public TextManipulationChangeCaseParam(ChangeCaseType type, ChangeCaseVariant variant)
        {
            Type = type;
            Variant = variant;
        }
    }

    internal class TextManipulationReplaceParam : ITextManipulationReplaceParam
    {
        public string SourceString { get; set; }
        public string TargetString { get; set; }
        public int Repeat { get; set; }
        public bool IgnoreCase { get; set; }

        public TextManipulationReplaceParam(string sourceString, string targetString, int repeat, bool ignoreCase)
        {
            SourceString = sourceString;
            TargetString = targetString;
            Repeat = repeat;
            IgnoreCase = ignoreCase;
        }
    }

    #endregion

    #region Types

    public enum ChangeCaseVariant
    {
        AllCharacters,
        WordsOnly
    }

    internal enum ChangeCaseType
    {
        Upper,
        Lower
    }

    #endregion
}
