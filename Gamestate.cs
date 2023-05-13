abstract class Gamestate {
    public Card carta {get; protected set;}
    public Card.Color? NextColor {
        get {
            if (carta is ColoredCard) {
                return carta.Colore;
            } else {
                return null;
            }
        }
    }

    public virtual uint NextTurn {
        get; protected set;
    } = 1;
}

sealed class InitialGamestate: Gamestate {
    InitialGamestate() {
        carta = Card.GetRandom();
    }
}

class PlayingGamestate: Gamestate {
    PlayingGamestate(Gamestate previous, Card _carta) {
        var primacarta = previous.carta;
        if (_carta is ColoredCard) {
            if (primacarta.NextColor == (ColoredCard.Color) _carta.Colore || primacarta.Action == _carta.Action) {
                carta = _carta;
            } else {
                throw new ApplicationException();
                carta = primacarta;
                NextTurn = 0;
            }
        } else {
            carta = _carta;
        }
    }
}