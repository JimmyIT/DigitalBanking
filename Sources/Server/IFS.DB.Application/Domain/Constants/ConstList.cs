using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Constants
{
    public struct DirectionConst
    {
        public const string Inbound = "I";
        public const string Outbound = "O";
        public const string TouristCard = "TC";
        public const string OnBoarding = "OB";
    }

    public struct ExternalSystemConst
    {
        public const string AMLtracAPI = "AMLtracAPI";
        public const string BankwareAPI = "BankwareAPI";
        public const string CardAPI = "CardAPI";
        public const string LloydAPI = "LloydAPI";
        public const string ShuftiProAPI = "ShuftiProAPI";
    }

    public struct HostBranchCustomerConst
    {
        public const string Host = "H";
        public const string Branch = "B";
        public const string Customer = "C";
    }

    public struct CustomerTypeConst
    {
        public const string SSE = "SSE";
        public const string MSE = "MSE";
    }

    public struct CountTypeConst
    {
        public const string CustomerRequest = "CUSTOMERREQUEST";
        public const string OutputFileSeq = "OUTPUTFILESEQ";
        public const string Onboarding = "ONBOARDING";
        public const string Error = "ERROR";
    }

    public struct AMLApprovedModeConst
    {
        public const string Auto = "Auto";
        public const string Manual = "Manual";
    }

    public struct AMLDocumentCheckConst
    {
        public const string Complete = "Complete";
        public const string InComplete = "InComplete";
    }
}
