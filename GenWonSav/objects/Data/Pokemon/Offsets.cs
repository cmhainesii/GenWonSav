internal class Offsets
{
    internal readonly int trainerNameOffset;
    internal readonly int rivalNameOffset;
    internal readonly int moneyOffset;
    internal readonly int ownedSeenSize;
    internal readonly int ownedOffset;
    internal readonly int seenOffset;
    internal readonly int partySizeOffset;
    internal readonly int bagSizeOffset;
    internal readonly int ballsPocketOffset;
    internal readonly int keyItemsPocketOffset;
    internal readonly int tmPocketOffset;
    internal readonly int checksumStart;
    internal readonly int checksumEnd;
    internal readonly int checksumLocation;
    internal readonly int partyNextPokemonOffset;
    internal readonly ushort currentlySetBoxOffset;
    internal readonly ushort currentBoxDataBegin;
    internal readonly ushort nextBoxOffset;
    internal readonly ushort nextBoxPokemonOffset;
    internal readonly ushort boxLevelOffset;
    internal readonly ushort boxIvOffset;
    internal readonly ushort boxOtNameOffset;
    internal readonly ushort boxNicknameOffset;
    internal readonly ushort boxEvOffset;
    internal readonly ushort badgesOffset;

    // internal const int checksumLocationOffset = 0x3523;

    // internal const int checksumStartOffset = 0x2598;
    // internal const int checksumEndOffset = 0x3522;
    
    public Offsets(int generation, bool cyrstal) {
        if(generation == 1) 
        {
            trainerNameOffset = 0x2598;
            rivalNameOffset = 0x25F6;
            moneyOffset = 0x25F3;
            ownedSeenSize = 0x13;
            ownedOffset = 0x25A3;
            seenOffset = 0x25B6;
            partySizeOffset = 0x2F2C;
            bagSizeOffset = 0x25C9;
            ballsPocketOffset = 0x00;
            keyItemsPocketOffset = 0x00;
            tmPocketOffset = 0x00;
            checksumStart = 0x2598;
            checksumEnd = 0x3522;
            checksumLocation = 0x3523;
            partyNextPokemonOffset = 0x2C; // 44
            currentlySetBoxOffset = 0x284C;
            currentBoxDataBegin = 0x30C0;
            nextBoxOffset = 0x462;
            nextBoxPokemonOffset = 0x21;
            boxLevelOffset = 0x03;
            boxIvOffset = 0x1B;
            boxOtNameOffset = 0x2AA;
            boxNicknameOffset = 0x386;
            boxEvOffset = 0x11;
            badgesOffset = 0x2602;
        }
        else { 
            // gsc all use the same offset here
            trainerNameOffset = 0x200B;
            rivalNameOffset = 0x2021;
            ownedSeenSize = 0x20; // 32 bits
            partyNextPokemonOffset = 48;
            nextBoxOffset = 0x450;
            nextBoxPokemonOffset = 0x20;
            boxLevelOffset = 0x1F;
            boxIvOffset = 0x15;
            boxOtNameOffset = 0x296;
            boxNicknameOffset = 0x372;
            boxEvOffset = 0x0B;

            if(cyrstal) {
                moneyOffset = 0x23DC;
                ownedOffset = 0x2A27;
                seenOffset = 0x2A47;
                partySizeOffset = 0x2865;       
                bagSizeOffset = 0x2420;
                ballsPocketOffset = 0x2465;
                keyItemsPocketOffset = 0x244A;
                tmPocketOffset = 0x23E7;
                checksumStart = 0x2009;
                checksumEnd = 0x2B82;
                checksumLocation = 0x2D0D;
                currentlySetBoxOffset = 0x2700;
                currentBoxDataBegin = 0x2D10;
                badgesOffset = 0x23E5;
                
            }
            else{
                moneyOffset = 0x23DB;   
                ownedOffset = 0x2A4C;
                seenOffset = 0x2A6C;
                partySizeOffset = 0x288A;
                bagSizeOffset = 0x241F;
                ballsPocketOffset = 0x2464;
                keyItemsPocketOffset = 0x2449;
                tmPocketOffset = 0x23E6;
                checksumStart = 0x2009;
                checksumEnd = 0x2D68;
                checksumLocation = 0x2D69;
                currentlySetBoxOffset = 0x2724;     
                currentBoxDataBegin = 0x2D6C;
                badgesOffset = 0x23E4;      
            }

        }
    }

    //= 0x2598; //gen1
}

