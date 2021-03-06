﻿using System.Numerics;

namespace DockerBlockchainRest.Utils
{
    public static partial class TestType
    {
        public static bool IsAddress(object addresss)
        {
            if (addresss.ToString().Contains("0x") && addresss.ToString().Length == 42)
            {
                return true;
            }
            return false;
        }
        public static bool IsNumber(object number)
        {
            BigInteger number1;
            return BigInteger.TryParse(number.ToString(), out number1);
        }
    }
}
