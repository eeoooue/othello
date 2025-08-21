
import './GameSidePanel.css'

export default function GameSidePanel() {

  return (
    <div className="game-side-panel">

        <div className="game-score">
            <div className="score-panel black">
              <h3>10</h3>
            </div>
            <div className="spacer"></div>
            <div className="score-panel">
              <h3>10</h3>
            </div>
        </div>

        <div className="game-status">
          <h4>White's Turn</h4>
        </div>

        <div className="action-buttons">
          <button disabled={true}>Pass</button>
          <button>Concede</button>
        </div>

    </div>
  );
}
