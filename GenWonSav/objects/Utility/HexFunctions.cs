public static class HexFunctions
{
    public static byte[] ConvertIntToHexBytes(int number)
    {
        byte[] hexBytes = new byte[2];

        hexBytes[0] = (byte)((number >> 8) & 0xFF);

        hexBytes[1] = (byte)(number & 0XFF);

        return hexBytes;
    }

    public static ushort ConvertByteToUshort(byte hex)
    {
        return (ushort)hex;
    }
}