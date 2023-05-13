using WebSocketSharp;

class Player: IDisposable {
    private WebSocket socket;
    public string? Nickname {get; protected set;}
    public uint cardNumber {
        get {
            return cardNumber;
        }
        protected set {
            if (value > 1) {
                SaidUno = false;
            }
            cardNumber = value;
        }
    }
    public bool SaidUno {get; protected set;} = false;

    private Game? gamejoined;

    public Player(WebSocket socketcon) {
        socket = socketcon;
        cardNumber = 0;
        socket.OnClose += OnSocketFault;
    }

    private void OnSocketFault(object sender, EventArgs e) {
        exitGame();
    }

    private void exitGame() {
        if (!(gamejoined is null)) {
            gamejoined.Players.Remove(this);
        }
        gamejoined = null;
    }

    protected void SayUno() {
        if (cardNumber == 1){
            SaidUno = true;
        }
    }

    public void Dispose() {
        socket.Close();
        exitGame();
    }
}
