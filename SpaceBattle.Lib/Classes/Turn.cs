public class Turn
{
    public int Position;
    public int Size;

    public Turn(int Position, int Size = 360)
    {
        this.Position = Position % Size;
        this.Size = Size;
    }

    public static Turn operator +(Turn v1, Turn v2)
    {
        return new Turn(v1.Position + v2.Position, v1.Size);
    }

    public static bool operator ==(Turn v1, Turn v2)
    {
        return (v1.Position == v2.Position && v1.Size == v2.Size);
    }

    public static bool operator !=(Turn v1, Turn v2)
    {
        return !(v1 == v2);
    }

    public override bool Equals(object? obj)
    {
        return obj is Turn angle && Position == angle.Position && Size == angle.Size;
    }

    public override int GetHashCode()
    {
        return new int[] { Position }.GetHashCode() + new int[] { Size }.GetHashCode();
    }
}
