
import './GameSidePanel.css'
import type { GameInfo } from "../services/GameInfoService";


function DetermineTurnContext(player: number, gameOver: boolean){

  if (gameOver){
    return "Game Over";
  }
  if (player == 1){
    return "Black's Turn";
  }
  return "White's Turn";
}

export default function GameSidePanel({
  gameInfo,
  onPass,
  onReset,
}: {
  gameInfo: GameInfo;
  onPass: () => void;
  onReset: () => void;
}) {

  const blackScore: number = gameInfo.ScoreBlack;
  const whiteScore: number = gameInfo.ScoreWhite;
  const turnContext: string = DetermineTurnContext(gameInfo.TurnPlayer, gameInfo.GameOver);
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
          <h4>{turnContext}</h4>
        </div>

        <div className="action-buttons">
          <button disabled={!enableButton} onClick={onPass}>Pass</button>
          <button onClick={onReset}>New Game</button>
        </div>

    </div>
  );
}
