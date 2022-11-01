using System;
using System.Runtime.CompilerServices;


public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {

        var splitNumbers = phoneNumber.Split("-");
        (string NewYorkLocalCode, string prefixCode, string last4digits) separatedNumber = 
            (splitNumbers.GetValue(0)?.ToString(), splitNumbers.GetValue(1)?.ToString(), splitNumbers.GetValue(2)?.ToString());

        if (separatedNumber.NewYorkLocalCode is "212" && separatedNumber.prefixCode is "555" &&
            separatedNumber.last4digits != null)
        {
            return (true, true, separatedNumber.last4digits);
        }
        
        if (separatedNumber.NewYorkLocalCode is "212" &&
                 separatedNumber.prefixCode is not "555" && separatedNumber.last4digits != null)
        {
            return (true, false, separatedNumber.last4digits);
        }
        
        if (separatedNumber.NewYorkLocalCode is not "212" &&
            separatedNumber.prefixCode is "555" && separatedNumber.last4digits != null)
        {
            return (false, true, separatedNumber.last4digits);
        }

        return (false, false, separatedNumber.last4digits);

        return phoneNumberInfo.IsFake;
    }
}