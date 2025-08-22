import "./GameInterface.css";
import GameBoard from "./GameBoard";
import GameSidePanel from "./GameSidePanel";
import type { Piece } from "../services/BoardService";
import type { GameInfo } from "../services/GameInfoService";

export default function GameInterface({
  tiles,
  gameInfo,
  onTileClick,
  onReset,
}: {
  tiles: Piece[];
  gameInfo: GameInfo;
  onTileClick: (i: number, j: number) => void;
  onReset: () => void;
}) {
  return (
    <div className="game-interface">
      <GameBoard tiles={tiles} onTileClick={onTileClick} />
      <GameSidePanel gameInfo={gameInfo} onReset={onReset}/>
    </div>
  );
}
