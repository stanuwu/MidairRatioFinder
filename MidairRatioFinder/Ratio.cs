namespace MidairRatioFinder;

public class Ratio
{
    public Ratio(int power, int gametick, double x, double y)
    {
        Power = power;
        Gametick = gametick;
        X = x;
        Y = y;
    }

    public int Power { get; set; }
    public int Gametick { get; set; }
    public double X  { get; set; }
    public double Y  { get; set; }
}