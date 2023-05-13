class Game: IObservable<Game> {
    Gamestate state;
    public List<Player> Players;
    private string password;

    public IDisposable Subscribe(IObserver<Game>) {
        return new IDisposable();
    }

    public void Join(Player giocatore);
    public void Exit();
}