using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Boxfusion.TechnicalAssessment.Localization
{
    public static class TechnicalAssessmentLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(TechnicalAssessmentConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(TechnicalAssessmentLocalizationConfigurer).GetAssembly(),
                        "Boxfusion.TechnicalAssessment.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
