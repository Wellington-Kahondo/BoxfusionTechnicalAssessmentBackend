using Boxfusion.TechnicalAssessment.Debugging;

namespace Boxfusion.TechnicalAssessment
{
    public class TechnicalAssessmentConsts
    {
        public const string LocalizationSourceName = "TechnicalAssessment";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "25d0ec6e1bab4ac8aa1cb6640a3d8889";
    }
}
