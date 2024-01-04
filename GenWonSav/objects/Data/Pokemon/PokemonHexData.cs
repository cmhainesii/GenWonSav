public class PokemonHexData {
    public byte[] data {get;}
    public byte[] otName {get;}
    public byte[] nickname {get;}
    public byte[] otId {get;}

    public PokemonHexData(byte[] data, byte[] otName, byte[] nickname, byte[] otId) {
        this.data = data;
        this.otName = otName;
        this.nickname = nickname;
        this.otId = otId;
    }
}