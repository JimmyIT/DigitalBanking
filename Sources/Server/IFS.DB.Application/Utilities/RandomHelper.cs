using IFS.DB.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Utilities
{
    public interface IRandomHelper
    {
        string CreateSaltValue();
        string CreateMSEAuthorityCode();
        string GeneratePIN();
    }

    public class RandomHelper : IRandomHelper
    {
        private readonly IStringProvider _StringProvider;

        public RandomHelper(IStringProvider stringProvider)
        {
            _StringProvider = stringProvider;
        }

        private string GenerateStringRandomly(int numOfCharacters)
        {
            StringBuilder genString = new StringBuilder();
            Random random = new Random(_StringProvider.NewGuid().GetHashCode());
            int randomValue = 0;

            for (int i = 0; i < numOfCharacters; i++)
            {
                randomValue = random.Next(0, 25);
                genString.Append((char)(randomValue + 65)); //65 is ASCII for "A"
            }
            return genString.ToString();
        }

        public string CreateSaltValue()
        {
            return GenerateStringRandomly(10);
        }

        public string CreateMSEAuthorityCode()
        {
            return GenerateStringRandomly(5);
        }

        public string GeneratePIN()
        {
            int PinLength = 4;
            StringBuilder pin = new StringBuilder();
            Random random = new Random(_StringProvider.NewGuid().GetHashCode());
            for (int idx = 0; idx < PinLength; idx++)
            {
                pin.Append(random.Next(0, 9));
            }
            return pin.ToString();
        }
    }
}
