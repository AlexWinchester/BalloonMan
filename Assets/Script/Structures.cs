public struct Line
{
    public Line(float m, float b)
    {
        M = m;
        B = b;
    }

    public float M { get; set; }
    public float B { get; set; }

    public override string ToString() => $"({M}, {B})";
}
