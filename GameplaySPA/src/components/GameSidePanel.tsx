
import './GameSidePanel.css'
import type { GameInfo } from "../services/GameInfoService";

function ParseTurnPlayer(player: number): string {
  if (player == 1){
    return "Black";
  }
  return "White";
}

export default function GameSidePanel({
  gameInfo,
}: {
  gameInfo: GameInfo;
}) {

  const blackScore: number = gameInfo.ScoreBlack;
  const whiteScore: number = gameInfo.ScoreWhite;
  const turnPlayer: string = ParseTurnPlayer(gameInfo.TurnPlayer);
  const enableButton: boolean = gameInfo.PlayerMustPass && !gameInfo.GameOver;

  return (
    <div className="game-side-panel">

        <div className="game-score">
            <div className="score-panel black">
              <h3>{blackScore}</h3>
            </div>
            <div className="spacer"></div>
            <div className="score-panel">
              <h3>{whiteScore}</h3>
            </div>
        </div>

        <div className="game-status">
          <h4>{turnPlayer}'s Turn</h4>
        </div>

        <div className="action-buttons">
          <button disabled={!enableButton}>Pass</button>
          <button>New Game</button>
        </div>

    </div>
  );
}
