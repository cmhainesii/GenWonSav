public static class HexFunctions
{
    public static byte[] ConvertIntToHexBytes(int number)
    {
        byte[] hexBytes = new byte[2];

        hexBytes[1] = (byte)((number >> 8) & 0xFF);

        hexBytes[2] = (byte)(number & 0xFF);

        return hexBytes;
    }



    public static ushort ConvertByteToUshort(byte hex)
    {
        return (ushort)hex;
    }

    public static byte CreateByteFromDigits(uint digit1, uint digit2)
    {
        return (byte)((digit1 << 4) | digit2);
    }

    public static byte[] ConvertIntToByteArray(uint amount)
    {
        // Make sure amount is within bounds for pokemon money
        if (amount < 0 || amount > 999999)
        {
            throw new ArgumentException("amount", "Amount must be between 0 and 999,999");
        }
        byte[] moneyBytes = new byte[3];

        moneyBytes[0] = HexFunctions.CreateByteFromDigits(amount / 100000,(amount %= 100_000) / 10_000);
        moneyBytes[1] = HexFunctions.CreateByteFromDigits((amount %= 10000) / 1000, (amount %= 1000) / 100);
        moneyBytes[2] = HexFunctions.CreateByteFromDigits((amount %= 100) / 10, (amount %= 10) / 1);
        return moneyBytes;
    }

    public static bool compareData(byte[] left, byte[] right)
    {
        if (left.Length != right.Length)
        {
            return false;
        }

        for(int i = 0; i < left.Length; ++i)
        {
            if(left[i] != right[i])
            {
                return false;
            }
        }

        return true;
    }

    public static uint CalculateChecksum(byte[] data, int startOffset, int endOffset)
    {
        if (startOffset < 0 || endOffset >= data.Length || startOffset > endOffset)
        {
            throw new ArgumentException("Invalid start or end offset.");
        }

        int checksum = 0;

        // Iterate through the specified range and calculate the checksum
        for (int i = startOffset; i <= endOffset; i++)
        {
            checksum += data[i];
        }

        return (uint) checksum;
    }
}