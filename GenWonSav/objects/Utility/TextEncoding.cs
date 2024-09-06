public static class TextEncoding {
    private static readonly Dictionary<char, byte> _charToHexMap = new Dictionary<char, byte>();
    private static readonly Dictionary<byte, char> _hexToCharMap = new Dictionary<byte, char>();
    
    static TextEncoding() {
        AddMapping('A', 0x80);
        AddMapping('B', 0x81);
        AddMapping('C', 0x82);
        AddMapping('D', 0x83);
        AddMapping('E', 0x84);
        AddMapping('F', 0x85);
        AddMapping('G', 0x86);
        AddMapping('H', 0x87);
        AddMapping('I', 0x88);
        AddMapping('J', 0x89);
        AddMapping('K', 0x8A);
        AddMapping('L', 0x8B);
        AddMapping('M', 0x8C);
        AddMapping('N', 0x8D);
        AddMapping('O', 0x8E);
        AddMapping('P', 0x8F);

        AddMapping('Q', 0x90);
        AddMapping('R', 0x91);
        AddMapping('S', 0x92);
        AddMapping('T', 0x93);
        AddMapping('U', 0x94);
        AddMapping('V', 0x95);
        AddMapping('W', 0x96);
        AddMapping('X', 0x97);
        AddMapping('Y', 0x98);
        AddMapping('Z', 0x99);
        AddMapping('(', 0x9A);
        AddMapping(')', 0x9B);
        AddMapping(':', 0x9C);
        AddMapping(';', 0x9D);
        AddMapping('[', 0x9E);
        AddMapping(']', 0x9F);

        AddMapping('a', 0xA0);
        AddMapping('b', 0xA1);
        AddMapping('c', 0xA2);
        AddMapping('d', 0xA3);
        AddMapping('e', 0xA4);
        AddMapping('f', 0xA5);
        AddMapping('g', 0xA6);
        AddMapping('h', 0xA7);
        AddMapping('i', 0xA8);
        AddMapping('j', 0xA9);
        AddMapping('k', 0xAA);
        AddMapping('l', 0xAB);
        AddMapping('m', 0xAC);
        AddMapping('n', 0xAD);
        AddMapping('o', 0xAE);
        AddMapping('p', 0xAF);
        
        AddMapping('q', 0xB0);
        AddMapping('r', 0xB1);
        AddMapping('s', 0xB2);
        AddMapping('t', 0xB3);
        AddMapping('u', 0xB4);
        AddMapping('v', 0xB5);
        AddMapping('w', 0xB6);
        AddMapping('x', 0xB7);
        AddMapping('y', 0xB8);
        AddMapping('z', 0xB9);

        AddMapping('×', 0xF1);
        AddMapping('^', 0xE1);
        AddMapping('&', 0xE2);
        AddMapping('-', 0xE3);
        AddMapping('?', 0xE6);
        AddMapping('!', 0xE7);
        AddMapping('♂', 0xEF);
        AddMapping('♂', 0xF5);
        AddMapping('/', 0xF3);
        AddMapping('.', 0xF2);
        AddMapping(',', 0xF4);
        AddMapping(' ', 0x7F);
    }

    private static void AddMapping(char character, byte hexValue) {
        _charToHexMap[character] = hexValue;
        _hexToCharMap[hexValue] = character;
    }

    public static byte GetHexValue(char character) {
        if (_charToHexMap.TryGetValue(character, out byte hexValue))
        {
            return hexValue;
        }
        else
        {
            throw new KeyNotFoundException($"Character '{character}' not found.");
        }
    }

    public static char GetCharacter(byte hexValue) {
        if (_hexToCharMap.TryGetValue(hexValue, out char character))
        {
            return character;
        }
        else {
            return character;
        }
    }   
}