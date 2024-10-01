using System;
using System.Text;
using System.Text.RegularExpressions;

class Colours
{
    private string colour = string.Empty;
    public string Colour
    {
        get
        {
            return colour;
        }
        set
        {
            if (colour == "red") {colour = value;}
            else if (colour == "blue") {colour = value;}
            else if (colour == "green") {colour = value;}
            else {throw new ArgumentException("Colour input invalid.");}
        }
    }

    private static int redInput;
    private static int blueInput;
    private static int greenInput;
    static Colours()
    {
        redInput = 12;
        blueInput = 14;
        greenInput = 13;
    }


    private int colourcount;
    public int ColourCount { get ; set ; }
    private int gamenum;
    public int GameNum
    {
        get
        { return gamenum; }
        set
        {
            if (gamenum <= Input.Games.Count)
            { gamenum = value; }
            else
            { throw new ArgumentException("Game number our of range."); }
        }
    }

    private bool iscolour;

    public static bool IsColour(int ColourCount, int ColourInput)
    {
        bool isColour = (ColourCount <= ColourInput)? true : false;
        return isColour;
    }

    public static bool GetGameNums(int gamenum)
    {
        bool isPossible;

        Colours red = new Colours();
        red.colour = "red";
        Colours blue = new Colours();
        blue.colour = "blue";
        Colours green = new Colours();
        green.colour = "green";

        red.colourcount = Input.ColourCount(red.colour, gamenum);
        blue.colourcount = Input.ColourCount(blue.colour, gamenum);
        green.colourcount = Input.ColourCount(green.colour, gamenum);
        red.iscolour = IsColour(red.colourcount, redInput);
        blue.iscolour = IsColour(blue.colourcount, blueInput);
        green.iscolour = IsColour(green.colourcount, greenInput);

        isPossible = (red.iscolour && blue.iscolour && green.iscolour) ? true : false;
        return isPossible;
        
    }
    public static int GetGamePower (int gamenum)
    {
        int gamePower = 0;

        Colours red = new Colours();
        red.colour = "red";
        Colours blue = new Colours();
        blue.colour = "blue";
        Colours green = new Colours();
        green.colour = "green";

        red.colourcount = Input.ColourCount(red.colour, gamenum);
        blue.colourcount = Input.ColourCount(blue.colour, gamenum);
        green.colourcount = Input.ColourCount(green.colour, gamenum);

        gamePower = red.colourcount*green.colourcount*blue.colourcount;
        return gamePower;

    }

}