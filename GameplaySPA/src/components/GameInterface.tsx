import "./GameInterface.css";
import GameBoard from "./GameBoard";
import GameSidePanel from "./GameSidePanel";
import type { Piece } from "../services/BoardService";
import type { GameInfo } from "../services/GameInfoService";

export default function GameInterface({
  tiles,
  gameInfo,
  onTileClick,
  onPass,
  onReset,
}: {
  tiles: Piece[];
  gameInfo: GameInfo;
  onTileClick: (i: number, j: number) => void;
  onPass: () => void;
  onReset: () => void;
}) {
  return (
    <div className="game-interface">
      <GameBoard tiles={tiles} onTileClick={onTileClick} />
      <GameSidePanel gameInfo={gameInfo} onPass={onPass} onReset={onReset}/>
    </div>
  );
}
