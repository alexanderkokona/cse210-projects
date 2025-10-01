using System;

public class Fraction
{
    // Private attributes
    private int _top;
    private int _bottom;

    // Constructor: no parameters (defaults to 1/1)
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor: one parameter (numerator only)
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor: two parameters (numerator and denominator)
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter and Setter for Top
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    // Getter and Setter for Bottom
    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Method: return fraction string form
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Method: return decimal value
    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}
