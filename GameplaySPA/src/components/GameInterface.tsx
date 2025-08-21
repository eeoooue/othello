import "./GameInterface.css";
import GameBoard from "./GameBoard";
import GameSidePanel from "./GameSidePanel";
import type { Piece } from "../services/BoardService";

export default function GameInterface({
  tiles,
  onTileClick,
}: {
  tiles: Piece[];
  onTileClick: (i: number, j: number) => void;
}) {
  return (
    <div className="game-interface">
      <GameBoard tiles={tiles} onTileClick={onTileClick} />
      <GameSidePanel />
    </div>
  );
}
