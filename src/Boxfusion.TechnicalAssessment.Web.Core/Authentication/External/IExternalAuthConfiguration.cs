using System.Collections.Generic;

namespace Boxfusion.TechnicalAssessment.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
