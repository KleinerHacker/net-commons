using System;
using System.Windows.Markup;

namespace Net.Commons.Markup.Parameter
{
    #region Parameters Markup Extensions

    public abstract class TextManipulationParamExtension : MarkupExtension, ITextManipulationParam
    {
    }

    [MarkupExtensionReturnType(typeof(ITextManipulationChangeCaseParam))]
    public class TextManipulationChangeCaseParamExtension : TextManipulationParamExtension, ITextManipulationChangeCaseParam
    {
        public ChangeCaseType Type { get; set; } = ChangeCaseType.Upper;
        public ChangeCaseVariant Variant { get; set; } = ChangeCaseVariant.AllCharacters;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new TextManipulationChangeCaseParam(Type, Variant);
        }
    }

    [MarkupExtensionReturnType(typeof(ITextManipulationReplaceParam))]
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
        ChangeCaseType Type { get; set; }
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

    public sealed class TextManipulationChangeCaseParam : ITextManipulationChangeCaseParam
    {
        public ChangeCaseType Type { get; set; }
        public ChangeCaseVariant Variant { get; set; }

        public TextManipulationChangeCaseParam()
        {
        }

        public TextManipulationChangeCaseParam(ChangeCaseType type, ChangeCaseVariant variant)
        {
            Type = type;
            Variant = variant;
        }

        public override string ToString()
        {
            return $"{nameof(Type)}: {Type}, {nameof(Variant)}: {Variant}";
        }
    }

    public sealed class TextManipulationReplaceParam : ITextManipulationReplaceParam
    {
        public string SourceString { get; set; }
        public string TargetString { get; set; }
        public int Repeat { get; set; }
        public bool IgnoreCase { get; set; }

        public TextManipulationReplaceParam()
        {
        }

        public TextManipulationReplaceParam(string sourceString, string targetString, int repeat, bool ignoreCase)
        {
            SourceString = sourceString;
            TargetString = targetString;
            Repeat = repeat;
            IgnoreCase = ignoreCase;
        }

        public override string ToString()
        {
            return $"{nameof(SourceString)}: {SourceString}, {nameof(TargetString)}: {TargetString}, {nameof(Repeat)}: {Repeat}, {nameof(IgnoreCase)}: {IgnoreCase}";
        }
    }

    #endregion

    #region Types

    public enum ChangeCaseVariant
    {
        AllCharacters,
        WordsOnly
    }

    public enum ChangeCaseType
    {
        Upper,
        Lower
    }

    #endregion
}
