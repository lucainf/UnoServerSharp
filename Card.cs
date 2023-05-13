abstract class Card {
    public enum Color {
        Red,
        Green,
        Yellow,
        Blue,
        Black

    }
    public enum Option {
        Zero,
        One,
        Two,
        Tree,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Block,
        Reverse,
        AddTwo,
        ChangeColor,
        AddFour,
    }
    public Color Colore {get; protected set;}
    public Option Action {get; protected set;}
    public virtual ColoredCard.Color? NextColor {get {return (ColoredCard.Color)Colore;}}

    public static Card GetRandom() {
        Random random = new();
        if (random.Next(1, 27) <= 2) {
            return SpecialCard.GetRandom(random);
        } else {
            return ColoredCard.GetRandom(random);
        }
    }
}

class ColoredCard: Card {
    public new enum Color {
        Red,
        Green,
        Yellow,
        Blue
    }

    public new enum Option
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Block,
        Reverse,
        AddTwo,
    }

    public ColoredCard(Color color, Option action) {
        Colore = (Card.Color) color;
        Action = (Card.Option) action;
    }

    public static new ColoredCard GetRandom(Random rng) {
        Option CardAction = Option.Zero;
        Color CardColor = Color.Red;

        if (rng.Next(1,25) == 1) {
            CardAction = Option.Zero;
        } else {
            switch (rng.Next(1,12)) {
                case 1:
                    CardAction = Option.One;
                    break;
                case 2:
                    CardAction = Option.Two;
                    break;
                case 3:
                    CardAction = Option.Three;
                    break;
                case 4:
                    CardAction = Option.Four;
                    break;
                case 5:
                    CardAction = Option.Five;
                    break;
                case 6:
                    CardAction = Option.Six;
                    break;
                case 7:
                    CardAction = Option.Seven;
                    break;
                case 8:
                    CardAction = Option.Eight;
                    break;
                case 9:
                    CardAction = Option.Nine;
                    break;
                case 10:
                    CardAction = Option.Block;
                    break;
                case 11:
                    CardAction = Option.Reverse;
                    break;
                case 12:
                    CardAction = Option.AddTwo;
                    break;
                default:
                break;
            }
        }

        switch (rng.Next(1,4)) {
            case 1:
                CardColor = Color.Red;
                break;
            case 2:
                CardColor = Color.Green;
                break;
            case 3:
                CardColor = Color.Yellow;
                break;
            case 4:
                CardColor = Color.Yellow;
                break;
            default:
                break;
        }

        return new ColoredCard(CardColor, CardAction);
    }

    public static new ColoredCard GetRandom() {
        Random random = new();
        return GetRandom(random);
    }
}

sealed class SpecialCard: Card {
    public new enum Color {
        Black,
    }
    public new enum Option {
        ChangeColor,
        AddFour,
    }

    public ColoredCard.Color? NextColor {get; private set;}
    public SpecialCard(Option action) {
        Colore = (Card.Color) Color.Black;
        Action = (Card.Option) action;
    }

    public SpecialCard(Option action, ColoredCard.Color chosenColor) {
        Colore = (Card.Color) Color.Black;
        Action = (Card.Option) action;
        NextColor = chosenColor;
    }

    public static new SpecialCard GetRandom(Random rng) {
        if (rng.Next(1,2) == 1) {
            return new SpecialCard(Option.AddFour);
        } else {
            return new SpecialCard(Option.ChangeColor);
        }
    }

    public static new SpecialCard GetRandom() {
        Random random = new();
        return GetRandom(random);
    }
}