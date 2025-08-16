
import './GameInterface.css'
import GameBoard from './GameBoard';
import GameSidePanel from './GameSidePanel';

export default function GameInterface() {

  return (
    <div className="game-interface">
        <GameBoard />
        <GameSidePanel/>
    </div>
  );
}
