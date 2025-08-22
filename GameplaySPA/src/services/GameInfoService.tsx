
export class GameInfo {
    public TurnPlayer: number;
    public ScoreBlack: number;
    public ScoreWhite: number;
    public PlayerMustPass: boolean;
    public GameOver: boolean;

    constructor(turnPlayer: number, scoreBlack: number, scoreWhite: number, playerMustPass: boolean, gameOver: boolean) {
        this.TurnPlayer = turnPlayer;
        this.ScoreBlack = scoreBlack;
        this.ScoreWhite = scoreWhite;
        this.PlayerMustPass = playerMustPass;
        this.GameOver = gameOver;
    }
}

export function getDummyGameInfo(){

    return new GameInfo(
        1,
        0,
        0,
        false,
        false,
    );
}

export async function getGameInfoFromApi(): Promise<GameInfo> {
    const res = await fetch("http://localhost:8080/othellogame/gameinfo", {
        mode: "cors",
        headers: { "Accept": "application/json" },
    });
    if (!res.ok) throw new Error(`GameInfo fetch failed: ${res.status}`);

    const data = await res.json();
    return new GameInfo(
        data.turnPlayer,
        data.scoreBlack,
        data.scoreWhite,
        data.playerMustPass,
        data.gameOver
    );
}

